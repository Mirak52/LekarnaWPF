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

namespace Lékárna
{
    /// <summary>
    /// Interaction logic for MedicineViewer.xaml
    /// </summary>
    public partial class MedicineViewer : Window
    {
        public MedicineViewer(string name,int ID)
        {
            InitializeComponent();
        }
    }
}
