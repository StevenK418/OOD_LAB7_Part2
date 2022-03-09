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
    }
}
