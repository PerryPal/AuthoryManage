using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;

namespace AuthoryManage.ModelMap {
    /// <summary>
    /// 角色与员工关系表
    /// </summary>
    public class RoleToEmpMap:EntityTypeConfiguration<Models.RoleToEmp> {
        public RoleToEmpMap() {
            this.ToTable("t_RoleToEmp");
            this.HasKey(m => m.FId);
            this.Property(m => m.FEmpId).IsRequired();
            this.Property(m => m.FId).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(m => m.FOperateTime).IsRequired();
            this.Property(m => m.FOperateUserId).IsRequired();
            this.Property(m => m.FRoleId).IsRequired();
        }
    }
}
