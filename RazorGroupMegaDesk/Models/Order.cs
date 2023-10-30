using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorGroupMegaDesk.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string? CustomerName { get; set; }

        [Display(Name = "Order Date")]
        [DataType(DataType.Date)]
        public DateTime OrderDate { get; set; }
        public int Width { get; set; }
        public int Depth { get; set; }
        public int Drawers { get; set; }
        public string? SurfMaterial { get; set; }
        public int RushOrder { get; set; }
    }
}
