using BudgetManagerNew.DLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetManagerNew.DLL.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(ICodeRepository codeRepository)
        {
            Codes = codeRepository;
        }
        public ICodeRepository Codes { get; }
    }
}
