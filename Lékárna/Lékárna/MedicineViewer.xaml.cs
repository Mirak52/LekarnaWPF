using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Lékárna
{
    /// <summary>
    /// Interaction logic for MedicineViewer.xaml
    /// </summary>
 
    public partial class MedicineViewer : Window
    {
        public int ID = 0;
        public MedicineViewer(int id)
        {
            InitializeComponent();
            ID = id;
            View();
        }

        private void View()
        {
            List<int> list = new List<int>();
            List<string> okDrugs = new List<string>();
            var HaveAllergy = App.DatabaseCostumerAllergen.QueryCustomExist(ID).Result;
            foreach(var CostumerAllergy in HaveAllergy)
            {
                list.Add(CostumerAllergy.Id_Allergen);
            }
            bool found = true;
            var Drugs = App.DatabaseDrug.GetItemsNotDoneAsync().Result; 
            foreach (var drug in Drugs)
            { 
                var DrugAllergen = App.DatabaseDrugAllergen.QueryCustomExist(drug.ID).Result;
                foreach (var Allergie in DrugAllergen)
                {
                    if (list.Contains(Allergie.Id_Allergen))
                    {
                        found = false;
                    }
                }
                if (found)
                {
                    okDrugs.Add(drug.Name);
                }
                found = true;
            }
            Medicine.ItemsSource = okDrugs;
        }

      

        private void Settings_Click_1(object sender, RoutedEventArgs e)
        {
            Settings page = new Settings(ID);
            page.Show();
            this.Close();
        }
    }
}
