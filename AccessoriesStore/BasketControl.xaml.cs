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

namespace AccessoriesStore
{
    /// <summary>
    /// Interaction logic for BasketControl.xaml
    /// </summary>
    public partial class BasketControl : UserControl
    {
        public BasketControl()
        {
            InitializeComponent();
        }
        AccessoriesStoreDB db = new AccessoriesStoreDB();
        //AccessoriesEntitiesBD db = new AccessoriesEntitiesBD();

        private void basketGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {

        }

        private void  CancelButton_Click (object sender, RoutedEventArgs e)
        {
            (this.Parent as Grid).Children.Remove(this);
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            AccessoriesStoreDB db = new AccessoriesStoreDB();
            //AccessoriesEntitiesBD db = new AccessoriesEntitiesBD();
            var r = from d in db.Baskets select d;
            this.basketGrid.ItemsSource = db.Baskets.ToList();

            //Binding price = new Binding();
            //price.ElementName = " руб.";
            //price.Path = new PropertyPath("Text");
            //priceAmount.SetBinding(TextBlock.TextProperty, price);

            //double sum = 0;
            //for (int i = 0; i < basketGrid.Columns.Count - 1; i++)
            //{
            //    sum += Convert.ToDouble(basketGrid.CurrentColumn.Cell[i].Value);
            //}

            //var sums = from d in db.Baskets select 
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            //AccessoriesStoreDB db = new AccessoriesStoreDB();
            var a = ((System.Data.Entity.Infrastructure.IObjectContextAdapter)db).ObjectContext;
            a.ExecuteStoreCommand("TRUNCATE TABLE [Basket]");
            db.SaveChanges();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            (this.Parent as Grid).Children.Remove(this);
            var a = ((System.Data.Entity.Infrastructure.IObjectContextAdapter)db).ObjectContext;
            a.ExecuteStoreCommand("TRUNCATE TABLE [Basket]");
            db.SaveChanges();
        }
    }
}
