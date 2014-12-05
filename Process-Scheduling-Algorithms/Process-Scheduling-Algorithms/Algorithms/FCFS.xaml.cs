using System.Data;
using System.Dynamic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Xml;

namespace Process_Scheduling_Algorithms
{
    /// <summary>
    /// Interaction logic for FCFS.xaml
    /// </summary>
    public partial class FCFS : Window
    {
        private DataTable dt;

        public FCFS()
        {
            InitializeComponent();
            btnAddProcess.Click += btnAddProcess_Click;

            this.Loaded += (sender, e) =>
            {
                dgProcesses.SelectionMode           = DataGridSelectionMode.Single;
                dgProcesses.CanUserAddRows          = false;
                dgProcesses.CanUserDeleteRows       = true;
                dgProcesses.CanUserReorderColumns   = true;
                dgProcesses.CanUserResizeRows       = false;
                dgProcesses.CanUserReorderColumns   = false;
                dgProcesses.CanUserSortColumns      = false;
            };


            dt = new DataTable();
            dt.Columns.Add("Name  ");
            dt.Columns.Add("Burst Time");
            dt.Columns.Add("Arrival Time");

        }

        void btnAddProcess_Click(object sender, RoutedEventArgs e)
        {
            if (txtArrivelTime.Text != string.Empty &&
                txtBurstTime.Text != string.Empty &&
                txtProcessName.Text != string.Empty)
            {
                Process p = new Process(
                    txtProcessName.Text.ToString()
                    , 0
                    , int.Parse(txtBurstTime.Text.ToString())
                    , int.Parse(txtArrivelTime.Text.ToString()));
                //dgProcesses.Items.Add()
                //dgProcesses.Items.Insert(0, p);
                //DataTable dt = new DataTable();
                //dt.NewRow();
                //DataRow dr = dgProcesses.Rows
                //dt.Rows.Add(new DataRow());
                //dynamic row = new ExpandoObject();
                
                //dgProcesses.Items.Add(row);
                //dgProcesses.ItemsSource = dt.DefaultView;
                MessageBox.Show(p.Name);
                dt.Rows.Add(p.Name, p.BurstTime.ToString(), p.ArrivalTime);
                
                dgProcesses.ItemsSource = dt.DefaultView;
                dgProcesses.Columns[0].CanUserResize = false;
                dgProcesses.Columns[1].CanUserResize = false;
                dgProcesses.Columns[2].CanUserResize = false;
               // dgProcesses.Columns[0].Width = DataGridLength.SizeToHeader;
                dgProcesses.Columns[1].Width = DataGridLength.SizeToHeader;
                dgProcesses.Columns[2].Width = DataGridLength.SizeToHeader;
                dgProcesses.Items.Refresh();
                //UpdateEveryting();
            }
            else
            {
                MessageBox.Show("Fill All Fields!");
            }
        }

        //! TextBox'a sadece harf kabul eden Fonksiyon.
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
        }
    }
}
