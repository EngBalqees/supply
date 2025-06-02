using Microsoft.EntityFrameworkCore.Infrastructure.Internal;

namespace supply.Models.Repositorie
{
    public class dbSupplierRepos : IRepositorie<Supplier>
    {
        public AppDBContext db { get; }

        public dbSupplierRepos(AppDBContext _db) { 
            db = _db;
        }

        public void Add(Supplier entity)
        {
            db.Supplier.Add(entity);
            db.SaveChanges();
        }
        public void Delete(int Id,Supplier entity)
        { 
            var data = Find (Id);
            db.Supplier.Remove(data);
            db.SaveChanges();
        }

        public Supplier Find(int Id) {
            return db.Supplier.SingleOrDefault(x => x.SupplierId == Id);
        }

        public void Update(int Id, Supplier entity) { 
            db.Supplier.Update(entity);
            db.SaveChanges();
        }
        public IList<Supplier> View()
        {
            return db.Supplier.ToList();
        }

    }
}
