using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;

namespace AuthoryManage.ModelMap {
    /// <summary>
    /// 用户表
    /// </summary>
    public class UserMap : EntityTypeConfiguration<Models.User> {
        public UserMap() {
            this.ToTable("t_User");//设置表名
            this.HasKey(m => m.FId);//设置主键
            this.Property(m => m.FId).IsRequired().HasColumnName("FId").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);//设置字段属性
            this.Property(m => m.FType).HasColumnName("FType");
        }
    }
}
