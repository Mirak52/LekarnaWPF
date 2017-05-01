﻿using System;
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
        public Settings(string name)
        {
            InitializeComponent();
            jmeno = name;
            View();        
        }

        private void View()
        {          
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
        private void ClickRem(object sender, SelectionChangedEventArgs e)
        {
            string osoba = (string)HaveAllergen.SelectedItems[0];
            var HaveAllergy = App.DatabaseAllergen.QueryCustomExist(osoba).Result;
            foreach (var listHaveAllergy in HaveAllergy)
            {
                App.DatabaseCostumerAllergen.QueryCustom(jmeno,listHaveAllergy.ID);
            }
            Settings Page = new Settings(jmeno);
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
            Settings page = new Settings(jmeno);
            page.Show();
            this.Close();
        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow page = new MainWindow();
            page.Show();
            this.Close();
        }
        private void Shop_Click(object sender, RoutedEventArgs e)
        {
            MedicineViewer page = new MedicineViewer(jmeno);
            page.Show();
            this.Close();
        }
    }
}
