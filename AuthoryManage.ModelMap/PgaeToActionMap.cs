using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;

namespace AuthoryManage.ModelMap {
    /// <summary>
    /// 页面按钮关系表
    /// </summary>
    public class PgaeToActionMap : EntityTypeConfiguration<Models.PgaeToAction> {
        public PgaeToActionMap() {
            this.ToTable("t_PgaeToAction");
            this.HasKey(m => m.FId);
            this.Property(m => m.FActionId).IsRequired();
            this.Property(m => m.FId).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(m => m.FMenuId).IsRequired();
            this.Property(m => m.FOperateTime).IsRequired();
            this.Property(m => m.FOperateUserId).IsRequired();
        }
    }
}
