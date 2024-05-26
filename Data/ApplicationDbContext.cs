using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_pc.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace API_pc.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}