using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using OfficeOpenXml;
using ProjectPRN212.GUI.Login_Register;
using ProjectPRN212.Models;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using static ProjectPRN212.Login_Register.Login;

namespace ProjectPRN212.GUI.Page_Admin
{
    /// <summary>
    /// Interaction logic for ManagementOrder.xaml
    /// </summary>
    public partial class ManagementOrder : Window
    {
        public ManagementOrder()
        {

            InitializeComponent();
            LoadOrder();
        }

        private void LoadOrder()
        {
            using (ShopNewContext context = new ShopNewContext())
            {
                var orders = context.Orders.Include(c => c.Customer).ToList();

                OrdersListView.ItemsSource = orders;
            }
        }
        private void Detail_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is int orderId)
            {
                Page_Admin.OrderDetails orderDetailsWindow = new Page_Admin.OrderDetails(orderId);
                orderDetailsWindow.Show();
            }
        }
        private void SendOrder_Click(object sender, RoutedEventArgs e)
        {
            using (ShopNewContext context = new ShopNewContext())
            {
                if (sender is Button button && button.Tag is int orderId)
                {
                    Models.Order order = context.Orders.FirstOrDefault(s => s.OrderId == orderId);
                    if (order != null)
                    {
                        order.OrderStatus = "Delivering";
                        context.Orders.Update(order);
                        context.SaveChanges();
                        LoadOrder();
                    }

                }
            }

        }

        private void CancelOrder_Click(object sender, RoutedEventArgs e)
        {
            using (ShopNewContext context = new ShopNewContext())
            {
                if (sender is Button button && button.Tag is int orderId)
                {
                    Models.Order order = context.Orders.FirstOrDefault(s => s.OrderId == orderId);
                    if (order != null)
                    {
                        var orderDetails = context.OrderDetails.Where(od => od.OrderId == orderId).ToList();
                        foreach (var orderDetail in orderDetails)
                        {
                            var product = context.Products.FirstOrDefault(p => p.ProductId == orderDetail.ProductId);
                            if (product != null)
                            {
                                product.Quantity += orderDetail.Quantity;
                                context.Products.Update(product);
                                context.SaveChanges();
                            }
                        }

                        order.OrderStatus = "Cancelled";
                        context.Orders.Update(order);
                        context.SaveChanges();
                        LoadOrder();
                    }
                }
            }
        }


        private void btnProfile_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
            Profile profile = new Profile();
            profile.ShowDialog();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ApplicationState.staffSession = null;
            this.Visibility = Visibility.Collapsed;
            MainWindow MainWindow = new MainWindow();
            MainWindow.ShowDialog();
            this.Close();

        }

        private void ExportToExcel_Click(object sender, RoutedEventArgs e)
        {
            using (ShopNewContext context = new ShopNewContext())
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();

                saveFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                saveFileDialog.InitialDirectory = @"D:\NewProjectPRN212";
                saveFileDialog.FileName = "OrdersReport.xlsx";
                saveFileDialog.Title = "Export Orders Report";

                if (saveFileDialog.ShowDialog() == true)
                {
                    string filePath = saveFileDialog.FileName;

                    FileInfo fileInfo = new FileInfo(filePath);

                    if (fileInfo.Exists)
                    {
                        fileInfo.Delete();
                    }

                    // Set the license context for EPPlus
                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                    var orders = context.Orders.Include(c => c.Customer).Include(o => o.OrderDetails).ThenInclude(od => od.Product).ToList();

                    using (var package = new ExcelPackage(fileInfo))
                    {
                        var worksheet = package.Workbook.Worksheets.Add("Orders");

                        worksheet.Cells[1, 1].Value = "Order ID";
                        worksheet.Cells[1, 2].Value = "Customer Name";
                        worksheet.Cells[1, 3].Value = "Receiver fullname";
                        worksheet.Cells[1, 4].Value = "Receiver gender";
                        worksheet.Cells[1, 5].Value = "Receiver email";
                        worksheet.Cells[1, 6].Value = "Phone number";
                        worksheet.Cells[1, 7].Value = "Receiver address";
                        worksheet.Cells[1, 8].Value = "Order Date";
                        worksheet.Cells[1, 9].Value = "Order status";
                        worksheet.Cells[1, 10].Value = "Total Cost";

                        worksheet.Column(1).Width = 15;
                        worksheet.Column(2).Width = 25;
                        worksheet.Column(3).Width = 25;
                        worksheet.Column(4).Width = 15;
                        worksheet.Column(5).Width = 30;
                        worksheet.Column(6).Width = 15;
                        worksheet.Column(7).Width = 30;
                        worksheet.Column(8).Width = 20;
                        worksheet.Column(9).Width = 15;
                        worksheet.Column(10).Width = 20;

                        int row = 2;
                        foreach (var order in orders)
                        {
                            worksheet.Cells[row, 1].Value = order.OrderId;
                            worksheet.Cells[row, 2].Value = order.Customer.Fullname;
                            worksheet.Cells[row, 3].Value = order.ReceiverFullname;
                            worksheet.Cells[row, 4].Value = order.ReceiverGender;
                            worksheet.Cells[row, 5].Value = order.ReceiverEmail;
                            worksheet.Cells[row, 6].Value = order.PhoneNumber;
                            worksheet.Cells[row, 7].Value = order.ReceiverAddress;
                            worksheet.Cells[row, 8].Value = order.OrderDate.Value.ToString("dd/MM/yyyy");
                            worksheet.Cells[row, 9].Value = order.OrderStatus;
                            worksheet.Cells[row, 10].Value = order.TotalCost;

                            row++;
                        }

                        package.Save();
                    }

                    MessageBox.Show("Report exported successfully.");
                }
                else
                {
                    MessageBox.Show("Export canceled.");
                }
            }
        }


    }
}
