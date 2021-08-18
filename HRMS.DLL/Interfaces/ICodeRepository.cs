using BudgetManagerNew.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetManagerNew.DLL.Interfaces
{
    public interface ICodeRepository: IGenericRepository<Code>
    {
        Task<IReadOnlyList<Code>> GetByFilterAsync(int page, int itemsPerPage, string search, string sortBy, bool reverse);
    }
}
