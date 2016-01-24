using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;

namespace AuthoryManage.ModelMap {
    /// <summary>
    /// 菜单表
    /// </summary>
    public class MenuMap :EntityTypeConfiguration<Models.Menu>{
        public MenuMap() {
            this.ToTable("t_Menu");
            this.HasKey(m => m.FId);
            this.Property(m => m.FIcon).HasMaxLength(30).IsUnicode(false);
            this.Property(m => m.FId).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(m => m.FLayer).IsRequired();
            this.Property(m => m.FName).IsRequired().HasMaxLength(30).IsUnicode(true);
            this.Property(m => m.FOperateTime).IsRequired();
            this.Property(m => m.FOperateUserId).IsRequired();
            this.Property(m => m.FParentId).IsRequired();
            this.Property(m => m.FSort).IsRequired();
            this.Property(m => m.FUrl).HasMaxLength(80).IsUnicode(false);
        }
    }
}
