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
        public string jmeno = "";
        public MedicineViewer(string name)
        {
            InitializeComponent();
            jmeno = name;
            View();
        }

        private void View()
        {
            string check ="";
            int first = 0;
            var Drugs = App.DatabaseDrug.GetItemsNotDoneAsync().Result; 
            foreach (var drug in Drugs)
            {
                if (first == 0)
                {
                    check = drug.Name;
                }
                var Allergy = App.DatabaseCostumerAllergen.QueryCustomExist(jmeno).Result;
                foreach (var Allergie in Drugs)
                {
                    if (check == drug.Name)
                    {
                        
                    }


                }

                first++;
            }
        }
    }
}
