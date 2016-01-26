using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthoryManage.Tools {
    public static class ConvertHelper {
        #region 将值安全转换为Int类型 SafeToInt32
        /// <summary>
        /// 将值安全转换为Int类型
        /// </summary>
        /// <param name="obj">需要转换的值</param>
        /// <param name="defValue">转换失败时的默认返回值</param>
        /// <returns></returns>
        public static int SafeToInt32(this object obj, int defValue = 0) {
            if (obj == null || string.IsNullOrEmpty(obj.ToString())) return defValue;
            int num;
            string s = obj.ToString().Trim().ToLower();
            switch (s) {
                case "true":
                    return 1;

                case "false":
                    return 0;
            }
            if (int.TryParse(s, out num)) return num;
            else return defValue;
        }
        #endregion
        #region 将值安全转换为Int?类型 SafeToInt32OrNull
        /// <summary>
        /// 将值安全转换为Int?类型
        /// </summary>
        /// <param name="obj">需要转换的值</param>
        /// <returns></returns>
        public static int? SafeToInt32OrNull(this object obj) {
            if (obj == null || string.IsNullOrEmpty(obj.ToString())) return null;
            int num;
            string s = obj.ToString().Trim().ToLower();
            switch (s) {
                case "true":
                    return 1;

                case "false":
                    return 0;
            }
            if (int.TryParse(s, out num)) return num;
            else return null;
        }
        #endregion

        #region 将值安全转换为Double类型 SafeToDouble
        /// <summary>
        /// 将值安全转换为Double类型
        /// </summary>
        /// <param name="obj">需要转换的值</param>
        /// <param name="defValue">转换失败时的默认返回值</param>
        /// <returns></returns>
        public static double SafeToDouble(this object obj, double defValue = 0) {
            if (obj == null || string.IsNullOrEmpty(obj.ToString())) return defValue;
            double num;
            string s = obj.ToString().Trim();
            if (double.TryParse(s, out num)) return num;
            else return defValue;
        }
        #endregion
        #region 将值安全转换为Double?类型 SafeToDoubleOrNull
        /// <summary>
        /// 将值安全转换为Double?类型
        /// </summary>
        /// <param name="obj">需要转换的值</param>
        /// <returns></returns>
        public static double? SafeToDoubleOrNull(this object obj) {
            if (obj == null || string.IsNullOrEmpty(obj.ToString())) return null;
            double num;
            string s = obj.ToString().Trim();
            if (double.TryParse(s, out num)) return num;
            else return null;
        }
        #endregion
    }
}
