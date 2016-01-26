using AuthoryManage.InterfaceRepository;
using AuthoryManage.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthoryManage.Repository.MsSql {
    public class EmpRepository : BaseRepository<Models.Emp>, IEmpRepository {
        public EmpRepository(IDbFactory dbFactory) : base(dbFactory) { }
        #region 修改用户登录信息 UpdateLoginInfo
        /// <summary>
        /// 修改用户登录信息
        /// </summary>
        /// <param name="empInfo">用户信息</param>
        /// <param name="logInfo">登录记录信息</param>
        /// <returns></returns>
        public bool UpdateLoginInfo(Emp empInfo, LoginLog logInfo) {
            try {
                this.DetachEntity(m => m.FUserId == empInfo.FUserId);
                this.EditEntity(empInfo, new string[] { "FLastLoginSource", "FLastLoginTime", "FLastLoginDesc" });
                this.CurrentContext.Entry<LoginLog>(logInfo).State = EntityState.Added;
                return this.CurrentContext.SaveChanges() > 0;
            }
            catch (DbEntityValidationException dbEx) {
                var msg = string.Empty;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                    foreach (var validationError in validationErrors.ValidationErrors)
                        msg += Environment.NewLine + string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                var fail = new Exception(msg, dbEx);
                Tools.LogHelper.WriteLogFile(fail);
                return false;
            }
        }
        #endregion
        #region  修改员工是否可登录信息 bool UpdateLimitLogin
        /// <summary>
        /// 修改员工是否可登录信息
        /// </summary>
        /// <param name="empInfo">员工信息</param>
        /// <param name="operateLog">操作记录</param>
        /// <returns></returns>
        public bool UpdateLimitLogin(Emp empInfo, EmpOperateLog operateLog) {
            try {
                this.DetachEntity(m => m.FUserId == empInfo.FUserId);
                this.EditEntity(empInfo, new string[] { "FIsLimitLogin"});
                this.CurrentContext.Entry<EmpOperateLog>(operateLog).State = EntityState.Added;
                return this.CurrentContext.SaveChanges() > 0;
            }
            catch (DbEntityValidationException dbEx) {
                var msg = string.Empty;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                    foreach (var validationError in validationErrors.ValidationErrors)
                        msg += Environment.NewLine + string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                var fail = new Exception(msg, dbEx);
                Tools.LogHelper.WriteLogFile(fail);
                return false;
            }
        }
        #endregion
    }
}