using E_Commerce.Cargo.Business.Abstract;
using E_Commerce.Cargo.DataAccess.Abstract;
using E_Commerce.Cargo.Entity.Concrete;

namespace E_Commerce.Cargo.Business.Concrete
{
    public class CargoOperationManager : ICargoOperationService
    {
        private readonly ICargoOperationDal cargoOperationDal;

        public CargoOperationManager(ICargoOperationDal cargoOperationDal)
        {
            this.cargoOperationDal = cargoOperationDal;
        }
        public void TDelete(int id)
        {
            cargoOperationDal.Delete(id);
        }

        public List<CargoOperation> TGetAll() => cargoOperationDal.GetAll();

        public CargoOperation TGetById(int id) => cargoOperationDal.GetById(id);

        public void TInsert(CargoOperation entity) => cargoOperationDal.Insert(entity);

        public void TUpdate(CargoOperation entity) => cargoOperationDal.Update(entity);
    }
}
