using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;

namespace AuthoryManage.ModelMap {
    /// <summary>
    /// 员工对应页面、页面动作关联表
    /// </summary>
    public class EmpToMenuMap:EntityTypeConfiguration<Models.EmpToMenu> {
        public EmpToMenuMap() {
            this.ToTable("t_EmpToMenu");
            this.HasKey(m => m.FId);
            this.Property(m => m.FId).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(m => m.FActionList).HasMaxLength(300).IsUnicode(false);
            this.Property(m => m.FEmpId).IsRequired();
            this.Property(m => m.FMenuId).IsRequired();
            this.Property(m => m.FOperateTime).IsRequired();
            this.Property(m => m.FOperateUserId).IsRequired();
        }
    }
}
