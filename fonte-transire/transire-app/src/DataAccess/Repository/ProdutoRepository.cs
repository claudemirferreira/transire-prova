using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DataAccess.Contexto;
using Domain.Model;

namespace DataAccess.Repository
{
    public class ProdutoRepository : IRepository<Produto>
    {
        public async Task<IEnumerable<Produto>> GetAll()
        {
            using (var context = new TransireContext())
            {
                return await context.Produtos
                                    .AsNoTracking()
                                    .ToListAsync();
            }
        }

        public async Task<IEnumerable<Produto>> Query(Expression<Func<Produto, bool>> predicate)
        {
            using (var context = new TransireContext())
            {
                return await context.Produtos
                                    .AsNoTracking()
                                    .Where(predicate)
                                    .ToListAsync();
            }
        }

        public async Task<Produto> GetById(int id)
        {
            using (var context = new TransireContext())
            {
                return await context.Produtos
                                    .AsNoTracking()
                                    .FirstOrDefaultAsync(x => x.ProdutoID == id);
            }
        }

        public async Task InsertOrUpdate(Produto produto)
        {
            using (var context = new TransireContext())
            {
                context.Entry(produto).State = produto.EntityState.ToEntityFrameworkState();
                await context.SaveChangesAsync();
            }
        }

        public async Task Delete(int id)
        {
            using (var context = new TransireContext())
            {
                var produto = context.Produtos.Find(id);
                if (produto == null) return;

                context.Produtos.Remove(produto);
                await context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Produto>> ListarPorNome(string Nome)
        {
            using (var context = new TransireContext())
            {
                return await context.Database.SqlQuery<Produto>("ConsultarProdutoPorNome @Nome", new SqlParameter("@Nome", Nome)).ToListAsync();                
            }

        }
    }

        
}