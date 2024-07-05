using E_Commerce.Cargo.Business.Abstract;
using E_Commerce.Cargo.DataAccess.Abstract;
using E_Commerce.Cargo.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Cargo.Business.Concrete
{
    public class CargoCustomerManager : ICargoCustomerService
    {
        private readonly ICargoCustomerDal cargoCustomerDal;

        public CargoCustomerManager(ICargoCustomerDal cargoCustomerDal)
        {
            this.cargoCustomerDal = cargoCustomerDal;
        }
        public void TDelete(int id)
        {
            cargoCustomerDal.Delete(id);
        }

        public List<CargoCustomer> TGetAll() => cargoCustomerDal.GetAll();

        public CargoCustomer TGetById(int id) => cargoCustomerDal.GetById(id);

        public void TInsert(CargoCustomer entity) => cargoCustomerDal.Insert(entity);

        public void TUpdate(CargoCustomer entity) => cargoCustomerDal.Update(entity);
    }
}
