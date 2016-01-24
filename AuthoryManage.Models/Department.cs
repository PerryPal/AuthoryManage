using System;
using System.Collections.Generic;
using System.Text;

namespace AuthoryManage.Models {
    /// <summary>
    /// 部门
    /// </summary>
    public class Department {
        /// <summary>
        /// 主键自增
        /// </summary>
        public int FId { get; set; }
        /// <summary>
        /// 所属部门
        /// </summary>
        public int FParentId { get; set; }
        /// <summary>
        /// 部门编号
        /// </summary>
        public string FNo { get; set; }
        /// <summary>
        /// 部门名称
        /// </summary>
        public string FName { get; set; }
        /// <summary>
        /// 部门描述
        /// </summary>
        public string FDescript { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public byte? FSort { get; set; }
        /// <summary>
        /// 是否删除
        /// </summary>
        public bool FIsDelete { get; set; }
        /// <summary>
        /// 创建人(或者修改人)
        /// </summary>
        public long FOperateUserId { get; set; }
        /// <summary>
        /// 创建时间(或者修改时间)
        /// </summary>
        public DateTime FOperateTime { get; set; }
    }
}
