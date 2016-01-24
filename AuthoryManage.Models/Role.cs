using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthoryManage.Models {
    /// <summary>
    /// 角色
    /// </summary>
    public class Role {
        /// <summary>
        /// 主键自增
        /// </summary>
        public int FId { get; set; }
        /// <summary>
        /// 主键自增
        /// </summary>
        public int FParentId { get; set; }
        /// <summary>
        /// 角色名称
        /// </summary>
        public string FName { get; set; }
        /// <summary>
        /// 角色描述
        /// </summary>
        public string FDescript { get; set; }
        /// <summary>
        /// 是否删除
        /// </summary>
        public bool FIsDelete { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public byte? FSort { get; set; }
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
