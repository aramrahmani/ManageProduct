using Sample.Model;
using System.Collections.Generic;

namespace Sample.Service
{
    public interface IUnitService
    {
        IEnumerable<Unit> GetUnits();
        Unit GetUnit(long unitId);
        Unit GetUnitByName(string unitName);

        void CreateUnit(Unit unit);
        void UpdateUnit(Unit unit);
        void DeleteUnit(Unit unit);
        void DeleteUnit(long unitId);
        void SaveUnit();
    }
}
