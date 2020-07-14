using Microsoft.AspNetCore.Mvc.Rendering;
using SDSDPms.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Uplift.DataAccess.Data.Repository.IRepository
{
    public interface IDepartmentRepository : IRepository<Department>
    {
        IEnumerable<SelectListItem> GetCategoryListForDropDown();

        void Update(Department department);
    }
}
