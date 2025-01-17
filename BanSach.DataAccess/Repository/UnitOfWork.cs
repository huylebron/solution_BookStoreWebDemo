﻿using BanSach.DataAccess.Data;
using BanSach.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanSach.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public ICategoryRepository Category { get; private set; }

        public ICoverTypeRepository covertype { get; private set; }

        public IProductRepository Product { get; private set; }

        public ICompanyRepository Company { get; private set; }
        public IApplicationUserRepository ApplicationUser { get; private set; }
        public IShoppingCartRepository ShoppingCart { get; private set; }
        public IOrderHeaderRepository OrderHeader { get; private set; }
        public IOrderDetailRepository OrderDetail { get; private set; }


        private readonly ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db) 
        {
            _db = db;
            Category = new CategoryRepository(_db);
            covertype = new CoverTypeRepository(_db);          
            Product = new ProductRepository(_db);
            Company=new CompanypeRepository(_db);
            ApplicationUser=new ApplicationUserRepository(_db);
            ShoppingCart=new ShoppingCartRepository(_db);
            OrderHeader=new OrderHeaderRepository(_db);
            OrderDetail=new OrderDetailRepository(_db);


        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
