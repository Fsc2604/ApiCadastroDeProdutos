﻿using ApiCadastroDeProduto.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.CadastroDeProduto.Infra.Data.Context
{
    public class ConnectionDbContext : DbContext
    {
        public ConnectionDbContext(DbContextOptions<ConnectionDbContext> options) : base(options)
        {

        }
        
        // Indicativo de que as classes Person Product Purchase e demais, existem no banco de dados como tabela
        // Conexao com o banco
        public DbSet<Person> People { get; set; }
        public DbSet<Product> Product{ get; set; }
        public DbSet<Purchase> Purchase{ get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<PersonImage> PersonImages { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ConnectionDbContext).Assembly);
        }
    }
}
