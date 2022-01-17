using System;
using System.Collections.Generic;
using System.Linq;
using Agenda.Interface;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Agenda.Repositories;
using Agenda.Controllers;
using Agenda.Models;

namespace Agenda.Business
{
    public class AgendaBusiness
    {
        AgendaRepository agendaRepository = new AgendaRepository();
        private readonly IAgendaRepository _repository;

        public AgendaBusiness(IAgendaRepository repository)
        {
            _repository = repository;
        }
        public AgendaBusiness()
        {

        }
        
    }
}
