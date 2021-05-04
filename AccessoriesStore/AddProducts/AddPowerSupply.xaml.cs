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
    /// Interaction logic for AddPowerSupply.xaml
    /// </summary>
    public partial class AddPowerSupply : UserControl
    {
        public AddPowerSupply()
        {
            InitializeComponent();
        }

        private void AddPSButton_Click(object sender, RoutedEventArgs e)
        {
            //AccessoriesStoreDB db = new AccessoriesStoreDB();
            AccessoriesEntitiesBD db = new AccessoriesEntitiesBD();
            PowerSupply powerSupply = new PowerSupply()
            {
                PSPower = textBox_PSPower.Text,
                PowerSupplyStandard = textBox_PowerSupplyStandart.Text,
                MaxLineCurrent12V = textBox_MaxLineCurrent12V.Text,
                PFC = textBox_PFC.Text,
                PowerSupplyConnectors = textBox_PowerSupplyConnectors.Text,
                Dimensions = textBox_Dimensions.Text
            };

            db.PowerSupplies.Add(powerSupply);
            db.SaveChanges();

            (this.Parent as Grid).Children.Remove(this);
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            (this.Parent as Grid).Children.Remove(this);
        }
    }
}
