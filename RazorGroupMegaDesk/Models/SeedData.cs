using Microsoft.EntityFrameworkCore;
using RazorGroupMegaDesk.Data;


namespace RazorGroupMegaDesk.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new RazorGroupMegaDeskContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<RazorGroupMegaDeskContext>>()))
            {
                if (context == null || context.Order == null)
                {
                    throw new ArgumentNullException("Null RazorGroupMegaDeskContext");
                }

                // Look for any orders.
                if (context.Order.Any())
                {
                    return;   // DB has been seeded
                }

                context.Order.AddRange(
                    new Order
                    {
                        CustomerName = "Jane Jacobs",
                        OrderDate = DateTime.Parse("2023-10-15"),
                        Width = 48,
                        Depth = 24,
                        Drawers = 2,
                        SurfMaterial = "Oak",
                        RushOrder = "3",
                    },

                    new Order
                    {
                        CustomerName = "Sam Campbell",
                        OrderDate = DateTime.Parse("2023-10-20"),
                        Width = 52,
                        Depth = 23,
                        Drawers = 6,
                        SurfMaterial = "Pine",
                        RushOrder = "5",
                    },

                    new Order
                    {
                        CustomerName = "Austin Perry",
                        OrderDate = DateTime.Parse("2023-10-03"),
                        Width = 60,
                        Depth = 20,
                        Drawers = 5,
                        SurfMaterial = "Oak",
                        RushOrder = "3",
                    },

                    new Order
                    {
                        CustomerName = "Sarah Stanley",
                        OrderDate = DateTime.Parse("2023-10-06"),
                        Width = 48,
                        Depth = 24,
                        Drawers = 2,
                        SurfMaterial = "Oak",
                        RushOrder = "3",
                    }
                );
                context.SaveChanges();
            }
        }
    }
}

