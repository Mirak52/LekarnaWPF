using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
namespace Lékárna
{
   public class CustomersDatabase
    {
        // SQLite connection
        public SQLiteAsyncConnection database;

        public CustomersDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Customers>().Wait();
        }
        public Task<List<Customers>> QueryCustom()
        {
            return database.QueryAsync<Customers>("DELETE FROM [Osoby]");
        }
      
        public Task<List<Customers>> QueryCustomExist()
        {
            return database.QueryAsync<Customers>("select * FROM [Customers] ");
        }
       
        public Task<List<Customers>> Add()
        {
            return database.QueryAsync<Customers>("INSERT INTO [Customers] (Name,Text) VALUES (`Ahoj`,`Pepa`)");
        }
        // Query
        public Task<List<Customers>> GetItemsAsync()
        {
            return database.Table<Customers>().ToListAsync();
        }

        // Query using SQL query string
        public Task<List<Customers>> GetItemsNotDoneAsync()
        {
            return database.QueryAsync<Customers>("SELECT * FROM [Customers] WHERE [Done] = 0");
        }

        // Query using LINQ
        public Task<Customers> GetItemAsync(int id)
        {
            return database.Table<Customers>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(Customers item)
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
