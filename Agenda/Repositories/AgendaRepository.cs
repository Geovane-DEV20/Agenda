using Agenda.Interface;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Agenda.Models;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Agenda.DataBase;
using Agenda.Repositories;

namespace Agenda.Repositories
{
    public class AgendaRepository : IAgendaRepository
    {
        private readonly AgendaContext _context;
        public AgendaRepository(AgendaContext context)
        {
            _context = context;
        }
        public void Cadastrar<T>(T entity) where T : class
        {
            _context.Add(entity);
        }
        public void Atualizar<T>(T entity) where T : class
        {
            _context.Update(entity);
        }
        public void Remover<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }
        public async Task<bool> SaveChangeAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}
