using Sample.Data;
using Sample.Model;
using System.Collections.Generic;

namespace Sample.Service
{
    public class UnitService : IUnitService
    {
        private readonly IUnitRepository unitRepository;
        private readonly IUnitOfWork unitOfWork;

        public UnitService(IUnitRepository unitRepository, IUnitOfWork unitOfWork)
        {
            this.unitRepository = unitRepository;
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<Unit> GetUnits()
        {
            return unitRepository.GetAll();
        }

        public Unit GetUnit(long unitId)
        {
            return unitRepository.GetById(unitId);
        }

        public Unit GetUnitByName(string unitName)
        {
            return unitRepository.GetUnit(unitName);
        }

        public void CreateUnit(Unit unit)
        {
            unitRepository.Add(unit);
        }

        public void DeleteUnit(Unit unit)
        {
            unitRepository.Delete(unit);
        }

        public void DeleteUnit(long unitId)
        {
            var unit = GetUnit(unitId);
            DeleteUnit(unit);
        }

        public void UpdateUnit(Unit unit)
        {
            unitRepository.Update(unit);
        }

        public void SaveUnit()
        {
            unitOfWork.Commit();
        }

      
    }
}
