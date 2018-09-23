namespace DataAccess.Migrations

{
    using System.Data.Entity.Migrations;
    
    public partial class createDB : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Produto");
            DropTable("dbo.Produtoes");

            CreateTable(
                    "dbo.Produtoes",
                    c => new
                    {
                        ProdutoID = c.Int(nullable: false, identity: true),
                        Nome = c.String(maxLength: 200)
                    })
                    .PrimaryKey(t => t.ProdutoID);

            CreateStoredProcedure(
                "dbo.consultarProdutoPorNome",
                p => new
                {
                    Nome = p.String(50),
                },
                body:
                    @"SELECT ProdutoID, Nome from Produtoes WHERE Nome like '%'+@nome+'%'"
            );
        }
        
        public override void Down()
        {
            DropStoredProcedure("dbo.consultarProdutoPorNome");
            DropTable("dbo.Produto");
            DropTable("dbo.Produtoes");
        }
    }
}
