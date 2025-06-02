
namespace supply.Models.Repositorie
{
    public class dbEmployeeRepos : IRepositorie<Employee>
    {
        public AppDBContext db { get; }

        public dbEmployeeRepos(AppDBContext _db)
        {
            db = _db;
        }
        public void Add(Employee entity)
        {
            db.Employee.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int Id, Employee entity)
        {
            var data = Find(Id);
            db.Employee.Remove(data);
            db.SaveChanges();
        }

        public Employee Find(int Id)
        {
            return db.Employee.SingleOrDefault(x => x.EmployeeId == Id);
        }

        public void Update(int Id, Employee entity)
        {
            db.Employee.Update(entity);
            db.SaveChanges();
        }

        public IList<Employee> View()
        {
            return db.Employee.ToList();
        }
    }
}
