using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
namespace Lékárna.Databaze
{
  public  class DrugDatabase
    {
        public SQLiteAsyncConnection database;

        public DrugDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Drug>().Wait();
        }
        public Task<List<Drug>> QueryCustom(string i, int ID)
        {
            return database.QueryAsync<Drug>("DELETE FROM [Drug] where Name = '" + i + "' AND Id_Allergen =  '" + ID + "'");
        }

        public Task<List<Drug>> QueryCustomExist(string i)
        {
            return database.QueryAsync<Drug>("select * FROM [Drug] where Name ='" + i + "'");
        }

        public Task<List<Drug>> Add()
        {
            return database.QueryAsync<Drug>("INSERT INTO [Drug] (Name,Text) VALUES (`Ahoj`,`Pepa`)");
        }
        // Query
        public Task<List<Drug>> GetItemsAsync()
        {
            return database.Table<Drug>().ToListAsync();
        }

        // Query using SQL query string
        public Task<List<Drug>> GetItemsNotDoneAsync()
        {
            return database.QueryAsync<Drug>("SELECT * FROM [Drug] WHERE [Done] = 0");
        }

        // Query using LINQ
        public Task<Drug> GetItemAsync(int id)
        {
            return database.Table<Drug>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(Drug item)
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

        public Task<int> DeleteItemAsync(Drug item)
        {
            return database.DeleteAsync(item);
        }
    }
}
