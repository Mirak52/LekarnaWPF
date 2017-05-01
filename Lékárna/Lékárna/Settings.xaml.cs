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
using Lékárna.Databaze;

namespace Lékárna
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {

        public string jmeno;
        public List<string> list = new List<string>();
        public List<string> list1 = new List<string>();
        public Settings(int ID)
        {

            InitializeComponent();
          
            /*List<int> list = new List<int>();
            list.Add(2);
            list.Add(3);
            list.Add(5);
            list.Add(7);
            Allergen.ItemsSource = list;
            CostumerAllergen alergen = new CostumerAllergen();
            alergen.Name = name;
            alergen.Id_Allergen = 1;
            App.DatabaseCostumerAllergen.SaveItemAsync(alergen);*/
            View();
            jmeno = "marek";
        }

        private void View()
        {
            jmeno = "marek";
            var HaveAllergy = App.DatabaseCostumerAllergen.QueryCustomExist(jmeno).Result;//první smyčka
            var Allergy = App.DatabaseAllergen.QueryCustom().Result;//druhá smyčka
            foreach (var listHaveAllergy in HaveAllergy)
            {
                foreach (var listAllergy in Allergy)
                {
                    if (listHaveAllergy.Id_Allergen == listAllergy.ID)
                    {
                        list.Add(listAllergy.Name);
                    } 
                }
            }
            foreach (var listAllergy in Allergy)
            {
                if (!list.Contains(listAllergy.Name))
                {
                    list1.Add(listAllergy.Name);
                }
            }
            AllergenL.ItemsSource = list1;
            HaveAllergen.ItemsSource = list;
            
        }
           
        //}

        private void ClickRem(object sender, SelectionChangedEventArgs e)
        {
            string osoba = (string)HaveAllergen.SelectedItems[0];
            var HaveAllergy = App.DatabaseAllergen.QueryCustomExist(osoba).Result;
            foreach (var listHaveAllergy in HaveAllergy)
            {
                App.DatabaseCostumerAllergen.QueryCustom(jmeno,listHaveAllergy.ID);
            }
            Settings Page = new Settings(1);
            Page.Show();
            this.Close();
        }

        private void ClickAdd(object sender, SelectionChangedEventArgs e)
        {
            string osoba = (string) AllergenL.SelectedItems[0];
            var HaveAllergy = App.DatabaseAllergen.QueryCustomExist(osoba).Result;
            foreach (var listHaveAllergy in HaveAllergy)
            {
                
                CostumerAllergen alergen = new CostumerAllergen();
                alergen.Name = jmeno;
                alergen.Id_Allergen = listHaveAllergy.ID;
                App.DatabaseCostumerAllergen.SaveItemAsync(alergen);
              
               

            }

            Settings Page = new Settings(1);
            Page.Show();
            this.Close();

        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Allergen alergen = new Allergen();
            alergen.Name = Test.Text;
            App.DatabaseAllergen.SaveItemAsync(alergen);
        }
    }
}
