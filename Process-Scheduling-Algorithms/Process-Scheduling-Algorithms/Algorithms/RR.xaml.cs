using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Process_Scheduling_Algorithms.Classes;

namespace Process_Scheduling_Algorithms
{
    public partial class RR : Window
    {
        private Graph _graph;
        private int timeQuantum;

        public RR()
        {
            InitializeComponent();
            _graph = new Graph(this.grdProcesses);
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
            /*TimeQuantum, Name, BurstTime*/

            if (timeQuantum == 0)
            {
                try
                {
                    timeQuantum = int.Parse(txtTimeQuantum.Text);
                }
                catch (System.Exception)
                {
                    MessageBox.Show("Where is my Time Quantum?");
                    return;
                }
            }

            var avg = _graph.AddProcessRR(txtProcessName.Text, int.Parse(txtBurstTime.Text), timeQuantum);

            txbDefaultWaiting.Text = string.Format("{0:##.00}", avg[0]);
            txbDefaultCompletion.Text = string.Format("{0:##.00}", avg[1]);
            var lst = ((List<string>)avg[2]);
            lstbProcessWaitingTimes.Items.Clear();
            for (int i = 0; i < lst.Count; i++)
                lstbProcessWaitingTimes.Items.Add(new ListBoxItem { Content = lst[i] });

            UpdateTimeInfos();
        }

        public void UpdateTimeInfos()
        {
            try
            {

                //var  = _graph.WaitingTimes(_graph.LstProcesses);
                var lst = _graph.LstProcesses.ToList();

                lstbProcesses.Items.Clear();
                for (int i = 0; i < lst.Count; i++)
                {
                    lstbProcesses.Items.Add(new ListBoxItem { Content = string.Format("{0} : {1}", lst[i].Name, lst[i].BurstTime) });
                }
            }
            catch (System.Exception)
            {

            }
        }

        private void BtnTimeQuantum_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                timeQuantum = int.Parse(txtTimeQuantum.Text);
            }
            catch (System.Exception)
            {
                MessageBox.Show("Where is my Time Quantum???");
            }
        }
    }
}
