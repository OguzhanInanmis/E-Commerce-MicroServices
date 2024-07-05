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
    public class CargoDetailManager : ICargoDetailService
    {
        private readonly ICargoDetailDal cargoDetailDal;

        public CargoDetailManager(ICargoDetailDal cargoDetailDal)
        {
            this.cargoDetailDal = cargoDetailDal;
        }
        public void TDelete(int id)
        {
            cargoDetailDal.Delete(id);
        }

        public List<CargoDetail> TGetAll() => cargoDetailDal.GetAll();

        public CargoDetail TGetById(int id) => cargoDetailDal.GetById(id);

        public void TInsert(CargoDetail entity) => cargoDetailDal.Insert(entity);

        public void TUpdate(CargoDetail entity) => cargoDetailDal.Update(entity);
    }
}
