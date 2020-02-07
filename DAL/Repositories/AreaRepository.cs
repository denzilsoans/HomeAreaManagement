using DataAccess.DataModels;
using System.Collections.Generic;
using DataAccess.Domain;
using DataAccess.Repositories.Interfaces;

namespace DataAccess.Repositories
{
    public class AreaRepository : Repository<Area>, IAreaRepository
    {
        public AreaRepository(ApplicationDbContext context) : base(context)
        { }

        public IEnumerable<Area> GetAllAreas()
        {
            return GetAll();
        }

        public Area GetAreaById(int Id)
        {
            return Get(Id);
        }

        public void RemoveAreaById(int Id)
        {
            Area area = Get(Id);
            Remove(area);
        }

        public void UpdateArea(Area area)
        {
            Update(area);
        }
    }
}
