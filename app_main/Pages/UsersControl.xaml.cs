using app_main.classes;
using app_main.windows;
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

namespace app_main {
    /// <summary>
    /// Логика взаимодействия для UsersControl.xaml
    /// </summary>
    public partial class UsersControl : Page, INotifyPropertyChanged{

        public static string filePathGlobal = ExcelLoader.filePathBokov;
        public UsersControl() {
            InitializeComponent();
            DataGridUsers.ItemsSource = users;
        }
        private ObservableCollection<User> users = getUsers();
        
        
        public ObservableCollection<User> Users {
            get { return users; }
            set { users = value;
                OnPropertyChanged("Users");
            }
        }

        

        
        
     
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName) {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

       
        private static ObservableCollection<User> getUsers() {
            FileInfo filePath = new FileInfo($"{filePathGlobal}Users.xlsx");
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
            using (var package = new ExcelPackage(filePath)) {
                var usersList = package.Workbook.Worksheets["Users"];

                int row = usersList.Dimension.Rows - 1;
                var users = new ObservableCollection<User>();

                for (int i = 0; i < row; i++) {

                    User user = new User(0, null, null);
                    int rowColumn = 2 + i;
                    user.ID = Convert.ToInt32(usersList.Cells["A" + rowColumn].Value);
                    user.Login = usersList.Cells["B" + rowColumn].Value.ToString();
                    user.Password = usersList.Cells["C" + rowColumn].Value.ToString();
                    users.Add(user);

                }
                return users;

            }
        }


        private void deleteUserDG_Click(object sender, RoutedEventArgs e) {
            deleteUserFromDG idWindow = new deleteUserFromDG();
            idWindow.ShowDialog();
            if (idWindow.idTextBox.Text=="") {
                idWindow.Close();
            }
            else {
                int id = Convert.ToInt32(idWindow.idTextBox.Text);

                var idList = new List<int>();
                foreach (var user in users) {
                    idList.Add(user.ID);
                }
                if (idList.Contains(id)) {
                    foreach (var user in users.ToArray()) {
                        if (user.ID == id) {
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
                ExcelLoader excelLoader = new ExcelLoader();
                excelLoader.SetUsersToExcel(users);

                idWindow.Close();

            }





        }

    }
}
