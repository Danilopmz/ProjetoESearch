using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AplicacaoComercial.Models
{
    public class Produto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string NomeProduto { get; set; }

        [Required]
        [StringLength(30)]
        public string TipoProduto { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string Descricao { get; set; }

        [Required]
        public int Quantidade { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public double Preco { get; set; }

        public ICollection<DetalhePedido> DetalhePedido { get; set; }
    }
}