namespace ApiProducto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TablaClientesV2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cliente",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Nombres = c.String(nullable: false, maxLength: 50),
                        apellidos = c.String(nullable: false, maxLength: 50),
                        Direccion = c.String(nullable: false, maxLength: 20),
                        Celular = c.String(nullable: false, maxLength: 10),
                        Estracto = c.String(nullable: false, maxLength: 1),
                        FechaNacimiento = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Cliente");
        }
    }
}
