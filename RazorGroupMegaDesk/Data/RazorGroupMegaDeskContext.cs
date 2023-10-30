using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazorGroupMegaDesk.Models;

namespace RazorGroupMegaDesk.Data
{
    public class RazorGroupMegaDeskContext : DbContext
    {
        public RazorGroupMegaDeskContext (DbContextOptions<RazorGroupMegaDeskContext> options)
            : base(options)
        {
        }

        public DbSet<RazorGroupMegaDesk.Models.Order> Order { get; set; } = default!;
    }
}
