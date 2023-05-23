using app_main.classes;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using Paragraph = iTextSharp.text.Paragraph;

namespace app_main.Pages.Buy_Page {
    /// <summary>
    /// Логика взаимодействия для mainBuyPage.xaml
    /// </summary>
    public partial class mainBuyPage : Page {

        public static string filePathGlobal = ExcelLoader.filePathBokov;

        public OwnerPage OwnerPage;
        public DateTime DateTime { get; set; }
        public mainBuyPage(OwnerPage ownerPage) {
            InitializeComponent();
            OwnerPage = ownerPage;
            initInfoAbout();
        }
        private void initInfoAbout() {
            textBlockDriver.Text = $"{OwnerPage.textBoxName.Text} {OwnerPage.textBoxSurname.Text} {OwnerPage.textBoxMiddleName.Text}, дата рождения: {OwnerPage.textBoxAge.Text} г.";
            textBlockDriver.FontSize = 16;
            textBlockPrice.Text = $" {CalculatePage.Price} руб.";
            textBlockPrice.FontSize = 16;
        }
        private void Button_PreviousPage_Click(object sender, RoutedEventArgs e) {
            NavigationService.GoBack();
        }

        private void Button_Buy_Click(object sender, RoutedEventArgs e) {
            CustomMessageBox messageBox = new CustomMessageBox("Успешно куплено");
            messageBox.Show();
            var buyer = OwnerPage.createBuyer();
            setBuyerToExcel(buyer);

            makePDFFile();

        }
        private void makePDFFile() {
            DateTime = DateTime.Now;
            BaseFont baseFont = BaseFont.CreateFont("C:\\Windows\\Fonts\\arial.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
            var font = new iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL);
            string fileName = $"{OwnerPage.textBoxSurname.Text}{OwnerPage.textBoxName.Text}{OwnerPage.textBoxMiddleName.Text}";
            Document document = new Document();
            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream($"C:\\Code\\Praktika_Finalochkka\\pdfDocuments\\{fileName}.pdf", FileMode.OpenOrCreate));
            document.Open();
            string str = $"{OwnerPage.textBoxSurname.Text} {OwnerPage.textBoxName.Text} {OwnerPage.textBoxMiddleName.Text}, дата рождения: {OwnerPage.textBoxAge.Text}";

            Paragraph paragraphMain = new Paragraph("Страхователь:", font);
            Paragraph paragraphName = new Paragraph(str, font);
            Paragraph paragraphPassport = new Paragraph($"Паспорт: {OwnerPage.getPassport()}. Водительское удостоверение: {OwnerPage.driverPage.getCarPassort()}", font);
            Paragraph paragraphPrice = new Paragraph($"Стоимость страховки: {textBlockPrice.Text}. Оплачено при помощи карты VISA. Электронный чек отправлен на {OwnerPage.getEmail()}", font);
            Paragraph paragraphTime = new Paragraph($"Начало действия страховки: {DateTime}. Страховка действует до {DateTime.AddYears(1)}", font);
            PdfContentByte cb = writer.DirectContent;
            cb.BeginText();
            cb.SetTextMatrix(220, 600);
            cb.SetFontAndSize(baseFont, 14);
            cb.ShowText("Спасибо за покупку!");
            cb.EndText();

            document.Add(paragraphMain);
            document.Add(paragraphName);
            document.Add(paragraphPassport);
            document.Add(paragraphPrice);
            document.Add(paragraphTime);

            document.Close();
            writer.Close();
        }
        public void setBuyerToExcel(Buyer buyer) {
            FileInfo filePath = new FileInfo($"{filePathGlobal}Buyers.xlsx");
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (ExcelPackage buyerPackage = new ExcelPackage(filePath)) {

                ExcelWorksheet worksheetBuyer = buyerPackage.Workbook.Worksheets["Buyers"];

                int amountOfBuyers = worksheetBuyer.Dimension.Rows + 1;

                worksheetBuyer.Cells["B" + amountOfBuyers].Value = buyer.Surname;
                worksheetBuyer.Cells["C" + amountOfBuyers].Value = buyer.Name;
                worksheetBuyer.Cells["D" + amountOfBuyers].Value = buyer.MiddleName;
                worksheetBuyer.Cells["E" + amountOfBuyers].Value = buyer.CarPassport;
                worksheetBuyer.Cells["F" + amountOfBuyers].Value = buyer.Type;
                worksheetBuyer.Cells["G" + amountOfBuyers].Value = buyer.Price;
                worksheetBuyer.Cells["H" + amountOfBuyers].Value = buyer.DateStart.Date;
                worksheetBuyer.Cells["I" + amountOfBuyers].Value = buyer.DateEnd.Date;
                worksheetBuyer.Cells["J" + amountOfBuyers].Value = buyer.Email;
                buyerPackage.Save();
            }

        }
    }
}
