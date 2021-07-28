using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AplicacaoComercial.Models
{
    public class Markers
    {    


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Required(ErrorMessage="Você precisa inserir o nome do Evento")]
        [StringLength(100)]
        public string name { get; set; }

        [Required(ErrorMessage="Você precisa inserir o cep e rua do Evento")]
        public string address { get; set; }

        [Required(ErrorMessage="Você precisa inserir a rua e o numero do local do Evento")]
        public string rua { get; set; }
        
        [Required(ErrorMessage="Você precisa inserir a data do Evento")]
        public string data { get; set; }

        //referenciar o evento
        [Required(ErrorMessage="Voce precisa inserir o horário de inicio do Evento")]
        public string inicio {get;set;}

        [Required(ErrorMessage="Voce precisa inserir o horário de termino do Evento")]
        public string termino {get;set;}

        [Required(ErrorMessage="Voce precisa inserir a descrição do Evento")]
        public string type {get;set;}

        [Required(ErrorMessage="Você precisa inserir preço do Evento")]
        public string preco { get; set; }
        // [Key]
        // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        // public int Id { get; set; }

        // [Required(ErrorMessage="Você precisa inserir o nome do Evento")]
        // [StringLength(100)]
        // public string Nome { get; set; }

        // [Required(ErrorMessage="Você precisa inserir o Cep do Evento")]
        // [StringLength(20)]
        // public string CEP { get; set; }

        // //referenciar o evento
        // [Required(ErrorMessage="Voce precisa inserir a Rua do Evento")]
        // [StringLength(100)]
        // public string Rua {get;set;}

        // [Required(ErrorMessage="Voce precisa inserir o Numero do Evento")]
        // [StringLength(10)]
        // public string NumeroLocal {get;set;}

        // [Required(ErrorMessage="Voce precisa inserir a data do Evento")]
        // public DateTime Data {get;set;}

        // [Required(ErrorMessage="Voce precisa inserir a hora de inicio do Evento")]
        // [StringLength(10)]
        // public string Inicio {get;set;}
        

        // [Required(ErrorMessage="Voce precisa inserir a rua do Evento")]
        // [StringLength(10)]
        // public string Final {get;set;}
        

        // [Required(ErrorMessage="Voce precisa inserir o preço do Evento, caso seja franca coloque 0")]
        // public double Preco {get;set;}

        

        
        // public Cliente Cliente {get;set;}
        


        // [DataType(DataType.DateTime)]
        // [DefaultValue("getDate()")]
        // public DateTime DataCadastro { get; set; }

        // public int IdUsuario { get; set; }
        // public Usuario Usuario{get;set;}

        // public int IdContato { get; set; }
        // public Contato Contato{get;set;}
        // public ICollection<Pedido> Pedido{get;set;}
        // public Evento Evento { get; set; }
        // public int IdEvento { get;set; }
        // public string NomeEvento { get;set; }
        // public string CEP { get;set; }
    }
}