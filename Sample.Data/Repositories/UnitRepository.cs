using Sample.Data;
using Sample.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Data
{
    public class UnitRepository : RepositoryBase<Unit>, IUnitRepository
    {
        public UnitRepository(IDbFactory dbFactory)
            : base(dbFactory) { }

        public Unit GetUnit(string name)
        {
            return DbContext.Units.Where(u => u.UnitName == name).FirstOrDefault();
        }
    }

    public interface IUnitRepository : IRepository<Unit>
    {
        Unit GetUnit(string name);
    }
}
