using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
namespace Lékárna.Databaze
{
    public class DrugAllergenDatabase
    {
        public SQLiteAsyncConnection database;

        public DrugAllergenDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<DrugAllergen>().Wait();
        }
        public Task<List<DrugAllergen>> QueryCustom(string i, int ID)
        {
            return database.QueryAsync<DrugAllergen>("DELETE FROM [DrugAllergen] where Name = '" + i + "' AND Id_Allergen =  '" + ID + "'");
        }

        public Task<List<DrugAllergen>> QueryCustomExist(int i)
        {
            return database.QueryAsync<DrugAllergen>("select * FROM [DrugAllergen] where Id_drug ='" + i + "'");
        }

        public Task<List<DrugAllergen>> Add()
        {
            return database.QueryAsync<DrugAllergen>("INSERT INTO [DrugAllergen] (Name,Text) VALUES (`Ahoj`,`Pepa`)");
        }
        // Query
        public Task<List<DrugAllergen>> GetItemsAsync()
        {
            return database.Table<DrugAllergen>().ToListAsync();
        }

        // Query using SQL query string
        public Task<List<DrugAllergen>> GetItemsNotDoneAsync()
        {
            return database.QueryAsync<DrugAllergen>("SELECT * FROM [DrugAllergen] WHERE [Done] = 0");
        }

        // Query using LINQ
        public Task<DrugAllergen> GetItemAsync(int id)
        {
            return database.Table<DrugAllergen>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(DrugAllergen item)
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
