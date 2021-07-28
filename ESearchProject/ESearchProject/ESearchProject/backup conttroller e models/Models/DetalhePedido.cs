using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AplicacaoComercial.Models
{
    public class DetalhePedido
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [Required]
        [ForeignKey("Pedido")]

        public int IdPedido { get; set; }

        [Required]
        [ForeignKey("Produto")]

        public int IdProduto { get; set; }
        public int Quantidade { get; set; }

       public  Pedido Pedido { get; set; }
      public Produto Produto { get; set; }
    }
}