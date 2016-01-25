﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace AuthoryManage.Tools {
    public class IpHelper {
        private static object _locker = new object();//锁对象

        private const byte MODE1 = 0x01;//第一种模式
        private const byte MODE2 = 0x02;//第二种模式
        private const int LENGTH = 7;//每条记录长度

        private static bool _state = false;//状态
        private static FileStream _ipdatefile;//ip数据文件流
        private static long _indexareabegin;//索引区域开始偏移量
        private static long _indexareaend;//索引区域结束偏移量
        private static long _indexcount;//索引个数

        static IpHelper() {
            string filePath = Common.GetMapPath("/App_Data/Site/ipdata.config");
            if (File.Exists(filePath)) {
                try {
                    _ipdatefile = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
                }
                catch {
                    _ipdatefile.Close();
                    _ipdatefile.Dispose();
                    return;
                }
                _ipdatefile.Position = 0;
                _indexareabegin = ReadByte4();
                _indexareaend = ReadByte4();
                _indexcount = (_indexareaend - _indexareabegin) / LENGTH + 1;

                if (_indexcount > 0) {
                    _state = true;
                }
                else {
                    _ipdatefile.Close();
                    _ipdatefile.Dispose();
                }
            }
        }
        /// <summary>
        /// 搜索ip位置
        /// </summary>
        /// <param name="ip">ip</param>
        /// <returns></returns>
        public static IPLocation SearchLocation(string ip) {
            lock (_locker) {
                if (_state) {
                    try {
                        string[] ipList = ip.Split('.');
                        if (ipList.Length != 4)
                            return null;

                        byte[] ipByteArray = new byte[4];
                        for (int i = 0; i < 4; i++) {
                            ipByteArray[3 - i] = (byte)(Convert.ToInt32(ipList[i]) & 0xFF);
                        }
                        long ipUInt32 = BitConverter.ToUInt32(ipByteArray, 0);

                        //以下为二分查找算法
                        long searchBegin = 0;
                        long searchEnd = _indexcount - 1;
                        long begin = 0;
                        long offset = 0;
                        long end = 0;
                        while (true) {
                            SetIndex(searchBegin, out begin, out offset, out end);
                            if (ipUInt32 >= begin && ipUInt32 <= end)
                                return ReadIPLocation(offset);

                            SetIndex(searchEnd, out begin, out offset, out end);
                            if (ipUInt32 >= begin && ipUInt32 <= end)
                                return ReadIPLocation(offset);

                            SetIndex((searchBegin + searchEnd) / 2, out begin, out offset, out end);
                            if (ipUInt32 >= begin && ipUInt32 <= end)
                                return ReadIPLocation(offset);

                            if (ipUInt32 < begin)
                                searchEnd = (searchBegin + searchEnd) / 2;
                            else
                                searchBegin = (searchBegin + searchEnd) / 2;
                        }
                    }
                    catch {
                        return null;
                    }
                }
                return null;
            }
        }
        /// <summary>
        /// 读取位置
        /// </summary>
        /// <param name="offset">偏移量</param>
        /// <returns></returns>
        private static IPLocation ReadIPLocation(long offset) {
            IPLocation ipLocation = new IPLocation();

            _ipdatefile.Position = offset + 4;

            byte flag = (byte)_ipdatefile.ReadByte();
            if (flag == MODE1) {
                long countryOffset = ReadByte3();
                _ipdatefile.Position = countryOffset;
                flag = (byte)_ipdatefile.ReadByte();
                if (flag == MODE2) {
                    ipLocation.Country = ReadString(ReadByte3());
                    _ipdatefile.Position = countryOffset + 4;
                }
                else {
                    ipLocation.Country = ReadString(countryOffset);
                }
                ipLocation.Area = ReadArea(_ipdatefile.Position);
            }
            else if (flag == MODE2) {
                ipLocation.Country = ReadString(ReadByte3());
                ipLocation.Area = ReadArea(offset + 8);
            }
            else {
                ipLocation.Country = ReadString(--_ipdatefile.Position);
                ipLocation.Area = ReadString(_ipdatefile.Position);
            }
            return ipLocation;
        }
        /// <summary>
        /// 读取区域
        /// </summary>
        /// <param name="offset">偏移量</param>
        /// <returns></returns>
        private static string ReadArea(long offset) {
            _ipdatefile.Position = offset;
            byte flag = (byte)_ipdatefile.ReadByte();
            if (flag == MODE1 || flag == MODE2) {
                long areaOffset = ReadByte3(offset + 1);
                if (areaOffset == 0)
                    return "";
                else
                    return ReadString(areaOffset);
            }
            else {
                return ReadString(offset);
            }
        }

        private static string ReadString(long offset) {
            _ipdatefile.Position = offset;
            byte[] byteArray = new byte[256];
            int i = 0;
            for (i = 0, byteArray[i] = (byte)_ipdatefile.ReadByte(); byteArray[i] != (byte)(0); byteArray[++i] = (byte)_ipdatefile.ReadByte()) ;
            if (i > 0)
                return Encoding.GetEncoding("GB2312").GetString(byteArray, 0, i).TrimEnd('\0').Trim();
            else
                return "";
        }

        private static long ReadByte4() {
            byte[] byteArray = new byte[4];
            _ipdatefile.Read(byteArray, 0, 4);
            return BitConverter.ToUInt32(byteArray, 0);
        }

        private static long ReadByte3() {
            byte[] byteArray = new byte[4];
            byteArray[0] = (byte)_ipdatefile.ReadByte();
            byteArray[1] = (byte)_ipdatefile.ReadByte();
            byteArray[2] = (byte)_ipdatefile.ReadByte();
            byteArray[3] = 0;
            return BitConverter.ToUInt32(byteArray, 0);
        }

        private static long ReadByte3(long offset) {
            _ipdatefile.Position = offset;
            byte[] byteArray = new byte[4];
            byteArray[0] = (byte)_ipdatefile.ReadByte();
            byteArray[1] = (byte)_ipdatefile.ReadByte();
            byteArray[2] = (byte)_ipdatefile.ReadByte();
            byteArray[3] = 0;
            return BitConverter.ToUInt32(byteArray, 0);
        }

        private static void SetIndex(long pos, out long begin, out long offset, out long end) {
            _ipdatefile.Position = _indexareabegin + LENGTH * pos;
            begin = ReadByte4();
            offset = ReadByte3();
            _ipdatefile.Position = offset;
            end = ReadByte4();
        }
        /// <summary>
        /// 获取Ip对应的地址
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public static string GetIpAddress(string ip) {
            IPLocation ipLocation = SearchLocation(ip);
            if (ipLocation == null) return "";
            else return string.Format("{0}{1}", ipLocation.Country, ipLocation.Area);
        }
        /// <summary>
        /// 获得客户端的IP
        /// </summary>
        /// <returns>当前客户端的IP</returns>
        public static string GetRealIP() {
            string strIp = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

            if (string.IsNullOrEmpty(strIp)) {
                strIp = HttpContext.Current.Request.UserHostAddress;
            }
            if (string.IsNullOrEmpty(strIp)) {
                return "0.0.0.0";
            }
            return strIp;
        }
        /// <summary>
        /// 获取浏览器的版本以及名称
        /// </summary>
        /// <returns></returns>
        public static string GetBrowerVersion() {
            string browerVersion = string.Empty;
            if (System.Web.HttpContext.Current != null) {
                System.Web.HttpBrowserCapabilities browser = System.Web.HttpContext.Current.Request.Browser;
                if (browser != null) {
                    browerVersion = browser.Browser + browser.Version;
                }
            }
            return browerVersion;
        }
    }
    /// <summary>
    /// IP位置
    /// </summary>
    public class IPLocation {
        private string _country;//国家
        private string _area;//区域

        /// <summary>
        /// 国家
        /// </summary>
        public string Country {
            get { return _country; }
            set { _country = value; }
        }
        /// <summary>
        /// 区域
        /// </summary>
        public string Area {
            get { return _area; }
            set { _area = value; }
        }
    }
}
