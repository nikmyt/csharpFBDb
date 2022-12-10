using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
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

namespace WPF.MVVM.Elements
{
    /// <summary>
    /// Interaction logic for PetsStockPanel.xaml
    /// </summary>
    /// 


    public partial class PetsStockPanel : UserControl
    {
        //or i could do it by incrementing internal counter
        public int petid;
        public PetsStockPanel()
        {

            InitializeComponent();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //i could do it by elements number lol
        }
    }
}
