using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthoryManage.Tools {
    public static class EnumHelper {
        /// <summary>
        /// 根据枚举类型和枚举值，获取枚举的文字(描述优先)
        /// </summary>
        /// <param name="type">枚举类型</param>
        /// <param name="obj">枚举值</param>
        /// <returns></returns>
        public static string GetEnumName<T>(this object obj) {
            if (obj == null) return string.Empty;
            string enumName = string.Empty;
            foreach (var item in Enum.GetValues(typeof(T))) {
                if ((int)obj == (int)item) {
                    var fi = typeof(T).GetField(item.ToString());
                    var attribute = fi.GetCustomAttributes(typeof(DescriptionAttribute), true).FirstOrDefault();
                    enumName = attribute == null ? Enum.GetName(typeof(T), obj) : ((DescriptionAttribute)attribute).Description;
                    break;
                }
            }
            return enumName;
        }
    }
}
