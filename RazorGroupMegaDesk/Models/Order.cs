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

        private const double PriceOak = 200;
        private const double PriceLaminate = 100;
        private const double PriceRosewood = 300;
        private const double PriceVeneer = 125;
        private const double PricePine = 50;

        public string CalculateTotal()
        {

            double exSurfChge = GetSurfaceArea();
            double totalDrawers = Drawers * 50;
            double basePrice = 200;
            double Total = 0;
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
            int extraSurfCharge = 0;

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
            double rushCost = 0;
            int totalSurfaceArea = Width * Depth;

            switch (RushOrder)
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
