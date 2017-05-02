using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Lékárna.Databaze;
using System.IO;
namespace Lékárna
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static CustomersDatabase _customers;

        public static CustomersDatabase DatabaseCustomers
        {
            get
            {
                if (_customers == null)
                {
                    var fileHelper = new FileHelper();
                    _customers = new CustomersDatabase(fileHelper.GetLocalFilePath("TodoSQLite.db3"));
                }
                return _customers;
            }
        }
        public static AllergenDatabase _allergen;

        public static AllergenDatabase DatabaseAllergen
        {
            get
            {
                if (_allergen == null)
                {
                    var fileHelper = new FileHelper();
                    _allergen = new AllergenDatabase(fileHelper.GetLocalFilePath("TodoSQLite.db3"));
                }
                return _allergen;
            }
        }
        public static CostumerAllergenDatabase _CostumerAllergen;

        public static CostumerAllergenDatabase DatabaseCostumerAllergen
        {
            get
            {
                if (_CostumerAllergen == null)
                {
                    var fileHelper = new FileHelper();
                    _CostumerAllergen = new CostumerAllergenDatabase(fileHelper.GetLocalFilePath("TodoSQLite.db3"));
                }
                return _CostumerAllergen;
            }
        }
        public static DrugDatabase _Drug;

        public static DrugDatabase DatabaseDrug
        {
            get
            {
                if (_Drug == null)
                {
                    var fileHelper = new FileHelper();
                    _Drug = new DrugDatabase(fileHelper.GetLocalFilePath("TodoSQLite.db3"));
                }
                return _Drug;
            }
        }
        public static DrugAllergenDatabase _DrugAllergen;

        public static DrugAllergenDatabase DatabaseDrugAllergen
        {
            get
            {
                if (_DrugAllergen == null)
                {
                    var fileHelper = new FileHelper();
                    _DrugAllergen = new DrugAllergenDatabase(fileHelper.GetLocalFilePath("TodoSQLite.db3"));
                }
                return _DrugAllergen;
            }
        }
        internal static string GetStringSha256Hash(string text)
        {
            if (String.IsNullOrEmpty(text))
                return String.Empty;

            using (var sha = new System.Security.Cryptography.SHA256Managed())
            {
                byte[] textData = System.Text.Encoding.UTF8.GetBytes(text);
                byte[] hash = sha.ComputeHash(textData);
                return BitConverter.ToString(hash).Replace("-", String.Empty);
            }
        }

    }

}
