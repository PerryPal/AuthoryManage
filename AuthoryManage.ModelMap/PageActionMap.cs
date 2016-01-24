using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;

namespace AuthoryManage.ModelMap {
    /// <summary>
    /// 页面模块(按钮)表
    /// </summary>
    public class PageActionMap:EntityTypeConfiguration<Models.PageAction> {
        public PageActionMap() {
            this.ToTable("t_PageAction");
            this.HasKey(m => m.FId);
            this.Property(m => m.FDescript).HasMaxLength(200).IsUnicode(true);
            this.Property(m => m.FFontCode).HasMaxLength(50).IsUnicode(false);
            this.Property(m => m.FId).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(m => m.FLevel).IsRequired();
            this.Property(m => m.FName).IsRequired().HasMaxLength(30).IsUnicode(true);
            this.Property(m => m.FOperateCode).HasMaxLength(50).IsUnicode(false);
            this.Property(m => m.FOperateTime).IsRequired();
            this.Property(m => m.FOperateUserId).IsRequired();
        }
    }
}
