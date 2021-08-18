using BudgetManagerNew.DLL.Interfaces;
using BudgetManagerNew.Models;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetManagerNew.DLL.Implementations
{
    public class CodeRepository : ICodeRepository
    {
        private readonly IConfiguration configuration;
        public CodeRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public async Task<int> AddAsync(Code code)
        {
            using (IDbConnection cnn = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                int rowsAffected;
                var p = new DynamicParameters();
                p.Add("@CodeName", code.CodeName);
                p.Add("@CodeNumber", code.CodeNumber);
                p.Add("@SerialNo", code.SerialNo);
                p.Add("@DateCreated", DateTime.Now);
                p.Add("@Creator", code.Creator);
                string sql = "dbo.spCode_AddNew";
                rowsAffected = await cnn.ExecuteAsync(sql, p, commandType: CommandType.StoredProcedure);
                       
                return rowsAffected;
            }
        }

        public Task<int> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Code>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<Code>> GetByFilterAsync(int page, int itemsPerPage, string search, string sortBy, bool reverse)
        {
            using (IDbConnection cnn = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                var p = new DynamicParameters();
                p.Add("@page", page);
                p.Add("@search", search);
                p.Add("@sortBy", sortBy);
                p.Add("@itemsPerPage", itemsPerPage);
                p.Add("@sortOrder", reverse ? "DESC" : "ASC");
                string sql = "dbo.spCode_GetAll";
                var codes = await cnn.QueryAsync<Code>(sql, p, commandType: CommandType.StoredProcedure);
                return codes.ToList();
            }
        }

        public Task<Code> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<int> UpdateAsync(Code code)
        {
            using (IDbConnection cnn = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                int rowsAffected;
                var p = new DynamicParameters();
                p.Add("@CodeName", code.CodeName);
                p.Add("@CodeNumber", code.CodeNumber);
                p.Add("@SerialNo", code.SerialNo);
                p.Add("@CodeId", code.CodeId);
                p.Add("@DateModified", DateTime.Now);
                p.Add("@Modifier", code.Creator);
                string sql = "dbo.spCode_Update";
                rowsAffected = await cnn.ExecuteAsync(sql, p, commandType: CommandType.StoredProcedure);                
                return rowsAffected;
            }
        }
    }
}
