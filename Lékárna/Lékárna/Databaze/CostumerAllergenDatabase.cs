using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
namespace Lékárna.Databaze
{
    public class CostumerAllergenDatabase
    {
        // SQLite connection
        public SQLiteAsyncConnection database;

        public CostumerAllergenDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<CostumerAllergen>().Wait();
        }
        public Task<List<CostumerAllergen>> QueryCustom()
        {
            return database.QueryAsync<CostumerAllergen>("DELETE FROM [CostumerAllergen]");
        }

        public Task<List<CostumerAllergen>> QueryCustomExist(string i)
        {
            return database.QueryAsync<CostumerAllergen>("select * FROM [CostumerAllergen] where Name ='" + i + "'");
        }

        public Task<List<CostumerAllergen>> Add()
        {
            return database.QueryAsync<CostumerAllergen>("INSERT INTO [CostumerAllergen] (Name,Text) VALUES (`Ahoj`,`Pepa`)");
        }
        // Query
        public Task<List<CostumerAllergen>> GetItemsAsync()
        {
            return database.Table<CostumerAllergen>().ToListAsync();
        }

        // Query using SQL query string
        public Task<List<CostumerAllergen>> GetItemsNotDoneAsync()
        {
            return database.QueryAsync<CostumerAllergen>("SELECT * FROM [Customers] WHERE [Done] = 0");
        }

        // Query using LINQ
        public Task<CostumerAllergen> GetItemAsync(int id)
        {
            return database.Table<CostumerAllergen>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(CostumerAllergen item)
        {
            if (item.ID != 0)
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(Customers item)
        {
            return database.DeleteAsync(item);
        }
    }
}
