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

namespace EPAM_Task17
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ShopEntities1 db = new ShopEntities1();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnShow_Click(object sender, RoutedEventArgs e)
        {
            var customerId = tbxCustomerId.Text;
            var orders = from o in db.Orders
                         join c in db.Customers
                         on o.CustomerId equals c.CustomerId
                         where c.CustomerId.ToString() == customerId
                         select new { o.OrderId, o.Quantity, o.OrderDate, c.FirstName, c.LastName };

            var ordersOfProduct = from co in orders
                                  join op in db.OrdersCartsProductsSellers
                                  on co.OrderId equals op.OrderId
                                  select new
                                  {
                                      co.OrderId,
                                      co.OrderDate,
                                      co.Quantity,
                                      co.FirstName,
                                      co.LastName,
                                      op.ProductId
                                  };

            var customerOrders = from o in ordersOfProduct
                                 join p in db.Products
                                 on o.ProductId equals p.ProductId
                                 select new
                                 {
                                     o.OrderId,
                                     p.ProductName,
                                     o.Quantity,
                                     o.OrderDate,
                                     o.FirstName,     
                                 };
            lvOrders.ItemsSource = customerOrders.ToList();
        }

        private void btnShow1_Click(object sender, RoutedEventArgs e)
        {
            var comments = from c in db.Comments
                           join p in db.Products
                           on c.ProductId equals p.ProductId
                           select new
                           {
                               p.ProductName,
                               c.Description,
                               c.Customers.FirstName,
                               c.Customers.LastName
                           };
            lvComments.ItemsSource = comments.ToList();
        }
    }
}
