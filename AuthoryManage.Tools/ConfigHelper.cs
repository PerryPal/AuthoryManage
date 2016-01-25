using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace AuthoryManage.Tools {
    public class ConfigHelper {
        #region 获取日志文件
        private static readonly string webSitePath = "~/App_Data/Site/WebSite.xml";
        #region 获取错误日志文件路径 GetLogValue
        /// <summary>
        /// 获取错误文件路径
        /// </summary>
        /// <returns></returns>
        public static string GetErrorLogValue() {
            string path = GetLogValue("ErrorLog");
            if (string.IsNullOrEmpty(path)) path = "/App_Data/LogFile/Error/";
            return path;
        }
        #endregion
        #region 获取调试日志文件路径
        public static string GetDebugLogValue() {
            string path =GetLogValue("DebugLog");
            if (string.IsNullOrEmpty(path)) path = "/App_Data/LogFile/Debug/";
            return path;
        }
        #endregion
        #region 获取日志文件路径
        public static string GetLogValue(string attributeValue) {
            return GetValue(Common.GetMapPath(webSitePath), "LogSite", "Log", "key", attributeValue);
        }
        #endregion
        #endregion

        #region 根据节点属性读取子节点值 GetValue
        /// <summary>
        /// 根据节点属性读取子节点值
        /// </summary>
        /// <param name="filePath">读取路径</param>
        /// <param name="parentElement">父节点</param>
        /// <param name="attributeName">属性名</param>
        /// <param name="attributeValue">属性值</param>
        /// <returns></returns>
        public static string GetValue(string filePath, string parentElement, string elemName,string attributeName, string attributeValue) {
            XmlDocument xDoc = new XmlDocument();
            string value = string.Empty;
            xDoc.Load(filePath);
            try {
                XmlNode xNode;
                XmlElement xElem;
                xNode = xDoc.SelectSingleNode(string.Format("//{0}", parentElement));
                xElem = xNode.SelectSingleNode(string.Format("//{0}[@{1}='{2}']", elemName, attributeName, attributeValue)) as XmlElement;
                if (xElem != null) {
                    value = xElem.GetAttribute("value");
                }
            }
            catch (Exception e) {
                LogHelper.WriteLogFile(e);
            }
            return value;
        }
        #endregion
    }
}
