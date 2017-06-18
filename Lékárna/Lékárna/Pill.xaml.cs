using Lékárna.Databaze;
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
    /// Interaction logic for Pill.xaml
    /// </summary>
    public partial class Pill : Window
    {
        public Pill()
        {
            InitializeComponent();
        }

        private void AlergenCreate_Click(object sender, RoutedEventArgs e)
        {
            Allergen alergen = new Allergen();
            alergen.Name = AlergenName.Text;
            App.DatabaseAllergen.SaveItemAsync(alergen);
        }

        private void Alergensend_Click(object sender, RoutedEventArgs e)
        {
            DrugAllergen alergen = new DrugAllergen();
            int x = 0;
            int y = 0;
            Int32.TryParse(IDDrog.Text, out x);
            Int32.TryParse(IDAlergen.Text, out y);
            alergen.Id_Allergen = y;
            alergen.Id_drug = x;
            App.DatabaseDrugAllergen.SaveItemAsync(alergen);
        }

        private void send_Click(object sender, RoutedEventArgs e)
        {
            Drug alergen = new Drug();

            alergen.Name = NameB.Text;
            alergen.price = PassB.Text;
            alergen.warning = PassBA.Text; 
            App.DatabaseDrug.SaveItemAsync(alergen);

        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow page = new MainWindow();
            page.Show();
            this.Close();
        }
    }
}
