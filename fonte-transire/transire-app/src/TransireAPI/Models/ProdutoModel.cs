using System.ComponentModel.DataAnnotations;

namespace TransireAPI.Models
{
    public class ProdutoModel
    {
        public int? ProdutoID { get; set; }
        [Required]
        public string Nome { get; set; }
    }
}