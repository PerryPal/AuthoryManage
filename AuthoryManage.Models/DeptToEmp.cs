using System;
using System.Collections.Generic;
using System.Text;

namespace AuthoryManage.Models {
    /// <summary>
    /// 部门员工关系
    /// </summary>
    public class DeptToEmp {
        /// <summary>
        /// 主键自增
        /// </summary>
        public int FId { get; set; }
        /// <summary>
        /// 部门ID
        /// </summary>
        public int FDeptId { get; set; }
        /// <summary>
        /// 员工ID
        /// </summary>
        public long FEmpId { get; set; }
        /// <summary>
        /// 操作(修改)人
        /// </summary>
        public long FOperateId { get; set; }
        /// <summary>
        /// 操作(修改)时间
        /// </summary>
        public DateTime FOperateTime { get; set; }
    }
}
