using HRMS.DLL.Interfaces;
using HRMS.MODEL.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.DLL.Implementations
{
    public class UserRepo : IUserRepo
    {
        private readonly IConfiguration configuration;
        public UserRepo(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public Task<int> AddAsync(User entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<User>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<User>> GetByFilterAsync(int page, int itemsPerPage, string search, string sortBy, bool reverse)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
