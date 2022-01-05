using Data.Context;
using Data.Models;
using Data.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class UserRepository : RepositoryBase<user>, IUserRepository
    {
        public UserRepository(ApplicationDBContext applicationDBContext) 
            : base(applicationDBContext)
        {
        }

        public void CreateUser(user user)
        {
            Create(user);
        }

        public void DeleteUser(user user)
        {
            Delete(user);
        }

        public user GetUser(string id)
        {
            return FindByCondition(u => u.id == id).FirstOrDefault();
        }

        public Task<PagedList<user>> GetUsers(PagingParameters pagingParameters)
        {
            return Task.FromResult(PagedList<user>.GetPagedList(FindAll().OrderBy(u => u.nome), pagingParameters.PageNumber, pagingParameters.PageSize));
        }

        public void UpdateUser(user user)
        {
            Update(user);
        }
    }
}
