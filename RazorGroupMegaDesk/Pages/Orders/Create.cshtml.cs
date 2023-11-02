using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorGroupMegaDesk.Models;

namespace RazorGroupMegaDesk.Pages.Orders
{
    public class CreateModel : PageModel
    {
        private readonly Data.RazorGroupMegaDeskContext _context;

        public CreateModel(Data.RazorGroupMegaDeskContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Order Order { get; set; } = default!;

        public SelectList SurfaceMaterialOptions { get; set; }

        public SelectList RushOrderOptions { get; set; }

        public IActionResult OnGet()
        {
            RushOrderOptions = new SelectList(new List<SelectListItem>
            {
                new SelectListItem("No Rush", "0"),
                new SelectListItem("3 days", "3"),
                new SelectListItem("5 days", "5"),
                new SelectListItem("7 days", "7"),
            }, "Value", "Text");

            SurfaceMaterialOptions = new SelectList(new List<SelectListItem>
            {
                new SelectListItem("Oak", "Oak"),
                new SelectListItem("Laminate", "Laminate"),
                new SelectListItem("Pine", "Pine"),
                new SelectListItem("Rosewood", "Rosewood"),
                new SelectListItem("Veneer", "Veneer")
            }, "Value", "Text");

            return Page();
        }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Order == null || Order == null)
            {
                return Page();
            }

            _context.Order.Add(Order);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
