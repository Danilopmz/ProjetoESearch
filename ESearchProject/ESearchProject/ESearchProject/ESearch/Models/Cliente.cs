using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AplicacaoComercial.Models
{
    public class Cliente
    {    
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage="Você precisa inserir o nome do cliente")]
        [StringLength(100)]
        public string NomeCliente { get; set; }

        [Required(ErrorMessage="Você precisa inserir o cpf do cliente")]
        public string CPF { get; set; }
    

        [DataType(DataType.DateTime)]
        [DefaultValue("getDate()")]
        public DateTime DataCadastro { get; set; }

        public int IdUsuario { get; set; }
        public Usuario Usuario{get;set;}

        // public int IdContato { get; set; }
        // public Contato Contato{get;set;}
        // public ICollection<Pedido> Pedido{get;set;}
        //evento
        // public int IdEvento { get;set; }
        // public Evento Evento { get; set; }
    }
}