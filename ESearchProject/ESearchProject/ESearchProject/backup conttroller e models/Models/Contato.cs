using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AplicacaoComercial.Models
{
    public class Contato
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id{ get; set; }

        [StringLength(30)]
        public string Telefone { get; set; }

        [StringLength(30)]
        public string  Celular { get; set; }

        [StringLength(100)]
        [EmailAddress]
        public string Email { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime Atualizacao{ get; set; }

        public Cliente Cliente { get; set; }
       public Funcionario  Funcionario{ get; set; }
        
    }
}