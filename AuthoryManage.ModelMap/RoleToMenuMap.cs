using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;

namespace AuthoryManage.ModelMap {
    /// <summary>
    /// 角色与页面、页面按钮之间的关联表
    /// </summary>
    public class RoleToMenuMap :EntityTypeConfiguration<Models.RoleToMenu>{
        public RoleToMenuMap() {
            this.ToTable("t_RoleToMenu");
            this.HasKey(m => m.FId);
            this.Property(m => m.FId).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(m => m.FActionList).IsUnicode(false).HasMaxLength(300);
            this.Property(m => m.FMenuId).IsRequired();
            this.Property(m => m.FOperateTime).IsRequired();
            this.Property(m => m.FOperateUserId).IsRequired();
            this.Property(m => m.FRoleId).IsRequired();
        }
    }
}
