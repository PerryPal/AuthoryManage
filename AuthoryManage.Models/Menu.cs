using System;
using System.Collections.Generic;
using System.Text;

namespace AuthoryManage.Models {
    /// <summary>
    /// 菜单
    /// </summary>
    public class Menu {
        /// <summary>
        /// 主键、自增
        /// </summary>
        public int FId { get; set; }
        /// <summary>
        /// 父Id
        /// </summary>
        public int FParentId { get; set; }
        /// <summary>
        /// 菜单名称
        /// </summary>
        public string FName { get; set; }
        /// <summary>
        /// 菜单路径
        /// </summary>
        public string FUrl { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public byte FSort { get; set; }
        /// <summary>
        /// 菜单图标
        /// </summary>
        public string FIcon { get; set; }
        /// <summary>
        /// 所属层级（第一级传0）
        /// </summary>
        public byte FLayer { get; set; }
        /// <summary>
        /// 是否显示在菜单列表上
        /// </summary>
        public bool FIsShow { get; set; }
        /// <summary>
        /// 是否启用
        /// </summary>
        public bool FIsEnable { get; set; }
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
