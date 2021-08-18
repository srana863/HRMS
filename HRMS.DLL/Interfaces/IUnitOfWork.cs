using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetManagerNew.DLL.Interfaces
{
    public interface IUnitOfWork
    {
        ICodeRepository Codes { get; }
    }
}
