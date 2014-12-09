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
using System.Windows.Shapes;

namespace Process_Scheduling_Algorithms
{
    /// <summary>
    /// Interaction logic for PNP.xaml
    /// </summary>
    public partial class PNP : Window
    {
        public PNP()
        {
            InitializeComponent();
        }

        //! TextBox'a sadece harf kabul eden Fonksiyon.
        private void txt_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, e.Text.Length - 1))
            {
                e.Handled = true;

            }
        }
    }
}
