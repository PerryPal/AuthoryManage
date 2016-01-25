using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace AuthoryManage.Tools {
    public class Common {
        #region 判断是否为正确的邮箱格式 IsEmail
        /// <summary>
        /// 判断是否为正确的邮箱格式
        /// </summary>
        /// <param name="email">要校验的邮箱账号</param>
        /// <returns></returns>
        public static bool IsEmail(string email) {
            if (string.IsNullOrEmpty(email)) return false;
            email = email.Trim();
            return Regex.IsMatch(email.Trim(), @"[A-Za-z0-9.%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", RegexOptions.IgnoreCase);
        }
        #endregion
        #region  判断是否为手机号码格式 IsMobile
        /// <summary>
        /// 判断是否为手机号码格式
        /// </summary>
        /// <param name="mobile">要校验的手机号码</param>
        /// <returns></returns>
        public static bool IsMobile(string mobile) {
            if (string.IsNullOrEmpty(mobile)) return false;
            mobile = mobile.Trim();
            if (mobile.Length != 11) return false;
            return Regex.IsMatch(mobile, @"1[3|5|7|8|][0-9]{9}");
        }
        #endregion
        #region 获得文件物理路径 GetMapPath
        /// <summary>
        /// 获得文件物理路径
        /// </summary>
        /// <returns></returns>
        public static string GetMapPath(string path) {
            if (HttpContext.Current != null) {
                return HttpContext.Current.Server.MapPath(path);
            }
            else {
                return System.Web.Hosting.HostingEnvironment.MapPath(path);
            }
        }
        #endregion
    }
}
