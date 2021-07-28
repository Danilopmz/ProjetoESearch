using System.Collections.Generic;
using System.Linq;
using AplicacaoComercial.Data;
using AplicacaoComercial.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Net.Http;

namespace AplicacaoComercial.Controllers
{
    [Route("api/[controller]")]
    public class MarkersController:Controller
    {
         Markers mark = new Markers();
        readonly ACContexto contexto;

        public MarkersController(ACContexto contexto){
            this.contexto = contexto;
        }
        [Authorize("Bearer",Roles="Cliente")]
        [HttpGet]
        // public IEnumerable<string> Listar(){
        public IEnumerable<Markers> Listar(){

        return contexto.Markers.ToList();
        }

        // [HttpGet("{id}")]
        // public Markers Listar(int id){
        //     return contexto.Markers.Where(x => x.Id==id).FirstOrDefault();
        // }

        [HttpPost]
        public IActionResult Cadastro([FromBody] Markers markers){
            if(!ModelState.IsValid)
            return BadRequest();

            contexto.Markers.Add(markers);
            contexto.SaveChanges();
            return Ok(markers);
        }
        
    }
}