#region

using System.Windows;

#endregion

namespace Process_Scheduling_Algorithms {

    public partial class MainWindow {
        public MainWindow() {
            InitializeComponent();
        }

        private void BtnGO_OnClick(object sender, RoutedEventArgs e) {
            if (cbiFCFS.IsSelected) {
                var fcfs = new Fcfs();
                fcfs.Tag = this;
                fcfs.Show();
            }
            else if (cbiPNP.IsSelected) {
                var pnp = new PNP();
                pnp.Tag = this;
                pnp.Show();
            }
            else if (cbiPP.IsSelected) {
                var pp = new PP();
                pp.Tag = this;
                pp.Show();
            }
            else if (cbiRR.IsSelected) {
                var rr = new RR();
                rr.Tag = this;
                rr.Show();
            }
            else if (cbiSJF.IsSelected) {
                var sjf = new SJF();
                sjf.Tag = this;
                sjf.Show();
            }
            else if (cbiSRTF.IsSelected) {
                var srtf = new SRTF();
                srtf.Tag = this;
                srtf.Show();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {
            lblFCFS.Content = "First-Come First-Serve(FCFS)\n\n"
                              + "1) Policy: Process that requests the CPU FIRST is allocated the CPU FIRST.\n" +
                              "2) FCFS is a non-preemptive algorithm.\n" +
                              "3) Implementation - using FIFO queues. Incoming process is added to the tail of the \nqueue. Process selected for execution is taken from head of queue.\n"
                              +
                              "4) Performance metric - Average waiting time in queue.\n";

            lblPNP.Content = "Priority-Nonpreemptive\n\n" +
                             "1) A priority value (integer) is associated with each process. \nCan be based on:\n" +
                             "\t # Cost to user\n" +
                             "\t # Importance to user\n" +
                             "\t # Aging\n" +
                             "\t # %CPU time used in last X hours.\n" +
                             "2) CPU is allocated to process with the highest priority.\n" +
                             "\t # Preemptive\n" +
                             "\t # Nonpreemptive\n" +
                             "3) SJN is a priority scheme where the priority is the predicted next CPU burst time.\n" +
                             "4) Problem:\n" +
                             "\t # Starvation!! - Low priority processes may never execute.\n" +
                             "5) Solution:\n" +
                             "\t # Aging - as time progresses increase the priority of the process.\n";

            lblPP.Content = "Priority-Preemptive\n\n" +
                            "1) A priority value (integer) is associated with each process. \nCan be based on:\n" +
                            "\t # Cost to user\n" +
                            "\t # Importance to user\n" +
                            "\t # Aging\n" +
                            "\t # %CPU time used in last X hours.\n" +
                            "2) CPU is allocated to process with the highest priority.\n" +
                            "\t # Preemptive\n" +
                            "\t # Nonpreemptive\n" +
                            "3) SJN is a priority scheme where the priority is the predicted next CPU burst time.\n" +
                            "4) Problem:\n" +
                            "\t # Starvation!! - Low priority processes may never execute.\n" +
                            "5) Solution:\n" +
                            "\t # Aging - as time progresses increase the priority of the process.\n";

            lblRR.Content = "Round-Robin\n\n" +
                            "Each process gets a small unit of CPU time:\n" +
                            "\t # Time quantum usually 10-100 milliseconds.\n" +
                            "\t # After this time has elapsed, the process is preempted and added to the end \nof the ready queue.\n"
                            +
                            "\t # n processes, time quantum = q:\n" +
                            "\t\t # Each process gets 1/n CPU time in chunks of at most q time units \nat a time.\n" +
                            "\t\t # No process waits more than (n-1)q time units. 3.Performance:\n" +
                            "\t\t\t # Time slice q too large – response time poor\n" +
                            "\t\t\t # Time slice (infinity)? - reduces to FIFO behavior\n" +
                            "\t\t\t # Time slice q too small - Overhead of context switch is too \nexpensive. Throughput poor\n";

            lblSJF.Content = "Shortest Job First(SJF)\n\n" +
                             "1) Associate with each process the length of its next CPU burst.\n" +
                             "2) Use these lengths to schedule the process with the shortest time.\n" +
                             //"3) Two Schemes:\n" +
                             //"Scheme 1: Non-preemptive\n" +
                             "Scheme : Non-preemptive\n" +
                             "\t # Once CPU is given to the process it cannot be preempted until it completes \nits CPU burst.\n";
            //"Scheme 2: Preemptive\n" +
            //"\t # If a new CPU process arrives with CPU burst length less than remaining time \nof current executing process, preempt.\n" +
            //"\t # Also called Shortest-Remaining-Time-First (SRTF).. ";

            lblSRTF.Content = "Shortest Remaining Time First(SRTF)\n\n" +
                              "1) Associate with each process the length of its next CPU burst.\n" +
                              "2) Use these lengths to schedule the process with the shortest time.\n" +
                              //"3) Two Schemes:\n" +
                              //"Scheme 1: Non-preemptive\n" +
                              //"\t # Once CPU is given to the process it cannot be preempted until it completes \nits CPU burst.\n" +
                              //"Scheme 2: Preemptive\n" +
                              "Scheme : Preemptive\n" +
                              "\t # If a new CPU process arrives with CPU burst length less than remaining time \nof current executing process, preempt.\n"
                              +
                              "\t # Also called Shortest-Remaining-Time-First (SRTF).. ";
        }

        #region COMBOBOX_ITEMS_ONSELECTED

        //TODO

        private void CbiFCFS_OnSelected(object sender, RoutedEventArgs e) {
            try {
                lblFCFS.Visibility = Visibility.Visible;
                lblPNP.Visibility = Visibility.Hidden;
                lblPP.Visibility = Visibility.Hidden;
                lblRR.Visibility = Visibility.Hidden;
                lblSJF.Visibility = Visibility.Hidden;
                lblSRTF.Visibility = Visibility.Hidden;
            }
            catch { }
        }

        private void CbiSJF_OnSelected(object sender, RoutedEventArgs e) {
            lblFCFS.Visibility = Visibility.Hidden;
            lblPNP.Visibility = Visibility.Hidden;
            lblPP.Visibility = Visibility.Hidden;
            lblRR.Visibility = Visibility.Hidden;
            lblSJF.Visibility = Visibility.Visible;
            lblSRTF.Visibility = Visibility.Hidden;
        }

        private void CbiSRTF_OnSelected(object sender, RoutedEventArgs e) {
            lblFCFS.Visibility = Visibility.Hidden;
            lblPNP.Visibility = Visibility.Hidden;
            lblPP.Visibility = Visibility.Hidden;
            lblRR.Visibility = Visibility.Hidden;
            lblSJF.Visibility = Visibility.Hidden;
            lblSRTF.Visibility = Visibility.Visible;
        }

        private void CbiPP_OnSelected(object sender, RoutedEventArgs e) {
            lblFCFS.Visibility = Visibility.Hidden;
            lblPNP.Visibility = Visibility.Hidden;
            lblPP.Visibility = Visibility.Visible;
            lblRR.Visibility = Visibility.Hidden;
            lblSJF.Visibility = Visibility.Hidden;
            lblSRTF.Visibility = Visibility.Hidden;
        }

        private void CbiPNP_OnSelected(object sender, RoutedEventArgs e) {
            lblFCFS.Visibility = Visibility.Hidden;
            lblPNP.Visibility = Visibility.Visible;
            lblPP.Visibility = Visibility.Hidden;
            lblRR.Visibility = Visibility.Hidden;
            lblSJF.Visibility = Visibility.Hidden;
            lblSRTF.Visibility = Visibility.Hidden;
        }

        private void CbiRR_OnSelected(object sender, RoutedEventArgs e) {
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