using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AplicacaoComercial.Models
{
    public class Funcionario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [Required(ErrorMessage="Você precisa inserir o nome do funcionario")]
        [StringLength(100)]
        public string NomeFuncionario { get; set; }
        
        [Required]
        public string Cargo { get; set; }
        
        [Required]
        [DataType(DataType.Currency)]
        public double Salario { get; set; }
        
        [ForeignKey("IdUsuario")]
        public int IdUsuario { get; set; }
  

         public Usuario Usuario{get;set;}

        public int IdContato { get; set; }
        public Contato Contato{get;set;}
    }
}