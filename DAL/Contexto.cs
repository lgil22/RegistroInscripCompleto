using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using RegistroP.Entidades;
using Microsoft.EntityFrameworkCore;
using RegistroP.UI.Registros;
using RegistroP.UI;
using RegistroP.BLL;


namespace RegistroP.DAL.Scripts
{
    public class Contexto : DbContext
    {
        public DbSet<Personas> Personas { get; set; }
        public DbSet<Inscripciones> Inscripciones { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server = .\SqlExpress; Database = PersonasDb; Trusted_Connection = True; ");
        }
       
    }

}

