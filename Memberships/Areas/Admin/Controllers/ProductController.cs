using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Memberships.Entities;
using Memberships.Models;
using Memberships.Areas.Admin.Extensions;
using Memberships.Areas.Admin.Models;

namespace Memberships.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        private ApplicationDbContext _dbContext = new ApplicationDbContext();

        // GET: Admin/Product
        public async Task<ActionResult> Index()
        {
            var products = await _dbContext.Products.ToListAsync();
            var model = await products.Convert(_dbContext);

            return View(model);
        }

        // GET: Admin/Product/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = await _dbContext.Products.FindAsync(id);
            if (product == null)
            {
                return HttpNotFound();
            }

            var model = await product.Convert(_dbContext);
            return View(model);
        }

        // GET: Admin/Product/Create
        public async Task<ActionResult> Create()
        {
            var model = new ProductModel
            {
                ProductLinkTexts = await _dbContext.ProductLinkTexts.ToListAsync(),
                ProductTypes = await _dbContext.ProductTypes.ToListAsync(),
            };
            return View(model);
        }

        // POST: Admin/Product/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Title,Description,ImageUrl,ProductLinkTextId,ProductTypeId")] Product product)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Products.Add(product);
                await _dbContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(product);
        }

        // GET: Admin/Product/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = await _dbContext.Products.FindAsync(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            var prod = new List<Product>();
            prod.Add(product);
            var ProductModel = await prod.Convert(_dbContext);
            return View(ProductModel.First());
        }

        // POST: Admin/Product/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Title,Description,ImageUrl,ProductLinkTextId,ProductTypeId")] Product product)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Entry(product).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET: Admin/Product/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = await _dbContext.Products.FindAsync(id);
            if (product == null)
            {
                return HttpNotFound();
            }

            var model = await product.Convert(_dbContext);
            return View(model);
        }

        // POST: Admin/Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Product product = await _dbContext.Products.FindAsync(id);
            _dbContext.Products.Remove(product);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _dbContext.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
