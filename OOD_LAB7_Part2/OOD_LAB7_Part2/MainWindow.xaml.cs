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

namespace OOD_LAB7_Part2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private NORTHWNDEntities db = new NORTHWNDEntities();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Ex1Button_Click(object sender, RoutedEventArgs e)
        {
            //Query Db for all customers by country and count number per country
            var query = from c in db.Customers
                group c by c.Country
                into g
                orderby g.Count() descending
                select new
                {
                    Country = g.Key,
                    Count = g.Count()
                };

            //Assign the result set as data source for the data grid.
            Ex1lbDisplay.ItemsSource = query.ToList();
        }

        private void Ex2Button_Click(object sender, RoutedEventArgs e)
        {
            //Query Db for all customers in Italy
            var query = from c in db.Customers
                where c.Country.Equals("Italy")
                select new
                {
                    Orders = c.Orders,
                    CustomerDemographics = c.CustomerDemographics,
                    CustomerID = c.CustomerID,
                    CompanyName = c.CompanyName,
                    ContactName = c.ContactName
                };

            //Assign the result set as data source for the data grid.
            Ex2lbDisplay.ItemsSource = query.ToList();

        }

        private void Ex3Button_Click(object sender, RoutedEventArgs e)
        {
            //Query the db for all products that are available
            var query = from p in db.Products
                where p.UnitsInStock - p.UnitsOnOrder > 0
                select new
                {
                    Product = p.ProductName,
                    Available = p.UnitsInStock
                };

            //Assign the returned result as the data source for the datagrid
            Ex3lbDisplay.ItemsSource = query.ToList();
        }
    }
}
