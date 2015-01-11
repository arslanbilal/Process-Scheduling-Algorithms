using System.Windows;
using System.Windows.Input;
using Process_Scheduling_Algorithms.Classes;

namespace Process_Scheduling_Algorithms
{
    /// <summary>
    /// Interaction logic for SJF.xaml
    /// </summary>
    public partial class SJF : Window
    {
        private Graph _graph;
        public SJF()
        {
            InitializeComponent();
            _graph = new Graph(grdProcesses);
        }

        //! TextBox'a sadece harf kabul eden Fonksiyon.
        private void txt_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, e.Text.Length - 1))
            {
                e.Handled = true;
            }
        }

        private void BtnAddProcess_OnClick(object sender, RoutedEventArgs e)
        {
            _graph.AddProcess(int.Parse(txtBurstTime.Text), txtProcessName.Text, int.Parse(txtArrivalTime.Text));
        }
    }
}
