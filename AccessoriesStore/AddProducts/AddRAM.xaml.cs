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
    /// Interaction logic for AddRAM.xaml
    /// </summary>
    public partial class AddRAM : UserControl
    {
        public AddRAM()
        {
            InitializeComponent();
        }

        private void AddRAMButton_Click(object sender, RoutedEventArgs e)
        {
            //AccessoriesStoreDB db = new AccessoriesStoreDB();
            AccessoriesEntitiesBD db = new AccessoriesEntitiesBD();
            RAM ram = new RAM()
            {
                RAMSet = textBox_RAMSet.Text,
                RAMVolume = textBox_RAMVolume.Text,
                RAMType = textBox_RAMType.Text,
                RAMFrequency = textBox_RAMFrequency.Text,
                CASLatency = textBox_CASLatency.Text,
                Timing = textBox_Timing.Text,
                SupplyVoltage = textBox_SupplyVoltage.Text,
                ChipLocation = textBox_ChipLocation.Text,
                NumberMicrocircuits = textBox_NumberMicrocircuits.Text,
                CapacityMicrocircuits = textBox_CapacityMicrocircuits.Text,
                TypeMicrocircuits = textBox_TypeMicrocircuits.Text,
                XMPprofiles = textBox_XMPprofiles.Text,
                AMPprofiles = textBox_AMPprofiles.Text,
                Cooling = textBox_Cooling.Text
            };

            db.RAMs.Add(ram);
            db.SaveChanges();

            (this.Parent as Grid).Children.Remove(this);
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            (this.Parent as Grid).Children.Remove(this);
        }
    }
}
