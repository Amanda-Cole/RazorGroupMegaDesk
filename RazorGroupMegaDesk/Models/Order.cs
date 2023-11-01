using System.ComponentModel.DataAnnotations;

namespace RazorGroupMegaDesk.Models
{
    public class Order
    {
        public int Id { get; set; }

        [Display(Name = "Customer Name"), Required]
        public string? CustomerName { get; set; }

        [Display(Name = "Order Date")]
        [DataType(DataType.Date)]
        public DateTime OrderDate { get; set; }

        [Range(MIN_WIDTH, MAX_WIDTH, ErrorMessage = $"Width must be between 24 and 96.")]
        public int Width { get; set; }

        [Range(MIN_DEPTH, MAX_DEPTH, ErrorMessage = "Depth must be between 12 and 48.")]
        public int Depth { get; set; }

        [Range(MIN_DRAWER_QTY, MAX_DRAWER_QTY, ErrorMessage = "Drawer quantitiy must be between 0 and 7.")]
        public int Drawers { get; set; }

        [Display(Name = "Surface Material"), Required]
        public string? SurfMaterial { get; set; }

        [Display(Name = "Rush Order"), Required]
        public string RushOrder { get; set; }

        private const double PriceOak = 200;
        private const double PriceLaminate = 100;
        private const double PriceRosewood = 300;
        private const double PriceVeneer = 125;
        private const double PricePine = 50;
        private const int MIN_WIDTH = 24;
        private const int MAX_WIDTH = 96;
        private const int MIN_DEPTH = 12;
        private const int MAX_DEPTH = 48;
        private const int MIN_DRAWER_QTY = 0;
        private const int MAX_DRAWER_QTY = 7;

        public string CalculateTotal()
        {
            double exSurfChge = GetSurfaceArea();
            double totalDrawers = Drawers * 50;
            double basePrice = 200;
            double Total;
            double surfaceCost = 0;
            double rushCost = GetRush();

            if (SurfMaterial == "Oak")
            {
                surfaceCost = PriceOak;
            }
            else if (SurfMaterial == "Laminate")
            {
                surfaceCost = PriceLaminate;
            }
            else if (SurfMaterial == "Pine")
            {
                surfaceCost = PricePine;
            }
            else if (SurfMaterial == "Rosewood")
            {
                surfaceCost = PriceRosewood;
            }
            else if (SurfMaterial == "Veneer")
            {
                surfaceCost = PriceVeneer;
            }

            Total = basePrice + exSurfChge + totalDrawers + surfaceCost + rushCost;
            string formattedTotal = Total.ToString("C");
            return formattedTotal;
        }

        public int GetSurfaceArea()
        {
            int surfaceArea = Width * Depth;
            int extraSurfCharge;

            if (surfaceArea > 1000)
            {
                extraSurfCharge = surfaceArea - 1000;
            }
            else
            {
                extraSurfCharge = 0;
            }
            return extraSurfCharge;
        }

        public double GetRush()
        {
            double rushCost;
            int totalSurfaceArea = Width * Depth;

            switch (int.Parse(RushOrder))
            {
                case 3:
                    //rowIndex = 0;
                    if (totalSurfaceArea < 1000)
                    {
                        rushCost = 60;
                    }

                    else if (totalSurfaceArea > 1000 && totalSurfaceArea < 2000)
                    {
                        rushCost = 70;
                    }
                    else
                    {
                        rushCost = 80;
                    }
                    return rushCost;

                case 5:
                    //rowIndex = 1;
                    if (totalSurfaceArea < 1000)
                    {
                        rushCost = 40;
                    }

                    else if (totalSurfaceArea > 1000 && totalSurfaceArea < 2000)
                    {
                        rushCost = 50;
                    }
                    else
                    {
                        rushCost = 60;
                    }
                    return rushCost;

                case 7:
                    //rowIndex = 2;
                    if (totalSurfaceArea < 1000)
                    {
                        rushCost = 30;
                    }

                    else if (totalSurfaceArea > 1000 && totalSurfaceArea < 2000)
                    {
                        rushCost = 35;
                    }
                    else
                    {
                        rushCost = 40;
                    }
                    return rushCost;
                default:
                    return 0;
            }
        }
    }
}
