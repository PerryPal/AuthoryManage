using AuthoryManage.InterfaceRepository;
using AuthoryManage.InterfaceService;
using AuthoryManage.Models;
using AuthoryManage.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthoryManage.Service {
    public class EmpService : BaseService<Models.Emp>, IEmpService {
        private readonly IEmpRepository _empRepository;
        private readonly ILoginLogRepository _loginLogRepository;
        public EmpService(IEmpRepository empRepository, ILoginLogRepository loginLogRepository)
            : base(empRepository) {
            this._empRepository = empRepository;
            this._loginLogRepository = loginLogRepository;
        }
        #region 员工登陆接口 Login
        /// <summary>
        /// 员工登陆接口
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="pwd">密码</param>
        /// <param name="loginSource">登陆来源</param>
        /// <returns></returns>
        public OperateResult Login(string userName, string pwd, byte loginSource) {
            OperateResult operateResult;
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(pwd)) {
                operateResult = new OperateResult(OperateStateType.ParamError, "用户名或密码不能为空!");
                return operateResult;
            }
            Emp empInfo;
            //先判断userName的类型
            if (Common.IsEmail(userName)) {//第一步先判断是否是邮箱
                empInfo = _empRepository.LoadEntities(m => m.FEmail == userName.Trim().ToLower() && !m.FIsDelete).FirstOrDefault();
            }
            else if (Common.IsMobile(userName)) {//第二步先判断是否是手机号码
                empInfo = _empRepository.LoadEntities(m => m.FMobile == userName.Trim() && !m.FIsDelete).FirstOrDefault();
            }
            else {
                empInfo = _empRepository.LoadEntities(m => m.FNo == userName.Trim() && !m.FIsDelete).FirstOrDefault();
            }
            if (empInfo == null) {
                operateResult = new OperateResult(OperateStateType.QueryNull, "该用户不存在!");
                return operateResult;
            }
            else {
                string loginIp = IpHelper.GetRealIP();
                string loginAddress = IpHelper.GetIpAddress(loginIp);
                string fLoginInfo = IpHelper.GetBrowerVersion();
                //判断密码是否正确
                if (empInfo.FPwd.Equals(MD5Helper.CreatePasswordMd5(pwd, empInfo.FPwdSalt))) {
                    //判断是否为可登录
                    if (empInfo.FIsLimitLogin) {
                        operateResult = new OperateResult(OperateStateType.Fail, "该用户被禁止登陆!");
                        return operateResult;
                    }
                    else {
                        operateResult = new OperateResult(OperateStateType.Success, empInfo);
                        //添加登陆信息，并修改登录历史纪录
                        LoginLog loginInfo = new LoginLog {
                            FIsSuccess = true,
                            FLoginAddress = loginAddress,
                            FLoginInfo = fLoginInfo,
                            FLoginIp = loginIp,
                            FLoginSource = loginSource,
                            FLoginTime = DateTime.Now,
                            FUserId = empInfo.FUserId,
                            FUserType = (byte)UserType.员工
                        };
                        empInfo.FLastLoginSource = loginSource;
                        empInfo.FLastLoginTime = DateTime.Now;
                        empInfo.FLastLoginDesc = string.Format("登陆IP：{0},登陆地址：{1},登陆来源{2}：{3}", loginIp, loginAddress, loginSource.GetEnumName<Models.LoginSource>(), fLoginInfo);
                        if (_empRepository.UpdateLoginInfo(empInfo, loginInfo)) {
                            return operateResult;
                        }
                        else {
                            operateResult.OperateState = OperateStateType.Error;
                            operateResult.OData = null;
                            operateResult.Message = "登录失败！";
                            return operateResult;
                        }
                    }
                }
                else {
                    operateResult = new OperateResult(OperateStateType.Fail, "用户名或密码错误!");
                    if (!empInfo.FIsLimitLogin) {
                        //添加登陆信息，并修改登录历史纪录
                        LoginLog loginInfo = new LoginLog {
                            FIsSuccess = false,
                            FLoginAddress = loginAddress,
                            FLoginInfo = fLoginInfo,
                            FLoginIp = loginIp,
                            FLoginSource = loginSource,
                            FLoginTime = DateTime.Now,
                            FUserId = empInfo.FUserId,
                            FUserType = (byte)UserType.员工
                        };
                        _loginLogRepository.AddEntity(loginInfo, true);
                        int errorCount = ConfigHelper.GetErrorCount();
                        int trueCount = _loginLogRepository.LoadEntities(m => m.FUserId == empInfo.FUserId && !m.FIsSuccess && m.FLoginTime <= DateTime.Now.AddMinutes(-ConfigHelper.GetErrorTime())).Count();
                        if (errorCount > 0 && trueCount >= errorCount) {
                            //将该员工设置为不可登录
                            empInfo.FIsLimitLogin = true;
                            EmpOperateLog operateLogInfo = new EmpOperateLog {
                                FActionType = 10,
                                FDesc = "由于输入密码错误次数过多，将此账号设置为禁止登陆",
                                FKeyId = empInfo.FUserId,
                                FOperateAddress = loginAddress,
                                FOperateIp = loginIp,
                                FOperateSource = loginSource,
                                FOperateTime = DateTime.Now,
                                FOperateUserId = empInfo.FUserId,
                                FSourceInfo = fLoginInfo,
                                FState = false,
                                FTitle = "多次登陆失败"
                            };
                            _empRepository.UpdateLimitLogin(empInfo, operateLogInfo);
                        }
                    }
                    return operateResult;
                }
            }
        }
        #endregion
    }
}
