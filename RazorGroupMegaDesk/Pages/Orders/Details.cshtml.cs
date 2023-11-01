using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorGroupMegaDesk.Models;

namespace RazorGroupMegaDesk.Pages.Orders
{
    public class DetailsModel : PageModel
    {
        private readonly Data.RazorGroupMegaDeskContext _context;

        public DetailsModel(Data.RazorGroupMegaDeskContext context)
        {
            _context = context;
        }

      public Order Order { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Order == null)
            {
                return NotFound();
            }

            var order = await _context.Order.FirstOrDefaultAsync(m => m.Id == id);
            if (order == null)
            {
                return NotFound();
            }
            else 
            {
                Order = order;
            }

            order.TotalAmount = order.CalculateTotal();
            return Page();
        }
    }
}
