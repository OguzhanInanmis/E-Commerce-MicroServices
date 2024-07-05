using E_Commerce.Cargo.Business.Abstract;
using E_Commerce.Cargo.DataAccess.Abstract;
using E_Commerce.Cargo.Entity.Concrete;

namespace E_Commerce.Cargo.Business.Concrete
{
    public class CargoCompanyManager : ICargoCompanyService
    {
        private readonly ICargoCompanyDal cargoCompanyDal;

        public CargoCompanyManager(ICargoCompanyDal cargoCompanyDal)
        {
            this.cargoCompanyDal = cargoCompanyDal;
        }
        public void TDelete(int id)
        {
            cargoCompanyDal.Delete(id);
        }

        public List<CargoCompany> TGetAll() => cargoCompanyDal.GetAll();

        public CargoCompany TGetById(int id) => cargoCompanyDal.GetById(id);

        public void TInsert(CargoCompany entity) => cargoCompanyDal.Insert(entity);

        public void TUpdate(CargoCompany entity) => cargoCompanyDal.Update(entity);
    }
}
