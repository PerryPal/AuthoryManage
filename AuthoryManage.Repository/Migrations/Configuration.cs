namespace AuthoryManage.Repository.Migrations {
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using AuthoryManage.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<AuthoryManage.Repository.DbManage.AuthoryManageContext> {
        public Configuration() {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AuthoryManage.Repository.DbManage.AuthoryManageContext context) {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.

            ////添加用户
            //context.Users.AddOrUpdate(
            //  p => p.FId,
            //  new User { FId = 1, FType = (byte)UserType.员工 }
            //);
            ////添加员工
            //context.Emps.AddOrUpdate(
            //    p => p.FUserId,
            //    new Emp { FUserId = 1, FIsDelete = false, FIsLimit = false, FIsLimitLogin = false, FIsLogin = false, FNo = "0000000001", FOperateTime = DateTime.Now, FPwdSalt = "1234567890", FPwd = "42C224B3C8899047460F5A6D1C041411" }
            //);
        }
    }
}
