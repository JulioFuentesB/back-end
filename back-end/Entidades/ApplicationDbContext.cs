﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace back_end.Entidades
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext( DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<PeliculasActores>()
           .HasKey(x => new { x.ActorId, x.PeliculaId });

            modelBuilder.Entity<PeliculasCines>()
                .HasKey(x => new { x.CineId, x.PeliculaId });

            modelBuilder.Entity<PeliculasGeneros>()
                .HasKey(x => new { x.GeneroId, x.PeliculaId });


            base.OnModelCreating(modelBuilder);
        }


        public DbSet<Generos> Generos { get; set; }
        public DbSet<Actores> Actores { get; set; }

        public DbSet<Cines> Cines { get; set; }

        public DbSet<PeliculasActores> PeliculasActores { get; set; }
        public DbSet<PeliculasGeneros> PeliculasGeneros { get; set; }
        public DbSet<PeliculasCines> PeliculasCines { get; set; }



    }
}
