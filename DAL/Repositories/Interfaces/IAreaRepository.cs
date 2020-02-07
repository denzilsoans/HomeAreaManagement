using DataAccess.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Repositories.Interfaces
{
    public interface IAreaRepository : IRepository<Area>
    {
        IEnumerable<Area> GetAllAreas();
        Area GetAreaById(int Id);
        void UpdateArea(Area area);
        void RemoveAreaById(int Id);
    }
}