
namespace supply.Models.Repositorie
{
    public class dbCustomerRepos : IRepositorie<Customer>
    {
        public AppDBContext db { get; }

        public dbCustomerRepos(AppDBContext _db)
        {
            db = _db;
        }
        public void Add(Customer entity)
        {
            db.Customer.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int Id, Customer entity)
        {
            var data = Find(Id);
            db.Customer.Remove(data);
            db.SaveChanges();
        }

        public Customer Find(int Id)
        {
            return db.Customer.SingleOrDefault(x => x.CustomerId == Id);
        }

        public void Update(int Id, Customer entity)
        {
            db.Customer.Update(entity);
            db.SaveChanges();
        }

        public IList<Customer> View()
        {
            return db.Customer.ToList();
        }
    }
}
