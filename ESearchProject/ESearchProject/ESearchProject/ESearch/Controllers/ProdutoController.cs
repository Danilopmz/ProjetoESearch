using System.Collections.Generic;
using System.Linq;
using AplicacaoComercial.Data;
using AplicacaoComercial.Models;
using Microsoft.AspNetCore.Mvc;

namespace AplicacaoComercial.Controllers
{
    [Route("api/[controller]")]
    public class ProdutoController:Controller
    {
         Produto prod = new Produto();
        readonly ACContexto contexto;

        public ProdutoController(ACContexto contexto){
            this.contexto = contexto;
        }
        // [Authorize("Bearer",Roles="Produto")]
        [HttpGet]
        // public IEnumerable<string> Listar(){
        public IEnumerable<Produto> Listar(){
            
        return contexto.Produto.ToList();
        }
        [HttpPost]
        public IActionResult Cadastro([FromBody] Produto produto){
            if(!ModelState.IsValid)
            return BadRequest();

            contexto.Produto.Add(produto);
            contexto.SaveChanges();
            return Ok(produto);
        }
    }
}