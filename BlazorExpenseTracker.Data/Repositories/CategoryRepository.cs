using BlazorExpenseTracker.Model;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorExpenseTracker.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private SqlConfiguration _connectionString;

        public CategoryRepository(SqlConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected SqlConnection dbConnection()
        {
            return new SqlConnection(_connectionString.ConnectionString);
        }

        public Task<bool> DeleteCategory(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            var db = dbConnection();

            var sql = @"SELECT Id, Name
                        FROM Categories ";

            return await db.QueryAsync<Category>(sql, new { });
        }

        public async Task<Category> GetCategoryDetails(int id)
        {
            var db = dbConnection();
            var sql = @"SELECT Id, Name
                        FROM Categories
                        WHERE Id = @Id ";

            return await db.QueryFirstOrDefaultAsync<Category>(sql, new { Id = id });
        }

        public async Task<bool> InsertCategory(Category category)
        {
            var db = dbConnection();
            var sql = @"INSERT INTO Categories (Name)
                        VALUES(@Name) ";

            var result = db.ExecuteAsync(sql, new { category.Name });

            return await result > 0;
        }

        public Task<bool> UpdateCategory(Category category)
        {
            throw new NotImplementedException();
        }
    }
}
