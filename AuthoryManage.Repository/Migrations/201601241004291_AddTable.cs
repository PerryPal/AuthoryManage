namespace AuthoryManage.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.t_Department",
                c => new
                    {
                        FId = c.Int(nullable: false, identity: true),
                        FParentId = c.Int(nullable: false),
                        FNo = c.String(maxLength: 10, unicode: false),
                        FName = c.String(nullable: false, maxLength: 30),
                        FDescript = c.String(maxLength: 150),
                        FSort = c.Byte(),
                        FIsDelete = c.Boolean(nullable: false),
                        FOperateUserId = c.Long(nullable: false),
                        FOperateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.FId);
            
            CreateTable(
                "dbo.t_DeptToEmp",
                c => new
                    {
                        FId = c.Int(nullable: false, identity: true),
                        FDeptId = c.Int(nullable: false),
                        FEmpId = c.Long(nullable: false),
                        FOperateId = c.Long(nullable: false),
                        FOperateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.FId);
            
            CreateTable(
                "dbo.t_EmpOperateLog",
                c => new
                    {
                        FId = c.Long(nullable: false, identity: true),
                        FKeyId = c.Long(nullable: false),
                        FActionType = c.Byte(nullable: false),
                        FMenuId = c.Int(nullable: false),
                        FTitle = c.String(maxLength: 50),
                        FDesc = c.String(maxLength: 120),
                        FOperateIp = c.String(maxLength: 50, unicode: false),
                        FOperateAddress = c.String(maxLength: 100),
                        FOperateSource = c.Byte(nullable: false),
                        FSourceInfo = c.String(maxLength: 100),
                        FState = c.Boolean(nullable: false),
                        FOperateUserId = c.Long(nullable: false),
                        FOperateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.FId);
            
            CreateTable(
                "dbo.t_Emp",
                c => new
                    {
                        FUserId = c.Long(nullable: false),
                        FNo = c.String(nullable: false, maxLength: 10, unicode: false),
                        FEmail = c.String(maxLength: 100, unicode: false),
                        FMobile = c.String(maxLength: 11, unicode: false),
                        FPwdSalt = c.String(nullable: false, maxLength: 10, unicode: false),
                        FPwd = c.String(nullable: false, maxLength: 200, unicode: false),
                        FIsLimit = c.Boolean(nullable: false),
                        FIsLogin = c.Boolean(nullable: false),
                        FIsLimitLogin = c.Boolean(nullable: false),
                        FIsDelete = c.Boolean(nullable: false),
                        FOperateUserId = c.Long(),
                        FOperateTime = c.DateTime(nullable: false),
                        FLastLoginTime = c.DateTime(),
                        FLastLoginDesc = c.String(maxLength: 100),
                        FLastLoginSource = c.Byte(),
                    })
                .PrimaryKey(t => t.FUserId);
            
            CreateTable(
                "dbo.t_EmpToMenu",
                c => new
                    {
                        FId = c.Int(nullable: false, identity: true),
                        FEmpId = c.Long(nullable: false),
                        FMenuId = c.Int(nullable: false),
                        FActionList = c.String(maxLength: 300, unicode: false),
                        FIsShow = c.Boolean(nullable: false),
                        FOperateUserId = c.Long(nullable: false),
                        FOperateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.FId);
            
            CreateTable(
                "dbo.t_LoginLog",
                c => new
                    {
                        FId = c.Int(nullable: false, identity: true),
                        FUserId = c.Long(nullable: false),
                        FUserType = c.Byte(),
                        FLoginTime = c.DateTime(nullable: false),
                        FLoginIp = c.String(),
                        FLoginSource = c.Byte(nullable: false),
                        FLoginAddress = c.String(maxLength: 50),
                        FLoginInfo = c.String(maxLength: 100),
                        FIsSuccess = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.FId);
            
            CreateTable(
                "dbo.t_Menu",
                c => new
                    {
                        FId = c.Int(nullable: false, identity: true),
                        FParentId = c.Int(nullable: false),
                        FName = c.String(nullable: false, maxLength: 30),
                        FUrl = c.String(maxLength: 80, unicode: false),
                        FSort = c.Byte(nullable: false),
                        FIcon = c.String(maxLength: 30, unicode: false),
                        FLayer = c.Byte(nullable: false),
                        FIsShow = c.Boolean(nullable: false),
                        FIsEnable = c.Boolean(nullable: false),
                        FOperateUserId = c.Long(nullable: false),
                        FOperateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.FId);
            
            CreateTable(
                "dbo.t_PageAction",
                c => new
                    {
                        FId = c.Int(nullable: false, identity: true),
                        FName = c.String(nullable: false, maxLength: 30),
                        FFontCode = c.String(maxLength: 50, unicode: false),
                        FOperateCode = c.String(maxLength: 50, unicode: false),
                        FIsShow = c.Boolean(nullable: false),
                        FLevel = c.Byte(nullable: false),
                        FDescript = c.String(maxLength: 200),
                        FOperateUserId = c.Long(nullable: false),
                        FOperateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.FId);
            
            CreateTable(
                "dbo.t_PgaeToAction",
                c => new
                    {
                        FId = c.Int(nullable: false, identity: true),
                        FMenuId = c.Int(nullable: false),
                        FActionId = c.Int(nullable: false),
                        FOperateUserId = c.Long(nullable: false),
                        FOperateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.FId);
            
            CreateTable(
                "dbo.t_Role",
                c => new
                    {
                        FId = c.Int(nullable: false, identity: true),
                        FParentId = c.Int(nullable: false),
                        FName = c.String(nullable: false, maxLength: 30),
                        FDescript = c.String(maxLength: 150),
                        FIsDelete = c.Boolean(nullable: false),
                        FSort = c.Byte(),
                        FOperateUserId = c.Long(nullable: false),
                        FOperateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.FId);
            
            CreateTable(
                "dbo.t_RoleToEmp",
                c => new
                    {
                        FId = c.Int(nullable: false, identity: true),
                        FRoleId = c.Int(nullable: false),
                        FEmpId = c.Int(nullable: false),
                        FOperateUserId = c.Int(nullable: false),
                        FOperateTime = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FId);
            
            CreateTable(
                "dbo.t_RoleToMenu",
                c => new
                    {
                        FId = c.Int(nullable: false, identity: true),
                        FRoleId = c.Int(nullable: false),
                        FMenuId = c.Int(nullable: false),
                        FActionList = c.String(maxLength: 300, unicode: false),
                        FIsShow = c.Boolean(nullable: false),
                        FOperateUserId = c.Long(nullable: false),
                        FOperateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.FId);
            
            CreateTable(
                "dbo.t_User",
                c => new
                    {
                        FId = c.Long(nullable: false, identity: true),
                        FType = c.Byte(),
                    })
                .PrimaryKey(t => t.FId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.t_User");
            DropTable("dbo.t_RoleToMenu");
            DropTable("dbo.t_RoleToEmp");
            DropTable("dbo.t_Role");
            DropTable("dbo.t_PgaeToAction");
            DropTable("dbo.t_PageAction");
            DropTable("dbo.t_Menu");
            DropTable("dbo.t_LoginLog");
            DropTable("dbo.t_EmpToMenu");
            DropTable("dbo.t_Emp");
            DropTable("dbo.t_EmpOperateLog");
            DropTable("dbo.t_DeptToEmp");
            DropTable("dbo.t_Department");
        }
    }
}
