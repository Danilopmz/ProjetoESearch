using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AplicacaoComercial.Models
{
    public class Usuario
    {



        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(20,MinimumLength=2, ErrorMessage="Você deve cadastrar usuários entre 2 e 20 caracteres")]
        public string NomeUsuario { get; set; }

        [Required]
        [StringLength(255, ErrorMessage="A senha é obrigatória")]
        public string Senha { get; set; }

        [Required]
        [StringLength(30,ErrorMessage="Você precisa definir o tipo de usuário: cliente; gerente; admin; supervisor")]
        public string Nivel { get; set; }
        
        
        public Cliente Cliente { get; set; }

        
        public Funcionario  Funcionario{ get; set; }
    }
}