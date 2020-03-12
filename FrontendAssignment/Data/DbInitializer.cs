using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using FrontendAssignment.Data.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FrontendAssignment.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ProductContext context)
        {
            context.Database.Migrate();
            if (!context.Products.Any())
            {
                SeedDefaultData(context);
            }
        }

        private static void SeedDefaultData(ProductContext context)
        {
            string jsonFile;
            var dir = Path.Combine(Directory.GetCurrentDirectory(), "data", "products.json");
            using (var r = new StreamReader(dir))
            {
                jsonFile = r.ReadToEnd();
            }

            IEnumerable<ProductJson> products = JsonSerializer.Deserialize<List<ProductJson>>(jsonFile);

            var dbData = products.Select(p =>
                new Product
                {
                    Name = p.Name,
                    FromPrice = p.FromPrice,
                    Image = p.Image,
                    Description = p.Description,
                    TimesViewed = 0,
                    UrlSegment = CreateUrlSegment(p.Name)
                });
            context.Products.AddRange(dbData);
            context.SaveChanges();
        }

        private static string CreateUrlSegment(string name)
        {
            return name.Trim()
                .ToLower()
                .Replace(" ", "_")
                .Replace("å", "a")
                .Replace("ä", "a")
                .Replace("ö", "o");
        }
    }
}