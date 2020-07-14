using System;
using System.Collections.Generic;
using System.Text;

namespace Uplift.DataAccess.Data.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IDepartmentRepository Department { get; }
        IUserRepository Resource { get; }
        void Save();
    }
}
