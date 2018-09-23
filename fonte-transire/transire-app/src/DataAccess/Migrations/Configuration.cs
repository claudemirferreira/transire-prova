using DataAccess.Contexto;
using Domain.Model;
using System.Data.Entity.Migrations;

namespace DataAccess.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<TransireContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(TransireContext context)
        {
            var produto = new Produto() { ProdutoID = 1, Nome = "Rice" };
            context.Produtos.Add(produto);
        }
    }
}
