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

        [Required(ErrorMessage="Você precisa inserir o seu nome")]
        
        public string NomeCliente { get; set; }

        [Required(ErrorMessage="Você precisa inserir o Email")]
        
        public string Email { get; set; }

        [Required(ErrorMessage="Você precisa inserir o CPF")]
        
        public string CPF { get; set; }

        [Required( ErrorMessage="Você deve cadastrar usuários entre 2 e 20 caracteres")]
        
        public string NomeUsuario { get; set; }

        [Required( ErrorMessage="A senha é obrigatória")]
        
        public string Senha { get; set; }

        [Required(ErrorMessage="Você precisa definir o tipo de usuário: cliente; gerente; admin; supervisor")]
        public string Nivel { get; set; }
        
        
        // public Cliente Cliente { get; set; }

        

        
        
    }
}