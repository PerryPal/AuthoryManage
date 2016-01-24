using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;

namespace AuthoryManage.ModelMap {
    /// <summary>
    /// 部门员工关系表
    /// </summary>
    public class DeptToEmpMap:EntityTypeConfiguration<Models.DeptToEmp> {
        public DeptToEmpMap() {
            this.ToTable("t_DeptToEmp");
            this.HasKey(m => m.FId);
            this.Property(m => m.FDeptId).IsRequired();
            this.Property(m => m.FEmpId).IsRequired();
            this.Property(m => m.FId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).IsRequired();
            this.Property(m => m.FOperateId).IsRequired();
            this.Property(m => m.FOperateTime).IsRequired();
        }
    }
}
