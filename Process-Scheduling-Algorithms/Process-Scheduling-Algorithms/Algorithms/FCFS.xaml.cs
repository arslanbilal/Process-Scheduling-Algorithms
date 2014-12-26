using System.Data;
using System.Dynamic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Xml;
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
        int index = 0;

        public FCFS()
        {
            InitializeComponent();

            _graph = new Graph(grdProcesses);
            
            btnAddProcess.Click += btnAddProcess_Click;



            this.Loaded += (sender, e) =>
            {
                dgProcesses.SelectionMode           = DataGridSelectionMode.Single;
                dgProcesses.CanUserAddRows          = false;
                dgProcesses.CanUserDeleteRows       = true;
                dgProcesses.CanUserResizeRows       = false;
                dgProcesses.CanUserReorderColumns   = false;
                dgProcesses.CanUserSortColumns      = false;
                dgProcesses.IsReadOnly              = true;
                dgProcesses.CanUserResizeColumns    = false;
            };


            dt = new DataTable();
            dt.Columns.Add("Name  ");
            dt.Columns.Add("Burst Time");
            dt.Columns.Add("Arrival Time");
            dgProcesses.ItemsSource = dt.DefaultView;

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
                    p = new Process(txtProcessName.Text, int.Parse(txtBurstTime.Text));
                }


                _graph.AddProcess(p.BurstTime, p.Name);

                MessageBox.Show(p.Name);

                dt.Rows.Add(p.Name.ToString(), p.BurstTime.ToString(), p.ArrivalTime.ToString());

                dgProcesses.ItemsSource = dt.DefaultView;
                dgProcesses.Items.Refresh();
                UpdateEveryting();
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

        void UpdateEveryting()
        {
            dgProcesses.SelectionMode = DataGridSelectionMode.Single;
            dgProcesses.CanUserAddRows = false;
            dgProcesses.CanUserDeleteRows = true;
            dgProcesses.CanUserReorderColumns = true;
            dgProcesses.CanUserResizeRows = false;
            dgProcesses.CanUserReorderColumns = false;
            dgProcesses.CanUserSortColumns = false;
            dgProcesses.IsReadOnly = true;
        }
    }
}
