using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoGamaAcademy.Models
{
    public class Context : DbContext
    {
        public virtual DbSet<Posts> Posts { get; set; } 
        public virtual DbSet<Integrantes> Integrantes { get; set; } 
        public DbSet<Servicos> Servicos { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost;Database=GamaAcademy;Trusted_Connection=True");
        }
      
        public virtual void SetModified(object entity)
        {
            Entry(entity).State = EntityState.Modified;
        }
    }
}
