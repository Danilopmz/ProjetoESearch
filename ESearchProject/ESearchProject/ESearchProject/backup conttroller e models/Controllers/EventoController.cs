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
    public class EventoController:Controller
    {
        Evento cli = new Evento();
        readonly ACContexto contexto;

        public EventoController(ACContexto contexto){
            this.contexto = contexto;
        }
        //autorizaçao
        // [Authorize("Bearer",Roles="Cliente")]
        // [HttpGet]
        // public IEnumerable<Evento> Listar(){
        //     return contexto.Evento.ToList();
        // }
        // [HttpGet("{id}")]
        // public Evento Listar(int id){
        //     return contexto.Evento.Where(x => x.Id==id).FirstOrDefault();
        // }

        [HttpPost]
        public IActionResult Cadastro([FromBody] Evento evento){
            if(!ModelState.IsValid)
                return BadRequest("Não foi possivel enviar os dados para cadasto, pois os dados não seguem o padrão de cadastro.");
            
            contexto.Evento.Add(evento);
            int rs = contexto.SaveChanges();

            if(rs < 1)
                return BadRequest("Houve uma falha interna e não foi possivel cadastrar");
            
            else
                return Ok(evento);
            
        }
        // [HttpPut("{id}")]
        // public IActionResult Atualizar([FromBody] Evento evento, int id){
        //       if(!ModelState.IsValid)
        //         return BadRequest("Não foi possivel enviar os dados para atualizar, pois os dados não seguem o padrão de atualização.");
            
        //     var cli = contexto.Evento.Where(x => x.Id==id).FirstOrDefault();

        //     cli.NomeEvento = evento.NomeEvento;
        //     cli.CEP = evento.CEP;
        //     contexto.Evento.Update(cli);
        //     int rs = contexto.SaveChanges();

        //     if(rs < 1)
        //         return BadRequest("Houve uma falha interna e não foi possivel cadastrar");
            
        //     else
        //         return Ok(evento);
        // }

        // [HttpDelete("{id}")]
        // public IActionResult Apagar(int id){
             
        //     var cli = contexto.Cliente.Where(x => x.Id==id).FirstOrDefault();
        //     if(cli==null)
        //         return BadRequest("Cliente não localizado");

        //     contexto.Cliente.Remove(cli);
        //     int rs = contexto.SaveChanges();

        //     if(rs > 0)
        //         return Ok();
        //     else
        //         return BadRequest();

        // }
    }
}