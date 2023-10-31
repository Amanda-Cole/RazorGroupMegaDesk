using System.ComponentModel.DataAnnotations;

namespace RazorGroupMegaDesk.Models
{
    public class Order
    {
        public int Id { get; set; }

        [Display(Name = "Customer Name")]
        public string? CustomerName { get; set; }

        [Display(Name = "Order Date")]
        [DataType(DataType.Date)]
        public DateTime OrderDate { get; set; }

        public int Width { get; set; }

        public int Depth { get; set; }

        public int Drawers { get; set; }

        [Display(Name = "Surface Material")]
        public string? SurfMaterial { get; set; }

        [Display(Name = "Rush Order")]
        public int RushOrder { get; set; }
    }
}
