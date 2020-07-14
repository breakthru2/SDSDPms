using Microsoft.AspNetCore.Mvc.Rendering;
using SDSDPms.DataAccess.Data;
using SDSDPms.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Uplift.DataAccess.Data.Repository.IRepository;

namespace Uplift.DataAccess.Data.Repository
{
    public class DepartmentRepository : Repository<Department>, IDepartmentRepository
    {
        private readonly ApplicationDbContext _db;

        public DepartmentRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<SelectListItem> GetCategoryListForDropDown()
        {
            return _db.Department.Select(i => new SelectListItem()
            {
                Text = i.Name,
                Value = i.Id.ToString()
            });
        }

        public void Update(Department category)
        {
            var objFromDb = _db.Department.FirstOrDefault(s => s.Id == category.Id);

            objFromDb.Name = category.Name;

            _db.SaveChanges();
        }
    }
}
