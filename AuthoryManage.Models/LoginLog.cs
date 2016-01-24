using System;
using System.Collections.Generic;
using System.Text;

namespace AuthoryManage.Models {
    /// <summary>
    /// 用户登录日志
    /// </summary>
    public class LoginLog {
        /// <summary>
        /// 主键、自增
        /// </summary>
        public int FId { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        public long FUserId { get; set; }
        /// <summary>
        /// 用户类型
        /// </summary>
        public byte? FUserType { get; set; }
        /// <summary>
        /// 登录时间
        /// </summary>
        public DateTime FLoginTime { get; set; }
        /// <summary>
        /// 登录IP
        /// </summary>
        public string FLoginIp { get; set; }
        /// <summary>
        /// 登录端口
        /// </summary>
        public Byte FLoginSource { get; set; }
        /// <summary>
        /// 登录地址
        /// </summary>
        public string FLoginAddress { get; set; }
        /// <summary>
        /// 登录信息
        /// </summary>
        public string FLoginInfo { get; set; }
        /// <summary>
        /// 是否登录成功
        /// </summary>
        public bool FIsSuccess { get; set; }
    }
}
