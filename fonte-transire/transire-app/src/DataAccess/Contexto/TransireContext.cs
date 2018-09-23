using System.Data.Entity;
using Domain.Model;

namespace DataAccess.Contexto
{
    internal class TransireContext : DbContext
    {
        private const string DatabaseName = "TransireDB";
        public DbSet<Produto> Produtos { get; set; }

        public TransireContext() : base(DatabaseName)
        {
            var connectionString = Common.Configuration.GetConnectionStringForKey(DatabaseName);
            Database.Connection.ConnectionString = connectionString;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
        }
    }
}