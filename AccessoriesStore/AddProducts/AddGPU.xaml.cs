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
    /// Interaction logic for AddGPU.xaml
    /// </summary>
    public partial class AddGPU : UserControl
    {
        public AddGPU()
        {
            InitializeComponent();
        }

        private void AddGPUButton_Click(object sender, RoutedEventArgs e)
        {
            //AccessoriesStoreDB db = new AccessoriesStoreDB();
            AccessoriesEntitiesBD db = new AccessoriesEntitiesBD();
            GPU gpu = new GPU()
            {
                GPUInterface = textBox_GPUInterface.Text,
                GPUManufacturer = comboBox_GPUManufacturer.Text,
                GraphicsProcessor = textBox_GraphicsProcessor.Text,
                GPUFrequency = textBox_GPUFrequency.Text,
                GPUTurboFrequency = textBox_GPUTurboFrequency.Text,
                NumberStreamProcessors = textBox_NumberStreamProcessors.Text,
                VideoMemory = textBox_VideoMemory.Text,
                VideoMemoryType = textBox_VideoMemoryType.Text,
                EffectiveMemoryFrequency = textBox_EffectiveMemoryFrequency.Text,
                MemoryBandwidth = textBox_MemoryBandwidth.Text,
                MemoryBusWidth = textBox_MemoryBusWidth.Text,
                DirectXSupport = textBox_DirectXSupport.Text,
                PowerConnectors = textBox_PowerConnectors.Text,
                RecommendedPowerSupply = textBox_RecommendedPowerSupply.Text,
                Cooling = textBox_Cooling.Text,
                NumberFans = textBox_NumberFans.Text,
                VideoCardDimensions = textBox_VideoCardDimensions.Text,
                Interfaces = textBox_Interfaces.Text
            };

            db.GPUs.Add(gpu);
            db.SaveChanges();

            (this.Parent as Grid).Children.Remove(this);
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            (this.Parent as Grid).Children.Remove(this);
        }
    }
}
