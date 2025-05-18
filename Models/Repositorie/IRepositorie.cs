namespace supply.Models.Repositorie
{
    public interface IRepositorie<TEntity>
    {
        IList<TEntity> View();
        void Add (TEntity entity);
        void Delete (int Id,TEntity entity);
        void Update (int Id,TEntity entity);

        TEntity Find(int Id);

    }
}