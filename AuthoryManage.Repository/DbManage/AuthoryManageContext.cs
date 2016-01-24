using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Text;

namespace AuthoryManage.Repository.DbManage {
    /// <summary>
    /// 数据库访问
    /// </summary>
    public class AuthoryManageContext : DbContext {
        public AuthoryManageContext()
            : base("AuthoryManageContext") {
            Database.SetInitializer<AuthoryManageContext>(null);
        }
        public DbSet<Models.Department> Departments { get; set; }
        public DbSet<Models.DeptToEmp> DeptToEmps { get; set; }
        public DbSet<Models.Emp> Emps { get; set; }
        public DbSet<Models.EmpOperateLog> EmpOperateLogs { get; set; }
        public DbSet<Models.EmpToMenu> EmpToMenus { get; set; }
        public DbSet<Models.LoginLog> LoginLogs { get; set; }
        public DbSet<Models.Menu> Menus{ get; set; }
        public DbSet<Models.PageAction> PageActions { get; set; }
        public DbSet<Models.PgaeToAction> PgaeToActions { get; set; }
        public DbSet<Models.Role> Roles { get; set; }
        public DbSet<Models.RoleToEmp> RoleToEmps { get; set; }
        public DbSet<Models.RoleToMenu> RoleToMenus { get; set; }
        public DbSet<Models.User> Users { get; set; }
        public virtual void Commit() {
            base.SaveChanges();
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            // 禁用默认表名复数形式
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            // 禁用一对多级联删除
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            // 禁用多对多级联删除
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            // 移除对MetaData表的查询验证
            modelBuilder.Conventions.Remove<IncludeMetadataConvention>();

            modelBuilder.Configurations.Add(new ModelMap.DepartmentMap());
            modelBuilder.Configurations.Add(new ModelMap.DeptToEmpMap());
            modelBuilder.Configurations.Add(new ModelMap.EmpMap());
            modelBuilder.Configurations.Add(new ModelMap.EmpOperateLogMap());
            modelBuilder.Configurations.Add(new ModelMap.EmpToMenuMap());
            modelBuilder.Configurations.Add(new ModelMap.LoginLogMap());
            modelBuilder.Configurations.Add(new ModelMap.MenuMap());
            modelBuilder.Configurations.Add(new ModelMap.PageActionMap());
            modelBuilder.Configurations.Add(new ModelMap.PgaeToActionMap());
            modelBuilder.Configurations.Add(new ModelMap.RoleMap());
            modelBuilder.Configurations.Add(new ModelMap.RoleToEmpMap());
            modelBuilder.Configurations.Add(new ModelMap.RoleToMenuMap());
            modelBuilder.Configurations.Add(new ModelMap.UserMap());
        }
    }
}
