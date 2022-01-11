using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agenda.Models;
using Microsoft.EntityFrameworkCore;

namespace Agenda.DataBase 
{
    public class AgendaContext : DbContext
    {
        // Construtor padrão
        public AgendaContext(DbContextOptions<AgendaContext> options) : base(options)
        {
                
        }
        public DbSet<Aggenda> Agendas { get; set; }
    }
}
