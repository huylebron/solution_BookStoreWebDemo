using BanSach.DataAccess.Data;
using BanSach.DataAccess.Repository.IRepository;
using BanSach.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanSach.DataAccess.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext _db;

        public ProductRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
            //_db.Products.Include(u => u.Category).Include(u=>u.CoverType);
        }

       

        public void Update(Product product)
        {
            var objFromDb = _db.Products.SingleOrDefault(a => a.Id == product.Id);
            if (objFromDb!=null)
            {
                objFromDb.Title = product.Title;
                objFromDb.ISBN = product.ISBN;
                objFromDb.ListPrice=product.ListPrice;
                objFromDb.Price50 = product.Price50;
                objFromDb.Price100 = product.Price100;
                objFromDb.Description = product.Description;
                objFromDb.CategoryId = product.CategoryId;
                objFromDb.Author = product.Author;
                objFromDb.CoverTypeId = product.CoverTypeId;
                if (product.ImageUrl!=null)
                {
                    objFromDb.ImageUrl = product.ImageUrl;
                }

            }
            _db.Products.Update(objFromDb);
        }
    }
}
