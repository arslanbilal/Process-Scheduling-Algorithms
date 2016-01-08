#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

using Process_Scheduling_Algorithms.Classes;

#endregion

namespace Process_Scheduling_Algorithms {

    public partial class RR {
        private readonly Graph _graph;
        private int timeQuantum;

        public RR() {
            InitializeComponent();
            _graph = new Graph(this.grdProcesses);
        }

        //! TextBox'a sadece harf kabul eden Fonksiyon.
        private void txt_PreviewTextInput(object sender, TextCompositionEventArgs e) {
            if (!char.IsDigit(e.Text, e.Text.Length - 1)) {
                e.Handled = true;
            }
        }

        private void BtnAddProcess_OnClick(object sender, RoutedEventArgs e) {
            /*TimeQuantum, Name, BurstTime*/

            if (timeQuantum == 0) {
                try {
                    timeQuantum = int.Parse(txtTimeQuantum.Text);
                }
                catch (Exception) {
                    MessageBox.Show("Where is my Time Quantum?");
                    return;
                }
            }

            var avg = _graph.AddProcessRR(txtProcessName.Text, int.Parse(txtBurstTime.Text), timeQuantum);

            txbDefaultWaiting.Text = $"{avg[0]:##.00}";
            txbDefaultCompletion.Text = $"{avg[1]:##.00}";
            var lst = ( (List<string>) avg[2] );
            lstbProcessWaitingTimes.Items.Clear();
            for (var i = 0; i < lst.Count; i++) {
                lstbProcessWaitingTimes.Items.Add(
                    new ListBoxItem {
                                        Content = lst[i]
                                    });
            }

            UpdateTimeInfos();
        }

        private void btnClearAll_OnClick(object sender, RoutedEventArgs e)
        {
            var cleared = new RR();
            cleared.Show();
            this.Close();
        }

        public void UpdateTimeInfos() {
            try {
                //var  = _graph.WaitingTimes(_graph.LstProcesses);
                var lst = _graph.LstProcesses.ToList();

                lstbProcesses.Items.Clear();
                for (var i = 0; i < lst.Count; i++) {
                    lstbProcesses.Items.Add(
                        new ListBoxItem {
                                            Content = string.Format("{0} : {1}", lst[i].Name, lst[i].BurstTime)
                                        });
                }
            }
            catch (Exception) { }
        }

        private void BtnTimeQuantum_OnClick(object sender, RoutedEventArgs e) {
            try {
                timeQuantum = int.Parse(txtTimeQuantum.Text);
            }
            catch (Exception) {
                MessageBox.Show("Where is my Time Quantum???");
            }
        }
    }

}