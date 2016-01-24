using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;

namespace AuthoryManage.ModelMap {
    /// <summary>
    /// 员工表
    /// </summary>
    public class EmpMap : EntityTypeConfiguration<Models.Emp> {
        public EmpMap() {
            this.ToTable("t_Emp");
            this.HasKey(m => m.FUserId);
            this.Property(m => m.FUserId).IsRequired().HasColumnName("FUserId").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            this.Property(m => m.FEmail).HasColumnName("FEmail").HasMaxLength(100).IsUnicode(false);
            this.Property(m => m.FIsDelete).HasColumnName("FIsDelete");
            this.Property(m => m.FIsLimit).HasColumnName("FIsLimit");
            this.Property(m => m.FIsLimitLogin).HasColumnName("FIsLimitLogin");
            this.Property(m => m.FIsLogin).HasColumnName("FIsLogin");
            this.Property(m => m.FLastLoginDesc).HasColumnName("FLastLoginDesc").HasMaxLength(100).IsUnicode(true);
            this.Property(m => m.FLastLoginSource).HasColumnName("FLastLoginSource");
            this.Property(m => m.FLastLoginTime).HasColumnName("FLastLoginTime");
            this.Property(m => m.FMobile).HasColumnName("FMobile").HasMaxLength(11).IsUnicode(false);
            this.Property(m => m.FNo).HasColumnName("FNo").HasMaxLength(10).IsUnicode(false).IsRequired();
            this.Property(m => m.FOperateTime).HasColumnName("FOperateTime").IsRequired();
            this.Property(m => m.FOperateUserId).HasColumnName("FOperateUserId");
            this.Property(m => m.FPwd).HasColumnName("FPwd").HasMaxLength(200).IsUnicode(false).IsRequired();
            this.Property(m => m.FPwdSalt).HasColumnName("FPwdSalt").HasMaxLength(10).IsRequired().IsUnicode(false);
        }
    }
}
