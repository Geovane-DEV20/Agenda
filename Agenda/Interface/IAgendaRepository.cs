using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agenda.DataBase;
using Agenda.Models;
using Microsoft.EntityFrameworkCore;

namespace Agenda.Interface
{
    public interface IAgendaRepository
    {
        void Cadastrar<T>(T entity) where T : class;
        void Atualizar<T>(T entity) where T : class;
        void Remover<T>(T entity) where T : class;
        Task<bool> SaveChangeAsync();

    }
}
