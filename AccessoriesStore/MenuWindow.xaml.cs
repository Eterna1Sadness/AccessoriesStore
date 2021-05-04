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
using System.Data.SqlClient;

namespace AccessoriesStore
{
    /// <summary>
    /// Interaction logic for MenuWindow.xaml
    /// </summary>
    public partial class MenuWindow : Window
    {
        public MenuWindow()
        {
            InitializeComponent();
        }

        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = ListViewMenu.SelectedIndex;
            MoveCursorMenu(index);

            //AccessoriesStoreDB db = new AccessoriesStoreDB();
            //AccessoriesEntitiesBD db = new AccessoriesEntitiesBD();
            APMpsychoEntities db = new APMpsychoEntities();
            var cpu = from d in db.Students select d;
            var gpu = from d in db.Admins select d;
            var ram = from d in db.Teachers select d;
            var mb = from d in db.Tests select d;


            switch (index)
            {
                case 0:
                    this.productGrid.ItemsSource = cpu.ToList();
                    break;
                case 1:
                    this.productGrid.ItemsSource = gpu.ToList();
                    break;
                case 2:
                    this.productGrid.ItemsSource = ram.ToList();
                    break;
                case 3:
                    this.productGrid.ItemsSource = mb.ToList();
                    break;
                default:
                    break;
            }
        }

        private void MoveCursorMenu(int index)
        {
            TrainsitionigContentSlide.OnApplyTemplate();
            GridCursor.Margin = new Thickness(0, (170 + (60 * index)), 0, 0);
        }

        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Visible;
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
            LogoImage.Visibility = Visibility.Visible;

        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
            ButtonOpenMenu.Visibility = Visibility.Visible;
            LogoImage.Visibility = Visibility.Collapsed;
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AddProductButton_Click(object sender, RoutedEventArgs e)
        {
            Add.Children.Clear();
            Add.Children.Add(new AddProductControl());
        }

        private void productGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            //AccessoriesStoreDB db = new AccessoriesStoreDB();
            AccessoriesEntitiesBD db = new AccessoriesEntitiesBD();

            var r = from d in db.Products select d;

            int productID = ((Product)productGrid.SelectedItem).ID;

            var removeEvent = db.Products.Where(ev => ev.ID == productID).Single();

            db.Products.Remove(removeEvent);
            db.SaveChanges();
            this.productGrid.ItemsSource = db.Products.ToList();
        }
        public int changedId = 0;
        private void ChangeProductButton_Click(object sender, RoutedEventArgs e)
        {
            //AccessoriesStoreDB db = new AccessoriesStoreDB();
            AccessoriesEntitiesBD db = new AccessoriesEntitiesBD();
            //this.productGrid.ItemsSource = db.Products.ToList();

            ChangeProductControl change = new ChangeProductControl();

            if (this.productGrid.SelectedIndex >= 0)
            {
                if (this.productGrid.SelectedItems.Count >= 0)
                {
                    if (this.productGrid.SelectedItems[0].GetType() == typeof(Product))
                    {
                        Product product = (Product)this.productGrid.SelectedItems[0];
                        change.comboBox_Product.Text = product.ProductType;
                        change.textBox_Name.Text = product.ProductName;
                        change.textBox_Price.Text = product.ProductPrice;
                        //product.ProductAvailability = "В наличии";
                        change.arrivalDate.DisplayDate = product.ArrivalDate;

                        this.changedId = product.ID;
                    }
                }
            }
            Add.Children.Clear();
            Add.Children.Add(new ChangeProductControl());
        }

        private void BascketProductButton_Click(object sender, RoutedEventArgs e)
        {
            //using (AccessoriesStoreDB db = new AccessoriesStoreDB())
            //AccessoriesStoreDB db = new AccessoriesStoreDB();
            AccessoriesEntitiesBD db = new AccessoriesEntitiesBD();

            Product product = (Product)this.productGrid.SelectedItem;
            Basket basket = new Basket()
            {
                ProductID = product.ID,
                Products = product.ProductName,
                TotalAmount = product.ProductPrice
            };

            db.Baskets.Add(basket);
            db.SaveChanges();

            var r = from d in db.Baskets select d;
            
        }

        private void productGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            //try
            //{
            //    ((productGrid)sender).SelectedCells[0].Selected = false;
            //}
            //catch { }
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void BasketOpenButton_Click(object sender, RoutedEventArgs e)
        {
            Add.Children.Clear();
            Add.Children.Add(new BasketControl());
        }

        private void ReportButton_Click(object sender, RoutedEventArgs e)
        {
            Report report = new Report();
            report.Show();
        }
    }
}
