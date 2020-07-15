using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BPO_API.Models;

namespace BPO_API.Data
{
    public class AuthenticationContext : DbContext
    {
        public AuthenticationContext (DbContextOptions<AuthenticationContext> options)
            : base(options)
        {
        }

        public DbSet<BPO_API.Models.Authentication> Authentication { get; set; }
    }
}
