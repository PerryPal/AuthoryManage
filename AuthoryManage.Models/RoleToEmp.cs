using System;
using System.Collections.Generic;
using System.Text;

namespace AuthoryManage.Models {
    /// <summary>
    /// 角色与员工关系
    /// </summary>
    public class RoleToEmp {
        /// <summary>
        /// 主键自增
        /// </summary>
        public int FId { get; set; }
        /// <summary>
        /// 角色ID
        /// </summary>
        public int FRoleId { get; set; }
        /// <summary>
        /// 员工ID
        /// </summary>
        public int FEmpId { get; set; }
        /// <summary>
        /// 创建(修改)人
        /// </summary>
        public int FOperateUserId { get; set; }
        /// <summary>
        /// 创建(修改)时间
        /// </summary>
        public int FOperateTime { get; set; }
    }
}
