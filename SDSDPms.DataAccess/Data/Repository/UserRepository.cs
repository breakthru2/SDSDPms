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
    public class UserRepository : Repository<Resource>, IUserRepository
    {
        private readonly ApplicationDbContext _db;

        public UserRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<SelectListItem> GetResourceListForDropDown()
        {
            return _db.Resource.Select(i => new SelectListItem()
            {
                Text = i.Name,
                Value = i.Id.ToString()
            });
        }

        public void Lockuser(string userId)
        {
            var userFromDb = _db.Resource.FirstOrDefault(u => u.Id == userId);
            userFromDb.LockoutEnd = DateTime.Now.AddYears(1000);
            _db.SaveChanges();
        }

        public void UnLockuser(string userId)
        {
            var userFromDb = _db.Resource.FirstOrDefault(u => u.Id == userId);
            userFromDb.LockoutEnd = DateTime.Now;
            _db.SaveChanges();
        }
    }
}
