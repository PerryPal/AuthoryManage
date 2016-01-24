using System;
using System.Collections.Generic;
using System.Text;

namespace AuthoryManage.Models {
    /// <summary>
    /// 用户
    /// </summary>
    public class User {
        /// <summary>
        /// 主键自增
        /// </summary>
        public long FId { get; set; }
        /// <summary>
        /// 用户类型(枚举)
        /// </summary>
        public byte? FType { get; set; }
    }
}
