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
    /// Interaction logic for AddCPU.xaml
    /// </summary>
    public partial class AddCPU : UserControl
    {
        public AddCPU()
        {
            InitializeComponent();
        }

        private void AddCPUButton_Click(object sender, RoutedEventArgs e)
        {
            //AccessoriesStoreDB db = new AccessoriesStoreDB();
            AccessoriesEntitiesBD db = new AccessoriesEntitiesBD();
            CPU cpu = new CPU()
            {
                CPUManufacturer = comboBox_Manufacturer.Text,
                Lineup = textBox_LineUp.Text,
                DeliveryType = textBox_DeliveryType.Text,
                CoolingIncluded = comboBox_CoolingIncluded.Text,
            };

            db.CPUs.Add(cpu);
            db.SaveChanges();

            (this.Parent as Grid).Children.Remove(this);
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            (this.Parent as Grid).Children.Remove(this);
        }
    }
}
