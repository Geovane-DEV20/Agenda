using Agenda.Interface;
using System.Linq;
using Agenda.Controllers;
using Microsoft.AspNetCore.Mvc;
using Agenda.Models;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Agenda.DataBase;
using Agenda.Repositories;
using Agenda.Business;

namespace Agenda.Repositories
{
    public class AgendaRepository : IAgendaRepository
    {
        private readonly AgendaContext _banco;

        //Construtor
        public AgendaRepository(AgendaContext banco)
        {
            _banco = banco;
        }

        public AgendaRepository()
        {
        }

        public List<Informacoes> ObterTodos(Informacoes informacoes)
        {
            var item = _banco.Agendas.AsQueryable();
            /*
            if (pagRegistroPag.HasValue)
            {
                item = item.Skip((pagNumero.Value - 1) * pagRegistroPag.Value).Take(pagRegistroPag.Value);
            }
            */
            return item.ToList();
        }
        public Informacoes Obter(int id)
        {
            return _banco.Agendas.Find(id);
        }

        public void Cadastrar(Informacoes informacoes)
        {
            _banco.Agendas.Add(informacoes);
            _banco.SaveChanges();
        }
        public void Atualizar(Informacoes informacoes)
        {
            _banco.Agendas.Update(informacoes);
            _banco.SaveChanges();
        }
        public void Deletar(int id)
        {
            _banco.Agendas.Remove(_banco.Agendas.Find(id));
            _banco.SaveChanges();
        }




    }
}
