using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agenda.DataBase;
using Agenda.Models;
using Agenda.Controllers;
using Microsoft.EntityFrameworkCore;

namespace Agenda.Interface
{
    public interface IAgendaRepository
    {

        List<Informacoes> ObterTodos(Informacoes informacoes);
        Informacoes Obter(int id);
        void Cadastrar(Informacoes informacoes);
        void Atualizar(Informacoes informacoes);
        void Deletar(int id);
    }
}
