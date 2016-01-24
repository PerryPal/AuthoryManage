using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
namespace AuthoryManage.ModelMap {
    /// <summary>
    /// 角色表
    /// </summary>
    public class RoleMap:EntityTypeConfiguration<Models.Role> {
        public RoleMap() {
            this.ToTable("t_Role");
            this.HasKey(m => m.FId);
            this.Property(m => m.FDescript).HasMaxLength(150).IsUnicode(true);
            this.Property(m => m.FId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).IsRequired();
            this.Property(m => m.FName).IsUnicode(true).IsRequired().HasMaxLength(30);
            this.Property(m => m.FOperateTime).IsRequired();
            this.Property(m => m.FOperateUserId).IsRequired();
            this.Property(m => m.FParentId).IsRequired();
        }
    }
}
