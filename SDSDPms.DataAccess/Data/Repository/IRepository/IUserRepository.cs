using Microsoft.AspNetCore.Mvc.Rendering;
using SDSDPms.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Uplift.DataAccess.Data.Repository.IRepository
{
    public interface IUserRepository : IRepository<Resource>
    {
        void Lockuser(string userId);
        void UnLockuser(string userId);


    }
}
