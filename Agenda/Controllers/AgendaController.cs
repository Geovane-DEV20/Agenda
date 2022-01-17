using Microsoft.AspNetCore.Mvc;
using Agenda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Agenda.Interface;
using Agenda.Repositories;

namespace Agenda.Controllers
{
    [Route("api/agenda")]
    public class AgendaController : ControllerBase
    {
        private readonly IAgendaRepository _repository;

        public AgendaController(IAgendaRepository repository)
        {
            _repository = repository;
        }

        [Route("")]
        [HttpGet]
        //Ira retornar todos os dados (/api/agenda/1)
        public ActionResult ObterTodos(Informacoes informacoes)
        {
            var item = _repository.ObterTodos(informacoes);
            return Ok(item);
        }

        [Route("{id}")]
        [HttpGet]
        //Ira retornar somente um id (/api/agenda/1)
        public ActionResult Obter(int id)
        {
            var obj = _repository.Obter(id);

            if (obj == null)
            {
                return NotFound(); //404 Not Found indica que o servidor não conseguiu encontrar o recurso solicitado.
            }

            return Ok(obj);
        }

        [Route("")]
        [HttpPost]
        //Ira cadastrar uma nova pessoa na agenda. /api/agenda(POST: id, nome, telefone e endereço)
        //Adicionado o atributo FromBody que fica no corpo da requisição
        public IActionResult Cadastrar([FromBody]Informacoes informacoes)
        {
            try
            {
                _repository.Cadastrar(informacoes);
                return Created($"/api/agenda/{informacoes.Id}", informacoes);
            }

            catch (Exception e)
            {
                return BadRequest($"Erro {e}");
            }
        }

        [Route("{id}")]
        [HttpPost]
        //Ira atualizar uma nova pessoa na agenda. /api/agenda/1(Put: id, nome, telefone e endereço)
        public ActionResult Atualizar([FromBody] Informacoes informacoes)
        {

            _repository.Atualizar(informacoes);
            return Ok("Atualizado com sucesso");

        }

        [Route("{id}")]
        [HttpDelete]
        //Ira deletar uma pessoa na agenda. /api/agenda/1(Delete: id)
        public ActionResult Deletar(int id)
        {
            var obj = _repository.Obter(id);
            if (obj == null)
            {
                return NotFound();
            }

            _repository.Deletar(id);
            return NoContent(); //Indica que o servidor atendeu à solicitação com êxito e que não há conteúdo para enviar no corpo da carga útil da resposta
            
        }
    }
}