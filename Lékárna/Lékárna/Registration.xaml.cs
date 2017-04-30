using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Lékárna
{
    /// <summary>
    /// Interaction logic for Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        public Registration()
        {
            InitializeComponent();
        }

        public void Reg()
        {
            string name = NameB.Text;
            string pass = PassB.Text;
            string passB = PassBA.Text;
            bool found = false;

            if (name != "" & pass != "" & passB != "")
            {
                var userCount = App.DatabaseCustomers.QueryCustomExist().Result;
                foreach (var house in userCount)
                {
                    if (house.Name == name)
                    {
                        found = true;
                    }

                }
                if (!found)
                    {
                        if (pass == passB)
                        {
                            string passHash = App.GetStringSha256Hash(pass);
                             Customers customer = new Customers();
                             customer.Authorization = 1;
                             customer.Name = name;
                             customer.Password = passHash;
                             App.DatabaseCustomers.SaveItemAsync(customer);
                            Error.Content = " Účet uspěšně vytvořen!";
                        }
                        else
                        {
                            Error.Content = "hesla se neshodují!";
                        }
                    }
                    else
                    {
                        Error.Content = "Uživatel existuje";
                    }
                 
            }

            else
            {
                Error.Content = "Špatně vyplněné údaje";
            }
        }
        private void Register_Click(object sender, RoutedEventArgs e)
        {
            Error.Content = "";
            Reg();
           
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
