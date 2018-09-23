using TransireAPI.Models;
using Domain.Model;
using Domain;

namespace TransireAPI.Common
{
    public static class ModelExtensions
    {
        public static Produto ToEntity(this ProdutoModel produtoModel)
        {
            var entity = new Produto
            {
                ProdutoID = produtoModel.ProdutoID ?? 0,
                Nome = produtoModel.Nome,
                EntityState = produtoModel.ProdutoID == null ? EntityState.Added : EntityState.Modified
            };

            return entity;
        }
    }
}