using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using IronXL;
using OfficeOpenXml;
namespace app_main.classes {
     class ExcelLoader {
        public static string filePathSenin = @"C:\Users\User\Desktop\bmstu\1.2\praktika_program\app_main\excelTables\";
        public static string filePathBokov = @"C:\Code\Praktika_Finalochkka\excelTables\";
        public void LoadExcel() {
            
            FileInfo filePath = new FileInfo(@"C:\Code\Praktika_Finalochkka\excelTables\Cars.xlsx");
            deleteIfExists(filePath);
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (ExcelPackage excelPackage = new ExcelPackage(filePath)) {
               
                ExcelWorksheet worksheetCars = excelPackage.Workbook.Worksheets.Add("Cars");

                worksheetCars.Cells["A1"].Value = "№";
                worksheetCars.Cells["B1"].Value = "Brand";
                worksheetCars.Cells["C1"].Value = "Model";
                worksheetCars.Cells["D1"].Value = "Power";
                worksheetCars.Cells["E1"].Value = "Year";
                worksheetCars.Cells["F1"].Value = "Price";

               

                ExcelWorksheet worksheetCities = excelPackage.Workbook.Worksheets.Add("Cities");
                worksheetCities.Cells["A1"].Value = "№";
                worksheetCities.Cells["B1"].Value = "City";
                worksheetCities.Cells["C1"].Value = "Coefficient";
                int rowCities=2;
                foreach (var city in Arrays.cities) {
                    worksheetCities.Cells["A"+rowCities].Value = rowCities-1;
                    worksheetCities.Cells["B"+rowCities].Value = city.Name;
                    worksheetCities.Cells["C"+rowCities].Value = city.Ratio;
                    rowCities++;
                }
                excelPackage.Save();
            }
           
        }
        private  void deleteIfExists(FileInfo file) {
            if (file.Exists) { file.Delete(); }
        }
        public void SetUserToExcel(User newUser) {
            FileInfo filePath = new FileInfo($"{filePathBokov}Users.xlsx");
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;                                                                                                             
            using (ExcelPackage userPackage = new ExcelPackage(filePath)) {

                ExcelWorksheet worksheetUsers = userPackage.Workbook.Worksheets["Users"];

                // int amountOfUsers = worksheetUsers.Rows.Count();
                int amountOfUsers = worksheetUsers.Dimension.Rows + 1;
                worksheetUsers.Cells["A" + amountOfUsers].Value = newUser.ID;
                worksheetUsers.Cells["B" + amountOfUsers].Value = newUser.Login;
                worksheetUsers.Cells["C" + amountOfUsers].Value = newUser.Password;

                userPackage.Save();
            }

        }
        public void SetUsersToExcel(ObservableCollection<User> users) {
            FileInfo filePath = new FileInfo($"{filePathBokov}Users.xlsx");
            deleteIfExists(filePath);
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (ExcelPackage userPackage = new ExcelPackage(filePath)) {

                ExcelWorksheet worksheetUsers = userPackage.Workbook.Worksheets.Add("Users");

                worksheetUsers.Cells["A" + 1].Value = "ID";
                worksheetUsers.Cells["B" + 1].Value = "Логин";
                worksheetUsers.Cells["C" + 1].Value = "Пароль";
                int row = 2;
                foreach (User user in users) {
                  
                    worksheetUsers.Cells["A" + row].Value = user.ID;
                    worksheetUsers.Cells["B" + row].Value = user.Login;
                    worksheetUsers.Cells["C" + row].Value = user.Password;
                    row++;
                }
                
                userPackage.Save();
            }

        }
        
        }


    }


