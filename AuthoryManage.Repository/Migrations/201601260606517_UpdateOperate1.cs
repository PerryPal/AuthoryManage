namespace AuthoryManage.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateOperate1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.t_EmpOperateLog", "FMenuId", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.t_EmpOperateLog", "FMenuId", c => c.Int(nullable: false));
        }
    }
}
