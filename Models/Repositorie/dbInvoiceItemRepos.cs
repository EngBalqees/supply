
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
            return db.InvoiceItem.SingleOrDefault(x => x.InvoiceItemId == Id);
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
    }
}
