using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using static WebApplicationDataGov.Models.EF_Models;

namespace WebApplicationDataGov.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
           
        public DbSet<School> Schools { get; set; }
    }
}
