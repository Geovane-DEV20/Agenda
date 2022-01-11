using Agenda.DataBase;
using Microsoft.AspNetCore.Mvc;
using Agenda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Agenda.Controllers
{
    [Route("api/agenda")]
    public class AgendaController : ControllerBase
    {

        private readonly AgendaContext _banco;
        public AgendaController(AgendaContext banco)
        {
            _banco = banco;
        }

        [Route("")]
        [HttpGet]
        //Ira retornar somente todos os dados (/api/agenda/1)
        public ActionResult ObterTodosDados(int id)
        {
            return Ok(_banco.Agendas);
        }

        [Route("{id}")]
        [HttpGet]
        //Ira retornar somente um id (/api/agenda/1)
        public ActionResult Obter(int id)
        {
            var obj = _banco.Agendas.Find(id);
            
            if (obj == null)
            {
                return NotFound(); //404 Not Found indica que o servidor não conseguiu encontrar o recurso solicitado.
            }
           
            return Ok(_banco.Agendas.Find(id));
        }

        [Route("")] 
        [HttpPost]
        //Ira cadastrar uma nova pessoa na agenda. /api/agenda(POST: id, nome, telefone e endereço)
        //Adicionado o atributo FromBody que fica no corpo da requisição
        public ActionResult Cadastrar([FromBody]Aggenda agenda)
        {
            _banco.Agendas.Add(agenda);
            _banco.SaveChanges();

            return Created($"/api/agenda/{agenda.Id}", agenda);
        }

        [Route("{id}")]
        [HttpPut]
        //Ira atualizar uma nova pessoa na agenda. /api/agenda/1(Put: id, nome, telefone e endereço)
        public ActionResult Atualizar (int id, [FromBody]Aggenda agenda)
        {

            var obj = _banco.Agendas.AsNoTracking().FirstOrDefault(a => a.Id == id );

            if (obj == null)
            {
                return NotFound();
            }

            agenda.Id = id;
            _banco.Agendas.Update(agenda);
            _banco.SaveChanges();

            return Ok("Atualizado com sucesso");
        }

        [Route("{id}")]
        [HttpDelete]
        //Ira deletar uma pessoa na agenda. /api/agenda/1(Delete: id)
        public ActionResult Deletar(int id)
        {
            var obj = _banco.Agendas.Find(id);

            if (obj == null)
            {
                return NotFound();
            }

            _banco.Agendas.Remove(_banco.Agendas.Find(id));
            _banco.SaveChanges();
            return NoContent();
        }

    }
}
