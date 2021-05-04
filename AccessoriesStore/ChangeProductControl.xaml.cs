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
    /// Interaction logic for ChangeProductControl.xaml
    /// </summary>
    public partial class ChangeProductControl : UserControl
    {
        public ChangeProductControl()
        {
            InitializeComponent();
        }
        private void ChangeProductButton_Click(object sender, RoutedEventArgs e)
        {
            //AccessoriesStoreDB db = new AccessoriesStoreDB();
            AccessoriesEntitiesBD db = new AccessoriesEntitiesBD();
            MenuWindow menu = new MenuWindow();
            var change = from c in db.Products where c.ID == menu.changedId select c;

            foreach(var item in change)
            {
                item.ProductName = textBox_Name.Text;
                item.ProductPrice = textBox_Price.Text;
                item.ArrivalDate = arrivalDate.DisplayDate;
                item.ProductType = comboBox_Product.Text;
            }

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
                    ChangeProduct.Children.Clear();
                    ChangeProduct.Children.Add(new AddCPU());
                    break;
                case 1:
                    ChangeProduct.Children.Clear();
                    ChangeProduct.Children.Add(new AddGPU());
                    break;
                case 2:
                    ChangeProduct.Children.Clear();
                    ChangeProduct.Children.Add(new AddRAM());
                    break;
                case 3:
                    ChangeProduct.Children.Clear();
                    ChangeProduct.Children.Add(new AddMotherboard());
                    break;
                case 4:
                    ChangeProduct.Children.Clear();
                    ChangeProduct.Children.Add(new AddPowerSupply());
                    break;
                case 5:
                    ChangeProduct.Children.Clear();
                    ChangeProduct.Children.Add(new AddHDDSSD());
                    break;
                default:
                    break;
            }
        }
    }
}
