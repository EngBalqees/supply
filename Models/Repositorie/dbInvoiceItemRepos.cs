
using Microsoft.EntityFrameworkCore;

namespace supply.Models.Repositorie
{
    public class dbInvoiceItemRepos : IRepositorie<InvoiceItem>
    {
        public AppDBContext db { get; }

        public dbInvoiceItemRepos(AppDBContext _db)
        {
            db = _db;
        }
        public void Add(InvoiceItem entity)
        {
            db.InvoiceItem.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int Id, InvoiceItem entity)
        {
            var data = Find(Id);
            db.InvoiceItem.Remove(data);
            db.SaveChanges();
        }

        public InvoiceItem Find(int Id)
        {
            return db.InvoiceItem.Include(p => p.Product).SingleOrDefault(x => x.InvoiceItemId == Id);
        }

        public void Update(int Id, InvoiceItem entity)
        {
            db.InvoiceItem.Update(entity);
            db.SaveChanges();
        }

        public IList<InvoiceItem> View()
        {
            return db.InvoiceItem
               .Include(x => x.Product)
               .ToList();
        }
        public InvoiceItem GetDetails(int? id)
        {
            return db.InvoiceItem.Include(i => i.Product)
                .ThenInclude(p => p.Category).Include(i => i.Product)
                .ThenInclude(p => p.Supplier).FirstOrDefault(i => i.InvoiceItemId == id);
        
        
        }
          

    }
}
