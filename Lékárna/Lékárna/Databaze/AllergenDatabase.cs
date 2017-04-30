using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
namespace Lékárna.Databaze
{
    public class AllergenDatabase
    {
        public SQLiteAsyncConnection database;

        public AllergenDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Allergen>().Wait();
        }
        public Task<List<Allergen>> QueryCustomExist(string name)
        {
            return database.QueryAsync<Allergen>("select ID FROM [Allergen] where Name ='" + name +"'");
        }
        public Task<List<Allergen>> QueryCustom()
        {
            return database.QueryAsync<Allergen>("select * FROM [Allergen]");
        }
        public Task<List<Allergen>> Add()
        {
            return database.QueryAsync<Allergen>("INSERT INTO [Allergen] (Name,Text) VALUES (`Ahoj`,`Pepa`)");
        }
        // Query
        public Task<List<Allergen>> GetItemsAsync()
        {
            return database.Table<Allergen>().ToListAsync();
        }

        // Query using SQL query string
        public Task<List<Allergen>> GetItemsNotDoneAsync()
        {
            return database.QueryAsync<Allergen>("SELECT * FROM [Allergen] WHERE [Done] = 0");
        }

        // Query using LINQ
        public Task<Allergen> GetItemAsync(int id)
        {
            return database.Table<Allergen>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(Allergen item)
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
