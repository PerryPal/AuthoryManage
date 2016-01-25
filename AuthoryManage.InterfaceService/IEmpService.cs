using AuthoryManage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthoryManage.InterfaceService {
    /// <summary>
    /// 员工
    /// </summary>
    public interface IEmpService :IBaseService<Emp> {
        #region 员工登陆接口 Login
        /// <summary>
        /// 员工登陆接口
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="pwd">密码</param>
        /// <param name="loginSource">登陆来源</param>
        /// <returns></returns>
        OperateResult Login(string userName, string pwd, byte loginSource);
        #endregion
    }
}
