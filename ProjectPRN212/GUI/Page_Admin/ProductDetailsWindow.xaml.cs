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
using static ProjectPRN212.Service.AdminProductApiService;

namespace ProjectPRN212.GUI.Page_Admin
{


    public partial class ProductDetailsWindow : Window
    {
        public ProductDTO Product { get; set; }

        public ProductDetailsWindow(ProductDTO product)
        {
            InitializeComponent();
            Product = product;
            DataContext = this;
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }



    }
}
