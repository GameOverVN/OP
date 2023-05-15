using app_main.classes;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
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

namespace app_main.Pages {
    /// <summary>
    /// Логика взаимодействия для DataChangePage.xaml
    /// </summary>
    public partial class DataChangePage : Page, INotifyPropertyChanged {

        public int BasicRate {get;set;}
        public DataChangePage() {
            InitializeComponent();
            TextBlockRatio.Text = loadBasicRateFromExcel().ToString();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName) {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        private void Button_CommonSettingsClick(object sender, RoutedEventArgs e) {
            SettingsPanel.Visibility = Visibility.Visible;
            dataGridCities.Visibility = Visibility.Collapsed;
        }
        private void Button_ChangeBasicRatio_Click(object sender, RoutedEventArgs e) {
            textBoxChangeRatio.Visibility = Visibility.Visible;
            buttonConfirm.Visibility = Visibility.Visible;   
        }
        private void ConfirmChangeRatio(object sender, RoutedEventArgs e) {
            try {
                int ratio = Convert.ToInt32(textBoxChangeRatio.Text);
                BasicRate = ratio;
                loadBasicRateToExcel();
                textBoxChangeRatio.Visibility = Visibility.Collapsed;
                buttonConfirm.Visibility = Visibility.Collapsed;
                TextBlockRatio.Text = BasicRate.ToString();
            }
            catch (Exception ex) {

                MessageBox.Show(ex.Message);
            }
            
        }
        public int loadBasicRateFromExcel() {
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
            FileInfo filePath = new FileInfo(@"C:\Users\User\Desktop\bmstu\1.2\praktika_program\app_main\excelTables\Settings.xlsx");
            using (ExcelPackage package = new ExcelPackage(filePath)) {
                var settingsList = package.Workbook.Worksheets["Settings"];

                int rate = Convert.ToInt32(settingsList.Cells["B1"].Value);

                BasicRate = rate;
                return rate;
            }
        }
        private void loadBasicRateToExcel() {
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
            FileInfo filePath = new FileInfo(@"C:\Users\User\Desktop\bmstu\1.2\praktika_program\app_main\excelTables\Settings.xlsx");
            using (ExcelPackage package = new ExcelPackage(filePath)) {
                var settingsList = package.Workbook.Worksheets["Settings"];

                int rate = Convert.ToInt32(textBoxChangeRatio.Text);

                settingsList.Cells["B1"].Value = rate;

                package.Save();
            }
        }

        
    }
}
