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
    /// Interaction logic for AddMotherboard.xaml
    /// </summary>
    public partial class AddMotherboard : UserControl
    {
        public AddMotherboard()
        {
            InitializeComponent();
        }

        private void AddMBButton_Click(object sender, RoutedEventArgs e)
        {
            //AccessoriesStoreDB db = new AccessoriesStoreDB();
            AccessoriesEntitiesBD db = new AccessoriesEntitiesBD();
            Motherboard motherboard = new Motherboard()
            {
                ProcessorSupport = comboBox_ProcessorSupport.Text,
                Socket = textBox_Socket.Text,
                Chipset = textBox_Chipset.Text,
                FormFactor = textBox_FormFactor.Text,
                MemoryType = textBox_MemoryType.Text,
                NumberMemorySlots = textBox_NumberMemorySlots.Text,
                MaximumMemorySize = textBox_MaxMemorySize.Text,
                MemoryMode = textBox_MemoryMode.Text,
                MaximumMemoryFrequency = textBox_MaxMemoryFrequency.Text,
                StorageInterfaces = textBox_StorageInterfaces.Text,
                NetworkAndCommunication = textBox_NetworkAndCommunication.Text,
                AudioAndVideo = textBox_AudioAndVideo.Text,
                RearPanelConnectors = textBox_RearPanelConnectors.Text,
                InternalConnectors = textBox_InternalConnectors.Text,
                OverallDimensions = textBox_OveralDimensions.Text
            };

            db.Motherboards.Add(motherboard);
            db.SaveChanges();

            (this.Parent as Grid).Children.Remove(this);
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            (this.Parent as Grid).Children.Remove(this);
        }
    }
}
