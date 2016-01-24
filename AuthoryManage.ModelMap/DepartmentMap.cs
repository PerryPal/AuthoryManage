using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;

namespace AuthoryManage.ModelMap {
    /// <summary>
    /// 部门表
    /// </summary>
    public class DepartmentMap : EntityTypeConfiguration<Models.Department> {
        public DepartmentMap() {
            this.ToTable("t_Department");
            this.HasKey(m => m.FId);
            this.Property(m => m.FDescript).HasMaxLength(150).IsUnicode(true);
            this.Property(m => m.FId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).IsRequired();
            this.Property(m => m.FName).HasMaxLength(30).IsUnicode(true).IsRequired();
            this.Property(m => m.FNo).HasMaxLength(10).IsUnicode(false);
            this.Property(m => m.FOperateTime).IsRequired();
            this.Property(m => m.FOperateUserId).IsRequired();
            this.Property(m => m.FParentId).IsRequired();
        }
    }
}
