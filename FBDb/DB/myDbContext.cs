using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.DB
{
    internal class myDbContext : DbContext
    {
        private readonly IConfiguration _config;

        /*
        public RecentHealthIssueDBContext(IConfiguration configuration)
        {
            _config = configuration;
        }
        */

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost;Database=PetsDB;Trusted_Connection=True;Encrypt=False;");
            //Trust_Server_Certificate=True;
            //.\SQLEXPRESS
            //optionsBuilder.UseSqlServer()
        }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<OwnedPets> OwnedPets { get; set; }

    }
}
