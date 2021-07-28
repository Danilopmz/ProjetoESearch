using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using AplicacaoComercial.Data;
using AplicacaoComercial.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AplicacaoComercial.Controllers
{
    [Route("api/[controller]")]
    public class ClienteController:Controller
    {
        Cliente cli = new Cliente();
        readonly ACContexto contexto;

        public ClienteController(ACContexto contexto){
            this.contexto = contexto;
        }
        [Authorize("Bearer",Roles="Cliente")]
        [HttpGet]
        // public IEnumerable<string> Listar(){
        public IEnumerable<Cliente> Listar(){

        return contexto.Cliente.ToList();


    // var ev = (from c in contexto.Cliente 
    //                 join e in contexto.Evento on (c) equals e.Cliente
    //                 select new {
    //                     //campos do evento
    //                     c.CEP,
    //                     c.DataCadastro,
    //                     c.NomeCliente
    //                 }).ToList();


    //         return ev;





            
        }
        [HttpGet("{id}")]
        public Cliente Listar(int id){
            return contexto.Cliente.Where(x => x.Id==id).FirstOrDefault();
        }
        

        [HttpPost]
        public IActionResult Cadastro([FromBody] Cliente cliente){
            if(!ModelState.IsValid)
                return BadRequest("Não foi possivel enviar os dados para cadasto, pois os dados não seguem o padrão de cadastro.");
            
            contexto.Cliente.Add(cliente);
            int rs = contexto.SaveChanges();

            if(rs < 1)
                return BadRequest("Houve uma falha interna e não foi possivel cadastrar");
            
            else
                return Ok(cliente);

            
        }
        [HttpPut("{id}")]
        public IActionResult Atualizar([FromBody] Cliente cliente, int id){
              if(!ModelState.IsValid)
                return BadRequest("Não foi possivel enviar os dados para atualizar, pois os dados não seguem o padrão de atualização.");
            
            var cli = contexto.Cliente.Where(x => x.Id==id).FirstOrDefault();

            cli.NomeCliente = cliente.NomeCliente;
            cli.CPF = cliente.CPF;
            contexto.Cliente.Update(cli);
            int rs = contexto.SaveChanges();

            if(rs < 1)
                return BadRequest("Houve uma falha interna e não foi possivel cadastrar");
            
            else
                return Ok(cliente);
        }

        [HttpDelete("{id}")]
        public IActionResult Apagar(int id){
             
            var cli = contexto.Cliente.Where(x => x.Id==id).FirstOrDefault();
            if(cli==null)
                return BadRequest("Cliente não localizado");

            contexto.Cliente.Remove(cli);
            int rs = contexto.SaveChanges();

            if(rs > 0)
                return Ok();
            else
                return BadRequest();

        }
    }
}