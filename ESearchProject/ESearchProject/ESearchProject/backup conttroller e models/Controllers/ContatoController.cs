using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using AplicacaoComercial.Data;
using AplicacaoComercial.Models;
using Microsoft.AspNetCore.Mvc;

namespace AplicacaoComercial.Controllers
{
    [Route("api/[controller]")]
    public class ContatoController:Controller
    {
        Contato cli = new Contato();
        readonly ACContexto contexto;

        public ContatoController(ACContexto contexto){
            this.contexto = contexto;
        }

        [HttpGet]
        public IEnumerable<Contato> Listar(){
            return contexto.Contato.ToList();
        }
        [HttpGet("{id}")]
        public Contato Listar(int id){
            return contexto.Contato.Where(x => x.Id==id).FirstOrDefault();
        }

        [HttpPost]
        public IActionResult Cadastro([FromBody] Contato contato){
            if(!ModelState.IsValid)
                return BadRequest("Não foi possivel enviar os dados para cadasto, pois os dados não seguem o padrão de cadastro.");
            
            contato.Atualizacao = DateTime.Now;
            contexto.Contato.Add(contato);
            int rs = contexto.SaveChanges();

            if(rs < 1)
                return BadRequest("Houve uma falha interna e não foi possivel cadastrar");
            
            else
                return Ok(contato);
            
        }
        [HttpPut("{id}")]
        public IActionResult Atualizar([FromBody] Contato contato, int id){
              if(!ModelState.IsValid)
                return BadRequest("Não foi possivel enviar os dados para atualizar, pois os dados não seguem o padrão de atualização.");
            
            var co = contexto.Contato.Where(x => x.Id==id).FirstOrDefault();

            co.Telefone=contato.Telefone;
            co.Celular = contato.Celular;
            co.Email=contato.Email;
            co.Atualizacao = DateTime.Now;
            contexto.Contato.Update(co);
            int rs = contexto.SaveChanges();

            if(rs < 1)
                return BadRequest("Houve uma falha interna e não foi possivel cadastrar");
            
            else
                return Ok(co);
        }

        [HttpDelete("{id}")]
        public IActionResult Apagar(int id){
             
            var co = contexto.Contato.Where(x => x.Id==id).FirstOrDefault();
            if(co==null)
                return BadRequest("Contato não localizado");

            contexto.Contato.Remove(cli);
            int rs = contexto.SaveChanges();

            if(rs > 0)
                return Ok();
            else
                return BadRequest();

        }
    }
}