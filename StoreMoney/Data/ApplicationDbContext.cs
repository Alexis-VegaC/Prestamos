using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StoreMoney.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreMoney.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<StoresMoney> StoreMoney { get; set; }
        public DbSet<Movement> Movements { get; set; }
    }
}
