using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
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

    public IList<Order> Order { get; set; } = default!;
    [BindProperty(SupportsGet = true)]
    public string? SearchString { get; set; }

    public SelectList? Names { get; set; }

    [BindProperty(SupportsGet = true)]
    public string? OrderNames { get; set; }

    public async Task OnGetAsync()
    {
      if (_context.Order != null)
      {
        Order = await _context.Order.ToListAsync();
      }
      var orders = from m in _context.Order
                   select m;
      if (!string.IsNullOrEmpty(SearchString))
      {
        orders = orders.Where(s => s.CustomerName.Contains(SearchString));
      }

      Order = await orders.ToListAsync();
    }
    public async Task<IActionResult> OnGetSortByName()
    {
      Order = await _context.Order.OrderBy(s => s.CustomerName).ToListAsync();
      return Page();
    }
    public async Task<IActionResult> OnGetSortByDate()
    {
      Order = await _context.Order.OrderBy(s => s.OrderDate).ToListAsync();
      return Page();
    }
  }
}
