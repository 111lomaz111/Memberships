using Memberships.Areas.Admin.Models;
using Memberships.Entities;
using Memberships.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Memberships.Areas.Admin.Extensions
{
    public static class ConversionExtensions
    {
        public static async Task<IEnumerable<ProductModel>> Convert(this IEnumerable<Product> products, ApplicationDbContext dbContext)
        {
            if (products.Count() == 0)
                return new List<ProductModel>();

            var text = await dbContext.ProductLinkTexts.ToListAsync();
            var types = await dbContext.ProductTypes.ToListAsync();

            return from p in products
                   select new ProductModel
                   {
                       Id = p.Id,
                       Title = p.Title,
                       Description = p.Description,
                       ImageUrl = p.ImageUrl,
                       ProductLinkTextId = p.ProductLinkTextId,
                       ProductLinkTexts = text,
                       ProductTypeId = p.ProductTypeId,
                       ProductTypes = types
                   };
        }

        public static async Task<ProductModel> Convert(this Product product, ApplicationDbContext dbContext)
        {
            var productLinkText = await dbContext.ProductLinkTexts.FirstOrDefaultAsync(p => p.Id == product.ProductLinkTextId);
            var productType = await dbContext.ProductTypes.FirstOrDefaultAsync(p => p.Id == product.ProductTypeId);

            var model = new ProductModel
                   {
                       Id = product.Id,
                       Title = product.Title,
                       Description = product.Description,
                       ImageUrl = product.ImageUrl,
                       ProductLinkTextId = product.ProductLinkTextId,
                       ProductLinkTexts = new List<ProductLinkText>(),
                       ProductTypeId = product.ProductTypeId,
                       ProductTypes = new List<ProductType>()
            };

            model.ProductLinkTexts.Add(productLinkText);
            model.ProductTypes.Add(productType);

            return model;
        }

    }
}