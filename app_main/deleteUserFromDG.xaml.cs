using app_main.windows;
using app_main.classes;
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


namespace app_main {
    /// <summary>
    /// Логика взаимодействия для deleteUserFromDG.xaml
    /// </summary>
    public partial class deleteUserFromDG : Window {
        public deleteUserFromDG() {
            InitializeComponent();
        }
        private static void textBox_TextInput(object sender, TextCompositionEventArgs e) {
            if (!Char.IsDigit(e.Text, 0)) {
                e.Handled = true;
            }
        }
        private void CancelDelete(object sender, RoutedEventArgs e) {
            this.Close();
        }
        
        private void deleteUserFromBD(object sender, RoutedEventArgs e) {
            var users = MainWindow.getUsers();

            int id = Convert.ToInt32(idTextBox.Text);
            var idList =new List<int>();
            foreach (var user in users) {
                idList.Add(user.ID);
            }
            if (idList.Contains(id)) {
                foreach ( var user in users.ToArray() ) {
                    if (user.ID==id) {
                        try {
                            users.Remove(user);
                            
                        }
                        catch (Exception ex) {

                            MessageBox.Show(ex.Message);
                        }
                    }
                }
            }
            else {
                MessageBox.Show("Указанный пользователь не найден");
            }
            AdminWindow adminWindow = new AdminWindow();
            adminWindow.usersRefresh();
            ExcelLoader excelLoader = new ExcelLoader();
            excelLoader.SetUsersToExcel(users);

            Close();


        }

       
    }
}
