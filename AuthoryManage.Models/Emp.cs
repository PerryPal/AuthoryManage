using System;
using System.Collections.Generic;
using System.Text;

namespace AuthoryManage.Models {
    /// <summary>
    /// 员工
    /// </summary>
    public class Emp {
        /// <summary>
        /// 员工ID
        /// </summary>
        public long FUserId { get; set; }
        /// <summary>
        /// 员工编号
        /// </summary>
        public string FNo { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string FEmail { get; set; }
        /// <summary>
        /// 手机号码
        /// </summary>
        public string FMobile { get; set; }
        /// <summary>
        /// 密码盐值
        /// </summary>
        public string FPwdSalt { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string FPwd { get; set; }
        /// <summary>
        /// 是否需要控制权限
        /// </summary>
        public bool FIsLimit { get; set; }
        /// <summary>
        /// 是否已经登陆
        /// </summary>
        public bool FIsLogin { get; set; }
        /// <summary>
        /// 是否禁止登陆
        /// </summary>
        public bool FIsLimitLogin { get; set; }
        /// <summary>
        /// 是否删除
        /// </summary>
        public bool FIsDelete { get; set; }
        /// <summary>
        /// 创建(修改)人
        /// </summary>
        public long? FOperateUserId { get; set; }
        /// <summary>
        /// 创建(修改)时间
        /// </summary>
        public DateTime FOperateTime { get; set; }
        /// <summary>
        /// 上次登录时间
        /// </summary>
        public DateTime? FLastLoginTime { get; set; }
        /// <summary>
        /// 上次登录信息
        /// </summary>
        public string FLastLoginDesc { get; set; }
        /// <summary>
        /// 上次登录端口
        /// </summary>
        public byte? FLastLoginSource { get; set; }
    }
}
