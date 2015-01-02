using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Process_Scheduling_Algorithms.Classes;

namespace Process_Scheduling_Algorithms
{
    /// <summary>
    /// Interaction logic for FCFS.xaml
    /// </summary>
    public partial class FCFS : Window
    {
        private DataTable dt;
        private Graph _graph;

        public FCFS()
        {
            InitializeComponent();

            _graph = new Graph(grdProcesses);
            
            btnAddProcess.Click += btnAddProcess_Click;

        }

        void btnAddProcess_Click(object sender, RoutedEventArgs e)
        {
            if ((txtArrivalTime.Text != string.Empty || cbOrderArrivalTime.IsChecked == false) &&
                txtBurstTime.Text != string.Empty &&
                txtProcessName.Text != string.Empty)
            {
                Process p;
                
                if (cbOrderArrivalTime.IsChecked == true)
                {
                    p = new Process(
                    txtProcessName.Text
                    , 0
                    , int.Parse(txtBurstTime.Text)
                    , int.Parse(txtArrivalTime.Text));
                }
                else
                {
                    //int burstTime
                    p = new Process(txtProcessName.Text, int.Parse(txtBurstTime.Text));
                }

                _graph.AddProcess(p.BurstTime, p.Name);
                this.UpdateTimeInfos();
            }
            else
            {
                MessageBox.Show("Fill All Fields!");
            }
        }

        //! TextBox is only numbers.
        private void txt_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, e.Text.Length - 1))
            {
                e.Handled = true;

            }
        }

        private void ToggleButton_OnChecked(object sender, RoutedEventArgs e)
        {
            try
            {
                UpdateTimeInfos();
            }
            catch (System.Exception)
            {
                
            }
        }

        public void UpdateTimeInfos()
        {
            txbDefaultWaiting.Text = string.Format("{0:##.00}", _graph.AverageWaitingTime(_graph.LstProcesses));
            txbDefaultCompletion.Text = string.Format("{0:##.00}", _graph.AverageCompletionTime(_graph.LstProcesses));

            var lst = _graph.OrderByBestCase();
            txbBestWaiting.Text = string.Format("{0:##.00}", _graph.AverageWaitingTime(lst));
            txbBestCompletion.Text = string.Format("{0:##.00}", _graph.AverageCompletionTime(lst));

            lst = _graph.OrderByWorstCase();
            txbWorstWaiting.Text = string.Format("{0:##.00}", _graph.AverageWaitingTime(lst));
            txbWorstCompletion.Text = string.Format("{0:##.00}", _graph.AverageCompletionTime(lst));

            if (rbDefault.IsChecked == true)
            {
                try
                {
                    _graph.OrderByDefaultCase();
                    var waitingTimes = _graph.WaitingTimes(_graph.LstProcesses);
                    lstbProcessWaitingTimes.Items.Clear();
                    for (int i = 0; i < waitingTimes.Length; i++)
                    {
                        lstbProcessWaitingTimes.Items.Add(new ListBoxItem { Content = waitingTimes[i] });
                    }
                }
                catch (System.Exception)
                {

                }
            }
            else if (rbBestCase.IsChecked == true)
            {
                lst = _graph.OrderByBestCase();
                var waitingTimes = _graph.WaitingTimes(lst);
                lstbProcessWaitingTimes.Items.Clear();
                for (int i = 0; i < waitingTimes.Length; i++)
                {
                    lstbProcessWaitingTimes.Items.Add(new ListBoxItem { Content = waitingTimes[i] });
                }
            }
            else if (rbWorstCase.IsChecked == true)
            {
                lst = _graph.OrderByWorstCase();
                var waitingTimes = _graph.WaitingTimes(lst);
                lstbProcessWaitingTimes.Items.Clear();
                for (int i = 0; i < waitingTimes.Length; i++)
                {
                    lstbProcessWaitingTimes.Items.Add(new ListBoxItem { Content = waitingTimes[i] });
                }
            }
        }
    }
}
