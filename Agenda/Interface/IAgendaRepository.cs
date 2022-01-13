using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agenda.Interface
{
    public interface IAgendaRepository
    {
        public void ObterTodosDados();
        public void Obter();
        public void Cadastrar();
        public void Atualizar();
        public void Deletar();

    }
}
