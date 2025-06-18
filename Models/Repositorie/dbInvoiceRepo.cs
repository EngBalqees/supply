using Microsoft.EntityFrameworkCore;
namespace supply.Models.Repositorie
{
    public class dbInvoiceRepo : IRepositorie<Invoice>
    {
        public AppDBContext db { get; }

        public dbInvoiceRepo(AppDBContext _db) { 
        db = _db;
        }
        public void Add(Invoice entity) { 
        db.Invoice.Add(entity);
            db.SaveChanges();
        }

        public Invoice Find(int Id)
        {
            return db.Invoice.Include(i => i.InvoiceItems)
                               .SingleOrDefault(x => x.InvoiceId == Id);
        }
        public void Delete(int Id, Invoice entity) { 
        var data = Find(Id);
            db.Invoice.Remove(data);
            db.SaveChanges();
        }

        public void Update(int Id,Invoice entity) { 
            db.Invoice.Update(entity);
            db.SaveChanges();
        }
        public IList<Invoice> View()
        {
            return db.Invoice.ToList();
        }

        public Invoice GetDetails(int? Id)
        {
            return db.Invoice.Include(x => x.InvoiceItems)
                .FirstOrDefault(i => i.InvoiceId == Id);
        }
    }
}
