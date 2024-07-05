using E_Commerce.Cargo.DataAccess.Abstract;
using E_Commerce.Cargo.DataAccess.Concrete;

namespace E_Commerce.Cargo.DataAccess.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        private readonly CargoContext cargoContext;

        public GenericRepository(CargoContext cargoContext)
        {
            this.cargoContext = cargoContext;
        }
        public void Delete(int id)
        {
            T? value = cargoContext.Set<T>().Find(id);
            cargoContext.Set<T>().Remove(value);
            cargoContext.SaveChanges();
        }

        public List<T> GetAll()
        {
            List<T> values = cargoContext.Set<T>().ToList();
            return values;
        }

        public T GetById(int id)
        {
            T? value = cargoContext.Set<T>().Find(id);
            return value;
        }

        public void Insert(T entity)
        {
            cargoContext.Set<T>().Add(entity);
            cargoContext.SaveChanges();
        }

        public void Update(T entity)
        {
            cargoContext.Set<T>().Update(entity);
            cargoContext.SaveChanges();
        }
    }
}
