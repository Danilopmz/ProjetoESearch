using System.Collections.Generic;
using System.Linq;
using AplicacaoComercial.Data;
using AplicacaoComercial.Models;
using Microsoft.AspNetCore.Mvc;

namespace AplicacaoComercial.Controllers
{
    [Route("api/[controller]")]
    public class UsuarioController:Controller
    {
          Usuario cli = new Usuario();
        readonly ACContexto contexto;

        public UsuarioController(ACContexto contexto){
            this.contexto = contexto;
        }

        [HttpGet]
        public IEnumerable<Usuario> Listar(){
            return contexto.Usuario.ToList();
        }
        [HttpGet("{id}")]
        public Usuario Listar(int id){
            return contexto.Usuario.Where(x => x.Id==id).FirstOrDefault();
        }

        [HttpPost]
        public IActionResult Cadastro([FromBody] Usuario usuario){
            if(!ModelState.IsValid)
                return BadRequest("Não foi possivel enviar os dados para cadasto, pois os dados não seguem o padrão de cadastro.");
            
            contexto.Usuario.Add(usuario);
            int rs = contexto.SaveChanges();

            if(rs < 1)
                return BadRequest("Houve uma falha interna e não foi possivel cadastrar");
            
            else
                return Ok(usuario);
            
        }
        [HttpPut("{id}")]
        public IActionResult Atualizar([FromBody] Usuario usuario, int id){
              if(!ModelState.IsValid)
                return BadRequest("Não foi possivel enviar os dados para atualizar, pois os dados não seguem o padrão de atualização.");
            
            var cli = contexto.Usuario.Where(x => x.Id==id).FirstOrDefault();
            cli.Email = usuario.Email;
            cli.CPF = usuario.CPF;
            cli.NomeCliente = usuario.NomeCliente;
            cli.NomeUsuario = usuario.NomeUsuario;
            cli.Senha = usuario.Senha;
            cli.Nivel = usuario.Nivel;
            contexto.Usuario.Update(cli);
            int rs = contexto.SaveChanges();

            if(rs < 1)
                return BadRequest("Houve uma falha interna e não foi possivel cadastrar");
            
            else
                return Ok(usuario);
        }

        [HttpDelete("{id}")]
        public IActionResult Apagar(int id){
             
            var cli = contexto.Usuario.Where(x => x.Id==id).FirstOrDefault();
            if(cli==null)
                return BadRequest("Cliente não localizado");

            contexto.Usuario.Remove(cli);
            int rs = contexto.SaveChanges();

            if(rs > 0)
                return Ok();
            else
                return BadRequest();

        }
    }
}