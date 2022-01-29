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

        public Context(DbContextOptions options) : base(options)
        {
        }
        /* protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=tcp:apigamadbserver.database.windows.net,1433;Initial Catalog=API_db;User Id=alexandre@apigamadbserver;Password=Ladeira@55");
        }*/

        public virtual void SetModified(object entity)
        {
            Entry(entity).State = EntityState.Modified;
        }
    }
}
