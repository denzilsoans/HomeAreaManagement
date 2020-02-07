using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.DataModels;
using HomeAreaManagement.ViewModels;

namespace HomeAreaManagement.Extensions
{
    public static class Extensions
    {
        public static Area ConvertToAreaModel(this AreaViewModel area)
        {
            return new Area()
            {
                Id = area.Id,
                Name = area.Name,
                CreatedOn = Convert.ToDateTime(area.CreatedOn),
                CreatedById = Convert.ToInt32(area.CreatedById),
                UpdatedOn = Convert.ToDateTime(area.UpdatedOn),
                UpdatedById = string.IsNullOrEmpty(area.UpdatedById) ? (int?)null : Convert.ToInt32(area.UpdatedById)
            };
        }

        public static AreaViewModel ConvertToAreaViewModel(this Area area)
        {
            return new AreaViewModel()
            {
                Id = area.Id,
                Name = area.Name,
                CreatedOn = Convert.ToString(area.CreatedOn),
                CreatedById = Convert.ToString(area.CreatedById),
                UpdatedOn = Convert.ToString(area.UpdatedOn),
                UpdatedById = area.UpdatedById.HasValue ? area.UpdatedById.ToString() : "",
                CreatedBy = "Admin",
                UpdatedBy = area.UpdatedById.HasValue ? "Admin" : ""
            };
        }
    }
}
