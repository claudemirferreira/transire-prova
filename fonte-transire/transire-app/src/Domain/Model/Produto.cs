using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Model
{
    public class Produto : IEntity
    {
        public int ProdutoID { get; set; }

        public string Nome { get; set; }

        [NotMapped]
        public EntityState EntityState { get; set; }
    }
}