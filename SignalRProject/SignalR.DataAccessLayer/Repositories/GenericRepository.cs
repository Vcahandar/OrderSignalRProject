using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;


namespace SignalR.DataAccessLayer.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        readonly SignalRContext _context;
        public GenericRepository(SignalRContext context)
        {
            _context=context;
        }
        public void Add(T entity)
        {

            _context.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(T entity)
        {
           _context.Remove(entity);
            _context.SaveChanges();
        }

        public List<T> GetListAll()
        {
            return _context.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Update(T entity)
        {
            _context.Update(entity);
            _context.SaveChanges();
        }
    }
}
