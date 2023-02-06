using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

using TravelLibrary.Server.Models.dbTravelLIB;

namespace TravelLibrary.Server.Data
{
    public partial class dbTravelLIBContext : DbContext
    {
        public dbTravelLIBContext(DbContextOptions<DbContext> opciones)
        {
        }

        public dbTravelLIBContext(DbContextOptions<dbTravelLIBContext> options) : base(options)
        {
        }

        partial void OnModelBuilding(ModelBuilder builder);

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<AutoresHasLibro>().HasKey(table => new {
                table.autores_id, table.libros_ISBN
            });

            builder.Entity<AutoresHasLibro>()
              .HasOne(i => i.Autore)
              .WithMany(i => i.AutoresHasLibros)
              .HasForeignKey(i => i.autores_id)
              .HasPrincipalKey(i => i.id);

            builder.Entity<AutoresHasLibro>()
              .HasOne(i => i.Libro)
              .WithMany(i => i.AutoresHasLibros)
              .HasForeignKey(i => i.libros_ISBN)
              .HasPrincipalKey(i => i.ISBN);

            builder.Entity<Libro>()
              .HasOne(i => i.Editoriale)
              .WithMany(i => i.Libros)
              .HasForeignKey(i => i.editoriales_id)
              .HasPrincipalKey(i => i.id);
            this.OnModelBuilding(builder);
        }

        public DbSet<Autore> Autores { get; set; }

        public DbSet<AutoresHasLibro> AutoresHasLibros { get; set; }

        public DbSet<Editoriale> Editoriales { get; set; }

        public DbSet<Libro> Libros { get; set; }
    }
}