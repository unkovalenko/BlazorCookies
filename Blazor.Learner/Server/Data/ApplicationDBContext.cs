using BlazorCookies.Server.Models;
using BlazorCookies.Shared.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorCookies.Models;

namespace BlazorCookies.Server.Data
{
    public class ApplicationDBContext : IdentityDbContext<ApplicationUser>
    {
        public virtual DbSet<USERS> USERS { get; set; }
        public virtual DbSet<PERSONAL> PERSONAL { get; set; }
        public virtual DbSet<CURRENCY> CURRENCY { get; set; }
        public virtual DbSet<EXCHCHECK> EXCHCHECK { get; set; }
        public virtual DbSet<EXCHANGE> EXCHANGE { get; set; }
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }
       
    }
}
