using E_Commerce.Cargo.DataAccess.Abstract;
using E_Commerce.Cargo.DataAccess.Concrete;
using E_Commerce.Cargo.DataAccess.Repositories;
using E_Commerce.Cargo.Entity.Concrete;

namespace E_Commerce.Cargo.DataAccess.EntityFramework
{
    public class EfCargoCustomerDal : GenericRepository<CargoCustomer>, ICargoCustomerDal
    {
        public EfCargoCustomerDal(CargoContext cargoContext) : base(cargoContext)
        {

        }
    }
}
