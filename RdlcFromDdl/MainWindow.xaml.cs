using Microsoft.Reporting.WinForms;
using Models;
using ReportLib;
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

namespace RdlcFromDdl
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

        private void btnGenerate_click(object sender, RoutedEventArgs e)
        {
            object list1 = null;
            var list1r = this.GetSalesData();
            var list2r = new List<RptEntityGen.RptResourceInfo>();

            int sl1 = 1;
            foreach (var item in list1r)
            {
                list2r.Add(new RptEntityGen.RptResourceInfo(_slnum: sl1,
                    invoiceNumber: item.InvoiceNumber,
                    customerName: item.CustomerName,
                    product: item.Product,
                    saleDate: item.SaleDate,
                    quantity: item.Quantity,
                    unitPrice: item.UnitPrice,
                    discount: item.Discount));
                sl1++;
            }

            list1 = list2r;

            /* just trying to make the GetLocalReport function work */
            object RptTitle = "Sales Report";
            var list3 = new object();

            string WindowTitle1 = (string)RptTitle;
            string RptdisplayMode = "PDF";

            string ReportName1 = "RptSetup.SalesRptInfo1";
            LocalReport rpt1 = ReportConfig00.GetLocalReport(ReportName1, list1, RptTitle, list3);
            

        }

        private List<SalesModel> GetSalesData()
        {
            return new List<SalesModel>
        {
            new SalesModel { InvoiceNumber = 1001, SaleDate = DateTime.Today.AddDays(-10), CustomerName = "John Doe", Product = "Laptop", Quantity = 1, UnitPrice = 75000, Discount = 2500 },
            new SalesModel { InvoiceNumber = 1002, SaleDate = DateTime.Today.AddDays(-9), CustomerName = "Jane Smith", Product = "Monitor", Quantity = 2, UnitPrice = 15000, Discount = 1000 },
            new SalesModel { InvoiceNumber = 1003, SaleDate = DateTime.Today.AddDays(-8), CustomerName = "Alice Johnson", Product = "Keyboard", Quantity = 3, UnitPrice = 2000, Discount = 300 },
            new SalesModel { InvoiceNumber = 1004, SaleDate = DateTime.Today.AddDays(-7), CustomerName = "Bob Lee", Product = "Mouse", Quantity = 5, UnitPrice = 1200, Discount = 200 },
            new SalesModel { InvoiceNumber = 1005, SaleDate = DateTime.Today.AddDays(-6), CustomerName = "Chris Paul", Product = "Printer", Quantity = 1, UnitPrice = 22000, Discount = 1500 },
            new SalesModel { InvoiceNumber = 1006, SaleDate = DateTime.Today.AddDays(-5), CustomerName = "Diana Ross", Product = "Router", Quantity = 2, UnitPrice = 4500, Discount = 300 },
            new SalesModel { InvoiceNumber = 1007, SaleDate = DateTime.Today.AddDays(-4), CustomerName = "Ethan Hunt", Product = "Tablet", Quantity = 1, UnitPrice = 30000, Discount = 2000 },
            new SalesModel { InvoiceNumber = 1008, SaleDate = DateTime.Today.AddDays(-3), CustomerName = "Frank Castle", Product = "Smartphone", Quantity = 2, UnitPrice = 28000, Discount = 2500 },
            new SalesModel { InvoiceNumber = 1009, SaleDate = DateTime.Today.AddDays(-2), CustomerName = "Grace Lee", Product = "Webcam", Quantity = 3, UnitPrice = 3500, Discount = 500 },
            new SalesModel { InvoiceNumber = 1010, SaleDate = DateTime.Today.AddDays(-1), CustomerName = "Henry Ford", Product = "External HDD", Quantity = 1, UnitPrice = 8500, Discount = 300 },
        };
        }
    }
}
