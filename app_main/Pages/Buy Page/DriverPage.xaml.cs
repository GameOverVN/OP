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
using System.Windows.Navigation;
using System.Windows.Shapes;
using static app_main.Pages.BuyPage;

namespace app_main.Pages.Buy_Page {
    /// <summary>
    /// Логика взаимодействия для DriverPage.xaml
    /// </summary>
    public partial class DriverPage : Page {
        public BuyPage buyPage;
        public static bool isOwner;
        public Driver Driver { get; set; }
        public DriverPage(BuyPage buyPage) {
            InitializeComponent();
            this.buyPage = buyPage;
            Driver = CalculatePage.Driver;
            initInfoAboutDriver();
            buyPage.getbackButton.Visibility = Visibility.Collapsed;
        }

        public string getCarPassort()
        {
            if (textBoxCarPassport.Text != "")
            {
                return textBoxCarPassport.Text;
            }
            else
            {
            return null;
                
            }
            
        }

        private void Button_PreviousCarPage_Click(object sender, RoutedEventArgs e) {
            buyPage.openPage(buyPages.car);
        }
        private void Button_NextOwnerPage_Click(object sender, RoutedEventArgs e) {
            if(getCarPassort() == null)
            {
                TextBlockEmptyCarPassport.Visibility = Visibility.Visible;
            }
            else
            {
                TextBlockEmptyCarPassport.Visibility = Visibility.Hidden;
                buyPage.frameBuyPage.Navigate(new OwnerPage(this));
            }
            
        }

        private void initInfoAboutDriver() {
            textBlockName.Text = Driver.Name;
            textBlockSurname.Text = Driver.Surname;
            textBlockMiddleName.Text = Driver.MiddleName;
            textBlockAge.Text = Driver.Age.ToString();
            textBlockStaj.Text = Driver.Experience.ToString();
            checkBoxPolicyholder.Content = $"{Driver.Name} {Driver.Surname} - собственник транспортного средства";
            
        }
        

    }
}
