using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;

namespace AuthoryManage.ModelMap {
    /// <summary>
    /// 用户登录日志表
    /// </summary>
    public class LoginLogMap:EntityTypeConfiguration<Models.LoginLog> {
        public LoginLogMap() {
            this.ToTable("t_LoginLog");
            this.HasKey(m => m.FId);
            this.Property(m => m.FId).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(m => m.FLoginSource).IsRequired();
            this.Property(m => m.FLoginTime).IsRequired();
            this.Property(m => m.FUserId).IsRequired();
            this.Property(m => m.FLoginAddress).HasMaxLength(50).IsUnicode(true);
            this.Property(m => m.FLoginInfo).HasMaxLength(100).IsUnicode(true);
        }
    }
}
