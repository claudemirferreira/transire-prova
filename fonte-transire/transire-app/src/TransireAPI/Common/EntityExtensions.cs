using TransireAPI.Models;
using Domain.Model;
using Domain;

namespace TransireAPI.Common
{
    public static class EntityExtensions
    {
        public static ProdutoModel ToModel(this Produto produto)
        {
            return new ProdutoModel
            {
                ProdutoID = produto.ProdutoID,
                Nome = produto.Nome
            };
        }       
    }
}