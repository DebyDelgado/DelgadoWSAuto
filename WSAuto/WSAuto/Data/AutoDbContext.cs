using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WSAuto.Models;

namespace WSAuto.Data
{
    public class AutoDbContext : DbContext
    {
        public AutoDbContext(DbContextOptions<AutoDbContext> options) : base(options) { }

        public DbSet<Auto> Auto { get; set; }
    }
}
