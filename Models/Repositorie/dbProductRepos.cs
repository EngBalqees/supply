﻿
using Microsoft.EntityFrameworkCore;

namespace supply.Models.Repositorie
{
    public class dbProductRepos : IRepositorie<Product>
    {
        public AppDBContext db { get; }

        public dbProductRepos(AppDBContext _db)
        {
            db = _db;
        }
        public void Add(Product entity)
        {
            db.Product.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int Id, Product entity)
        {
            var data = Find(Id);
            db.Product.Remove(data);
            db.SaveChanges();
        }

        public Product Find(int Id)
        {
            return db.Product.SingleOrDefault(x => x.ProductId == Id);
        }

        public void Update(int Id, Product entity)
        {
            db.Product.Update(entity);
            db.SaveChanges();
        }

        public IList<Product> View()
        {
            return db.Product
              .Include(x => x.Supplier)
              .Include(x => x.Category)
              .ToList();
        }
    }
}
