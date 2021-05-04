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
    /// Interaction logic for AddProductControl.xaml
    /// </summary>
    public partial class AddProductControl : UserControl
    {
        public AddProductControl()
        {
            InitializeComponent();
        }

        public void AddProductButton_Click(object sender, RoutedEventArgs e)
        {
            //AccessoriesStoreDB db = new AccessoriesStoreDB();
            AccessoriesEntitiesBD db = new AccessoriesEntitiesBD();
            Product product = new Product()
            {
                ProductName = textBox_Name.Text,
                ProductType = comboBox_Product.Text,     
                ProductPrice = textBox_Price.Text + " руб.",
                ProductAvailability = "В наличии",
                ArrivalDate = arrivalDate.DisplayDate
            };

            db.Products.Add(product);
            db.SaveChanges();

            (this.Parent as Grid).Children.Remove(this);
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            (this.Parent as Grid).Children.Remove(this);
        }

        private void specificationsButton_Click(object sender, RoutedEventArgs e)
        {
            int index = comboBox_Product.SelectedIndex;

            switch (index)
            {
                case 0:
                    AddProduct.Children.Clear();
                    AddProduct.Children.Add(new AddCPU());
                    break;
                case 1:
                    AddProduct.Children.Clear();
                    AddProduct.Children.Add(new AddGPU());
                    break;
                case 2:
                    AddProduct.Children.Clear();
                    AddProduct.Children.Add(new AddRAM());
                    break;
                case 3:
                    AddProduct.Children.Clear();
                    AddProduct.Children.Add(new AddMotherboard());
                    break;
                case 4:
                    AddProduct.Children.Clear();
                    AddProduct.Children.Add(new AddPowerSupply());
                    break;
                case 5:
                    AddProduct.Children.Clear();
                    AddProduct.Children.Add(new AddHDDSSD());
                    break;
                default:
                    break;
            }
        }
    }
}
