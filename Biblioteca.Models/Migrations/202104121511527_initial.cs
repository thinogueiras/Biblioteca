namespace Biblioteca.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Aluno", "Nome", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Usuario", "UserName", c => c.String());
            AlterColumn("dbo.Usuario", "Password", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Usuario", "Password", c => c.String(nullable: false));
            AlterColumn("dbo.Usuario", "UserName", c => c.String(nullable: false));
            AlterColumn("dbo.Aluno", "Nome", c => c.String(nullable: false, maxLength: 80));
        }
    }
}
