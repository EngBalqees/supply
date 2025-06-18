
using Microsoft.EntityFrameworkCore;

namespace supply.Models.Repositorie
{
    public class dbSaleRepos : IRepositorie<Sale>
    {
        public AppDBContext db { get; }

        public dbSaleRepos(AppDBContext _db)
        {
            db = _db;
        }
        public void Add(Sale entity)
        {
            db.Sale.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int Id, Sale entity)
        {
            var data = Find(Id);
            if (data != null)
            {
                db.Sale.Remove(data);
                db.SaveChanges();
            }
        }

        public Sale Find(int Id)
        {
            return db.Sale.SingleOrDefault(x => x.SaleId == Id);
        }

        public void Update(int Id, Sale entity)
        {
            db.Sale.Update(entity);
            db.SaveChanges();
        }

        public IList<Sale> View()
        {
            return db.Sale
                         .Include(x => x.Employee)
                         .Include(x => x.Customer)
                         .Include(x => x.Invoice)
                         .ToList();
        }

        public Sale GetDetails(int? id)
        {
            return db.Sale.Include(i => i.Customer)
                .Include(i => i.Employee)
                .Include(i => i.Invoice).FirstOrDefault(i => i.SaleId == id);
        }
    }
}
