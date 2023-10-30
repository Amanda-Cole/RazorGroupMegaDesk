using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorGroupMegaDesk.Data;
using RazorGroupMegaDesk.Models;

namespace RazorGroupMegaDesk.Pages.Orders
{
    public class IndexModel : PageModel
    {
        private readonly RazorGroupMegaDesk.Data.RazorGroupMegaDeskContext _context;

        public IndexModel(RazorGroupMegaDesk.Data.RazorGroupMegaDeskContext context)
        {
            _context = context;
        }

        public IList<Order> Order { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Order != null)
            {
                Order = await _context.Order.ToListAsync();
            }
        }
    }
}
