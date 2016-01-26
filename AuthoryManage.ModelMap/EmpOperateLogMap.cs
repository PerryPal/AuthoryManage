using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;

namespace AuthoryManage.ModelMap {
    /// <summary>
    /// 员工操作日志表
    /// </summary>
    public class EmpOperateLogMap:EntityTypeConfiguration<Models.EmpOperateLog> {
        public EmpOperateLogMap() {
            this.ToTable("t_EmpOperateLog");
            this.HasKey(m => m.FId);
            this.Property(m => m.FActionType).IsRequired();
            this.Property(m => m.FDesc).HasMaxLength(120).IsUnicode(true);
            this.Property(m => m.FId).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(m => m.FOperateAddress).HasMaxLength(100).IsUnicode(true);
            this.Property(m => m.FOperateIp).HasMaxLength(50).IsUnicode(false);
            this.Property(m => m.FOperateSource).IsRequired();
            this.Property(m => m.FOperateTime).IsRequired();
            this.Property(m => m.FOperateUserId).IsRequired();
            this.Property(m => m.FSourceInfo).HasMaxLength(100).IsUnicode(true);
            this.Property(m => m.FTitle).HasMaxLength(50).IsUnicode(true);
            this.Property(m => m.FMenuId).IsOptional();
        }
    }
}
