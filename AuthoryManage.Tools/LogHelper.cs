using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthoryManage.Tools {
    public class LogHelper {
        private static object _locker = new object();//锁对象
        static string errorLogPath = Common.GetMapPath(ConfigHelper.GetErrorLogValue());
        static string debugLogPath = Common.GetMapPath(ConfigHelper.GetDebugLogValue());
        #region  日志
        #region 写入调试日志
        public static void WriteDebugLogFile(string debugMessage) {
            WriteLogFile(debugMessage, debugLogPath);
        }
        #endregion
        #region 写入错误日志
        #region 写入普通错误日志
        /// <summary>
        /// 写入普通错误日志错误描述
        /// </summary>
        /// <param name="errorMessage"></param>
        public static void WriteLogFile(string errorMessage) {
            WriteLogFile(errorMessage, errorLogPath);
        }
        #endregion
        #region 写入错误异常日志文件
        /// <summary>
        /// 写入错误异常日志文件
        /// </summary>
        /// <param name="input">Exception</param>
        public static void WriteLogFile(Exception ex) {
            WriteLogFile(string.Format("方法:{0},异常信息:{1}", ex.TargetSite, ex.Message), errorLogPath);
        }
        #endregion
        #endregion
        #region 写入日志文件 WriteLogFile
        /// <summary>
        /// 写入日志文件
        /// </summary>
        /// <param name="input">输入内容</param>
        public static void WriteLogFile(string input,string filePath) {
            lock (_locker) {
                FileStream fs = null;
                StreamWriter sw = null;
                try {
                    if (!Directory.Exists(filePath)) {
                        Directory.CreateDirectory(filePath);
                    }
                    string fileName = filePath + DateTime.Now.ToString("yyyyMMdd") + ".log";

                    FileInfo fileInfo = new FileInfo(fileName);
                    if (fileInfo.Directory != null && !fileInfo.Directory.Exists) {
                        fileInfo.Directory.Create();
                    }
                    if (!fileInfo.Exists) {
                        fileInfo.Create().Close();
                    }
                    else if (fileInfo.Length > 2048 * 1000) {
                        fileInfo.Delete();
                    }
                    fs = fileInfo.OpenWrite();
                    sw = new StreamWriter(fs);
                    sw.BaseStream.Seek(0, SeekOrigin.End);
                    sw.Write("Log Start : ");
                    sw.Write("{0}", DateTime.Now.ToString("yyyy年MM月dd日 HH:mm:ss"));
                    sw.Write(Environment.NewLine);
                    sw.Write(input);
                    sw.Write(Environment.NewLine);
                    sw.Write("------------------------------------");
                    sw.Write("Log End");
                    sw.Write(Environment.NewLine);
                }
                catch (Exception) {
                }
                finally {
                    if (sw != null) {
                        sw.Flush();
                        sw.Close();
                    }
                    if (fs != null) {
                        fs.Close();
                    }
                }
            }
        }
        #endregion
        #endregion
    }
}
