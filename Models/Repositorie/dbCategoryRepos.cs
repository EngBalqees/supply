
namespace supply.Models.Repositorie
{
    public class dbCategoryRepos : IRepositorie<Category>
    {
        public AppDBContext db { get; }

        public dbCategoryRepos(AppDBContext _db)
        {
            db = _db;
        }
        public void Add(Category entity)
        {
            db.Category.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int Id, Category entity)
        {
            var data = Find(Id);
            db.Category.Remove(data);
            db.SaveChanges();
        }

        public Category Find(int Id)
        {
            return db.Category.SingleOrDefault(x => x.CategoryId == Id);
        }

        public void Update(int Id, Category entity)
        {
            db.Category.Update(entity);
            db.SaveChanges();
        }

        public IList<Category> View()
        {
            return db.Category.ToList();
        }
    }
}
