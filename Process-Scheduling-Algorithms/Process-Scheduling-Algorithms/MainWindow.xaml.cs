using System;
using System.Windows;

namespace Process_Scheduling_Algorithms
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        #region COMBOBOX_ITEMS_ONSELECTED
        //TODO

        private void CbiFCFS_OnSelected(object sender, RoutedEventArgs e)
        {
            try
            {
                lblFCFS.Visibility = Visibility.Visible;
                lblPNP.Visibility = Visibility.Hidden;
                lblPP.Visibility = Visibility.Hidden;
                lblRR.Visibility = Visibility.Hidden;
                lblSJF.Visibility = Visibility.Hidden;
                lblSRTF.Visibility = Visibility.Hidden;
            }
            catch
            {

            }
        }

        private void CbiSJF_OnSelected(object sender, RoutedEventArgs e)
        {
            lblFCFS.Visibility = Visibility.Hidden;
            lblPNP.Visibility = Visibility.Hidden;
            lblPP.Visibility = Visibility.Hidden;
            lblRR.Visibility = Visibility.Hidden;
            lblSJF.Visibility = Visibility.Visible;
            lblSRTF.Visibility = Visibility.Hidden;
        }

        private void CbiSRTF_OnSelected(object sender, RoutedEventArgs e)
        {
            lblFCFS.Visibility = Visibility.Hidden;
            lblPNP.Visibility = Visibility.Hidden;
            lblPP.Visibility = Visibility.Hidden;
            lblRR.Visibility = Visibility.Hidden;
            lblSJF.Visibility = Visibility.Hidden;
            lblSRTF.Visibility = Visibility.Visible;
        }

        private void CbiPP_OnSelected(object sender, RoutedEventArgs e)
        {
            lblFCFS.Visibility = Visibility.Hidden;
            lblPNP.Visibility = Visibility.Hidden;
            lblPP.Visibility = Visibility.Visible;
            lblRR.Visibility = Visibility.Hidden;
            lblSJF.Visibility = Visibility.Hidden;
            lblSRTF.Visibility = Visibility.Hidden;
        }

        private void CbiPNP_OnSelected(object sender, RoutedEventArgs e)
        {
            lblFCFS.Visibility = Visibility.Hidden;
            lblPNP.Visibility = Visibility.Visible;
            lblPP.Visibility = Visibility.Hidden;
            lblRR.Visibility = Visibility.Hidden;
            lblSJF.Visibility = Visibility.Hidden;
            lblSRTF.Visibility = Visibility.Hidden;
        }

        private void CbiRR_OnSelected(object sender, RoutedEventArgs e)
        {
            lblFCFS.Visibility = Visibility.Hidden;
            lblPNP.Visibility = Visibility.Hidden;
            lblPP.Visibility = Visibility.Hidden;
            lblRR.Visibility = Visibility.Visible;
            lblSJF.Visibility = Visibility.Hidden;
            lblSRTF.Visibility = Visibility.Hidden;
        } 
        #endregion
    }
}
