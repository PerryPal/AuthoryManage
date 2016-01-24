using System;
using System.Collections.Generic;
using System.Text;

namespace AuthoryManage.Models {
    /// <summary>
    /// 页面模块(按钮)
    /// </summary>
    public class PageAction {
        /// <summary>
        /// 主键、自增
        /// </summary>
        public int FId { get; set; }
        /// <summary>
        /// 模块名称
        /// </summary>
        public string FName { get; set; }
        /// <summary>
        /// 模块代码(前台)
        /// </summary>
        public string FFontCode { get; set; }
        /// <summary>
        /// 模块代码(后台)
        /// </summary>
        public string FOperateCode { get; set; }
        /// <summary>
        /// 是否显示
        /// </summary>
        public bool FIsShow { get; set; }
        /// <summary>
        /// 等级
        /// </summary>
        public byte FLevel { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string FDescript { get; set; }
        /// <summary>
        /// 创建(修改)人
        /// </summary>
        public long FOperateUserId { get; set; }
        /// <summary>
        /// 创建(修改)时间
        /// </summary>
        public DateTime FOperateTime { get; set; }
    }
}
