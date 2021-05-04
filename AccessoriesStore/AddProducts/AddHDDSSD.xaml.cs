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
    /// Interaction logic for AddHDDSSD.xaml
    /// </summary>
    public partial class AddHDDSSD : UserControl
    {
        public AddHDDSSD()
        {
            InitializeComponent();
        }

        private void AddHDDSSDButton_Click(object sender, RoutedEventArgs e)
        {
            //AccessoriesStoreDB db = new AccessoriesStoreDB();
            AccessoriesEntitiesBD db = new AccessoriesEntitiesBD();
            HDDSSD hddssd = new HDDSSD()
            {
                DiskType = comboBox_DiskType.Text,
                Volume = textBox_Vloume.Text,
                FormFactor = textBox_FormFactor.Text,
                Interface = textBox_Interface.Text,
                Bufer = textBox_Bufer.Text,
                SequentialReadSpeed = textBox_SequentiaReadSpeed.Text,
                SequentiaWriteSpeed = textBox_SequentiaWriteSpeed.Text
            };

            db.HDDSSDs.Add(hddssd);
            db.SaveChanges();

            (this.Parent as Grid).Children.Remove(this);
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            (this.Parent as Grid).Children.Remove(this);
        }
    }
}
