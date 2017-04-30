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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Lékárna.Databaze;

namespace Lékárna
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        public void Login()
        {
            string name = NameB.Text;
            string pass = PassB.Text;
            string passDat = "";
            int ID = 0;
            bool found = false;
            int decision = 0;

            if (name != "" & pass != "")
            {
                var userCount = App.DatabaseCustomers.QueryCustomExist().Result;
                foreach (var house in userCount)
                {
                    if (house.Name == name)
                    {
                        ID = house.ID;
                        found = true;
                        passDat = house.Password;
                        decision = house.Choice;
                    }
                }
                if (found)
                {
                    string passHash = App.GetStringSha256Hash(pass);
                    if (passHash == passDat)
                    {
                        if (decision == 1)
                        {
                            MedicineViewer Page = new MedicineViewer(name, ID);
                            Page.Show();
                            this.Close();
                        }
                        else
                        {
                            //Settings Page = new Settings(name, ID);
                            //Page.Show();
                            this.Close();
                        }
                    }
                    else
                    {
                        Error.Content = "";
                    }
                }
                else
                {
                    Error.Content = "Zkontroluj údaje";
                }

            }

            else
            {
                Error.Content = "Špatně vyplněné údaje";
            }



        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            Registration Page = new Registration();
            Page.Show();
            this.Close();
        }

        private void Loggin_Click(object sender, RoutedEventArgs e)
        {
            Login();
        }

        private void Forgot_Click(object sender, RoutedEventArgs e)
        {
            string marek = "marek";
            Settings Page = new Settings(1);
            Page.Show();
            this.Close();

        }
    }
}
