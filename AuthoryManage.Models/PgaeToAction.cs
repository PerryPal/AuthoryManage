using System;
using System.Collections.Generic;
using System.Text;

namespace AuthoryManage.Models {
    /// <summary>
    /// 页面按钮关系
    /// </summary>
    public class PgaeToAction {
        /// <summary>
        /// 主键、自增
        /// </summary>
        public int FId { get; set; }
        /// <summary>
        /// 页面ID
        /// </summary>
        public int FMenuId { get; set; }
        /// <summary>
        /// 按钮ID
        /// </summary>
        public int FActionId { get; set; }
        /// <summary>
        /// 添加(修改)人
        /// </summary>
        public long FOperateUserId { get; set; }
        /// <summary>
        /// 添加(修改)时间
        /// </summary>
        public DateTime FOperateTime { get; set; }
    }
}
