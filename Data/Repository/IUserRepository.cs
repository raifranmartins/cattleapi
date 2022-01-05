using Data.Models;
using Data.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public interface IUserRepository : IRepositoryBase<user>
    {
        Task<PagedList<user>> GetUsers(PagingParameters pagingParameters);
        user GetUser(string id);
        void CreateUser(user user);
        void UpdateUser(user user);
        void DeleteUser(user user);        
    }
}
