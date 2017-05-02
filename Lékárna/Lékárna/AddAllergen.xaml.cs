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
    /// Interaction logic for AddAllergen.xaml
    /// </summary>
    public partial class AddAllergen : Window
    {
        public AddAllergen()
        {
            InitializeComponent();
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            DrugAllergen alergen = new DrugAllergen();
            alergen.Id_Allergen = 2;
            alergen.Id_drug = 2;

            App.DatabaseDrugAllergen.SaveItemAsync(alergen);
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow page = new MainWindow();
            page.Show();
            this.Close();
        }
    }
}
