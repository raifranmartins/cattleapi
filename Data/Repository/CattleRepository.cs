using Data.Context;
using Data.Models;
using Data.Paging;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class CattleRepository : RepositoryBase<cattle>
    {
        public CattleRepository(ApplicationDBContext applicationDBContext)
            : base(applicationDBContext)
        {
        }

        public void CreateCattle(cattle cattle)
        {
            Create(cattle);
        }

        public void DeleteCattle(cattle cattle)
        {
            Delete(cattle);
        }

        public cattle GetCattle(string id)
        {
            return FindByCondition(u => u.id == id).FirstOrDefault();
        }

        public Task<PagedList<cattle>> GetCattles(PagingParameters pagingParameters)
        {
            return Task.FromResult(PagedList<cattle>.GetPagedList(FindAll().Include(u => u.user).OrderBy(u => u.nome), pagingParameters.PageNumber, pagingParameters.PageSize));
        }

        public void UpdateCattle(cattle cattle)
        {
            Update(cattle);
        }


    }
}
