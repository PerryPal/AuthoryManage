using System;
using System.Collections.Generic;
using System.Text;

namespace AuthoryManage.Models {
    /// <summary>
    /// 员工对应页面、页面动作关联
    /// </summary>
    public class EmpToMenu {
        /// <summary>
        /// 主键、自增
        /// </summary>
        public int FId { get; set; }
        /// <summary>
        /// 员工ID
        /// </summary>
        public long FEmpId { get; set; }
        /// <summary>
        /// 菜单ID
        /// </summary>
        public int FMenuId { get; set; }
        /// <summary>
        /// 动作集合（用json存储）
        /// </summary>
        public string FActionList { get; set; }
        /// <summary>
        /// 是否显示
        /// </summary>
        public bool FIsShow { get; set; }
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
