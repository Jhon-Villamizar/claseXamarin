namespace ServiciosWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ValidacionCamposProductos : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Productoes", newName: "Producto");
            AlterColumn("dbo.Producto", "Nombre", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Producto", "Descripcion", c => c.String(maxLength: 200));
            AlterColumn("dbo.Producto", "Imagen", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Producto", "Imagen", c => c.String());
            AlterColumn("dbo.Producto", "Descripcion", c => c.String());
            AlterColumn("dbo.Producto", "Nombre", c => c.String());
            RenameTable(name: "dbo.Producto", newName: "Productoes");
        }
    }
}
