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
    /// Interaction logic for CPUList.xaml
    /// </summary>
    public partial class CPUList : UserControl
    {
        public CPUList()
        {
            InitializeComponent();
            AccessoriesEntitiesBD db = new AccessoriesEntitiesBD();
            var products = from ProductName in db.Products select ProductName;
            this.Name.Text = products.ToString();
        }
        
    }
}
