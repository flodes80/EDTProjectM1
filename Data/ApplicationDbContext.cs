using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EDTProjectM1.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Dbsets des bâtiments
        public DbSet<Models.Batiment> Batiments { get; set; }

        // Dbsets des groupes
        public DbSet<Models.Groupe> Groupes { get; set; }

        // Dbsets des salles
        public DbSet<Models.Salle> Salles { get; set; }

        // Dbsets des seances
        public DbSet<Models.Seance> Seances { get; set; }

        // Dbsets des types de seance
        public DbSet<Models.TypeSeance> TypesSeance { get; set; }

        // Dbsets des UEs
        public DbSet<Models.UE> UE { get; set; }
    }
}
