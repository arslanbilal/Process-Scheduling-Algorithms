#region

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

#endregion

namespace Process_Scheduling_Algorithms.Classes {

    internal class Graph {
        private Grid grdLines;
        private Grid grdProcessesTimes;
        private ProgressBar pbar;
        private Grid Parent { get; }
        private int Count { get; set; }
        private int Sum { get; set; }
        public List<Process> LstProcesses { get; set; }

        public Graph(Grid parent) {
            Parent = parent;
            LstProcesses = new List<Process>();

            pbar = new ProgressBar {
                                       Value = 0,
                                       Height = 42,
                                       VerticalAlignment = VerticalAlignment.Top,
                                       Background = Brushes.CornflowerBlue
                                   };
            parent.Children.Add(pbar);

            grdLines = new Grid {
                                    Height = 50,
                                    VerticalAlignment = VerticalAlignment.Top
                                };
            BeginDrawLineToGrid();
            parent.Children.Add(grdLines);

            grdProcessesTimes = new Grid();
            BeginWriteProcessTimesToGrid();
            parent.Children.Add(grdProcessesTimes);

            //grdLines.ShowGridLines = true;
            //grdProcessesTimes.ShowGridLines = true;
        }

        private void ctorGraph() {
            pbar = new ProgressBar {
                                       Value = 0,
                                       Height = 42,
                                       VerticalAlignment = VerticalAlignment.Top
                                   };
            Parent.Children.Add(pbar);

            grdLines = new Grid {
                                    Height = 50,
                                    VerticalAlignment = VerticalAlignment.Top
                                };
            BeginDrawLineToGrid();
            Parent.Children.Add(grdLines);

            grdProcessesTimes = new Grid();
            BeginWriteProcessTimesToGrid();
            Parent.Children.Add(grdProcessesTimes);
        }

        /// <summary>
        ///     Verilen gride processler ilk zaman cizgisini '0' (sifir)i cizer
        /// </summary>
        private void BeginDrawLineToGrid() {
            var line = GiveMeALine();
            Grid.SetColumn(line, 0);
            grdLines.Children.Add(line);

            grdLines.ColumnDefinitions.Add(
                new ColumnDefinition {
                                         Width = new GridLength(0, GridUnitType.Star)
                                     });
        }

        /// <summary>
        ///     Processlerin baslangic zamani olan sifir rakamini cizginin altina yazar
        /// </summary>
        private void BeginWriteProcessTimesToGrid() {
            grdProcessesTimes.Margin = new Thickness(-8, -8, 8, 0);
            grdProcessesTimes.ColumnDefinitions.Add(
                new ColumnDefinition {
                                         Width = new GridLength(0, GridUnitType.Star)
                                     });
            var lblZero = new Label {
                                        Margin = new Thickness(0, 45, 0, 0),
                                        Content = 0,
                                        FontWeight = FontWeights.Bold,
                                        HorizontalContentAlignment = HorizontalAlignment.Left,
                                        HorizontalAlignment = HorizontalAlignment.Left,
                                        VerticalAlignment = VerticalAlignment.Top
                                    };
            grdProcessesTimes.Children.Add(lblZero);
        }

        private void AddProcessForCases(int burstTime, string name, int count, int sum) {
            grdLines.ColumnDefinitions[count].Width = new GridLength(burstTime, GridUnitType.Star);
            //grdLines.ColumnDefinitions[_count].Width = new GridLength(burstTime - lastEndTime, GridUnitType.Star);

            // bir onceki columdefinition un Width ni ayarlayip(GridUnitType.Star oldugu icin yuzdelik olarak ayarlar) _count'u bir artirir.
            grdProcessesTimes.ColumnDefinitions[count].Width = new GridLength(burstTime, GridUnitType.Star);
            //grdProcessesTimes.ColumnDefinitions[_count].Width = new GridLength(burstTime - lastEndTime, GridUnitType.Star);

            //column definition ekleme islemi
            grdLines.ColumnDefinitions.Add(
                new ColumnDefinition {
                                         Width = new GridLength(30, GridUnitType.Pixel)
                                     });
            //grdLines.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(10, GridUnitType.Pixel) });
            grdProcessesTimes.ColumnDefinitions.Add(
                new ColumnDefinition {
                                         Width = new GridLength(30, GridUnitType.Pixel)
                                     });
            //grdProcessesTimes.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(10, GridUnitType.Pixel) });

            var tbProcess = new TextBlock {
                                              Margin = new Thickness(8, 18, -8, 0),
                                              Text = string.Format("{0}({1})", name, burstTime),
                                              FontWeight = FontWeights.ExtraBold,
                                              Height = 42,
                                              Background = Brushes.Transparent,
                                              Foreground = Brushes.YellowGreen,
                                              VerticalAlignment = VerticalAlignment.Top,
                                              TextAlignment = TextAlignment.Center
                                              //, BorderThickness = new Thickness(0)
                                          };
            Grid.SetColumn(tbProcess, count);
            grdProcessesTimes.Children.Add(tbProcess);

            //yeni line ekleme islemi
            var line = GiveMeALine();
            Grid.SetColumn(line, count + 1);
            var lblBackGround = new Label {
                                              Background = count % 2 == 0 ? Brushes.CornflowerBlue : Brushes.RoyalBlue,
                                              VerticalAlignment = VerticalAlignment.Top,
                                              Height = 42
                                          };
            grdLines.Children.Add(lblBackGround);
            Grid.SetColumn(lblBackGround, count);
            grdLines.Children.Add(line);

            var lblProcess = new Label {
                                           Margin = new Thickness(0, 45, 0, 0),
                                           Content = sum,
                                           //Background = _count % 2 == 0 ? Brushes.Transparent : Brushes.LightSlateGray,
                                           HorizontalContentAlignment = HorizontalAlignment.Left,
                                           FontWeight = FontWeights.Bold,
                                           HorizontalAlignment = HorizontalAlignment.Left,
                                           VerticalAlignment = VerticalAlignment.Top
                                       };
            Grid.SetColumn(lblProcess, count + 1);
            grdProcessesTimes.Children.Add(lblProcess);
        }

        /// <summary>
        ///     processin bitis zamanina gore yeni process ekler
        /// </summary>
        /// <param name="burstTime">process bitis zamani</param>
        /// <param name="name">process adi</param>
        public void AddProcess(int burstTime, string name) {
            LstProcesses.Add(new Process(name, burstTime));

            //bu process icin onceki columndefinitionun genisligini ayarlanmasi
            grdLines.ColumnDefinitions[Count].Width = new GridLength(burstTime, GridUnitType.Star);

            // bir onceki columdefinition un Width ni ayarlayip(GridUnitType.Star oldugu icin yuzdelik olarak ayarlar) _count'u bir artirir.
            grdProcessesTimes.ColumnDefinitions[Count].Width = new GridLength(burstTime, GridUnitType.Star);

            //column definition ekleme islemi
            grdLines.ColumnDefinitions.Add(
                new ColumnDefinition {
                                         Width = new GridLength(30, GridUnitType.Pixel)
                                     });
            grdProcessesTimes.ColumnDefinitions.Add(
                new ColumnDefinition {
                                         Width = new GridLength(30, GridUnitType.Pixel)
                                     });

            /*process adinin yazimi*/
            var tbProcess = new TextBlock {
                                              Margin = new Thickness(8, 18, -8, 0),
                                              Text = string.Format("{0}({1})", name, burstTime),
                                              FontWeight = FontWeights.Bold,
                                              Height = 42,
                                              Background = Brushes.Transparent,
                                              VerticalAlignment = VerticalAlignment.Top,
                                              TextAlignment = TextAlignment.Center
                                              //, BorderThickness = new Thickness(0)
                                          };
            Grid.SetColumn(tbProcess, Count);
            grdProcessesTimes.Children.Add(tbProcess);

            //yeni line ekleme islemi
            var line = GiveMeALine();
            Grid.SetColumn(line, Count + 1);
            /*processlerin arka renginin ayarlanmasi*/
            var lblBackGround = new Label {
                                              Background = Count % 2 == 0 ? Brushes.CornflowerBlue : Brushes.RoyalBlue,
                                              VerticalAlignment = VerticalAlignment.Top,
                                              Height = 42
                                          };
            grdLines.Children.Add(lblBackGround);
            Grid.SetColumn(lblBackGround, Count);
            grdLines.Children.Add(line);

            Sum += burstTime;

            /*proceslerin bitis surelerinin ayarlanmasi*/
            var lblProcess = new Label {
                                           Margin = new Thickness(0, 45, 0, 0),
                                           Content = Sum,
                                           //Background = _count % 2 == 0 ? Brushes.Transparent : Brushes.LightSlateGray,
                                           HorizontalContentAlignment = HorizontalAlignment.Left,
                                           FontWeight = FontWeights.Bold,
                                           HorizontalAlignment = HorizontalAlignment.Left,
                                           VerticalAlignment = VerticalAlignment.Top
                                       };
            Grid.SetColumn(lblProcess, Count + 1);
            grdProcessesTimes.Children.Add(lblProcess);

            Count++;
        }

        public void AddProcessWithoutAddList(int burstTime, string name) {
            //bu process icin onceki columndefinitionun genisligini ayarlanmasi
            grdLines.ColumnDefinitions[Count].Width = new GridLength(burstTime, GridUnitType.Star);

            // bir onceki columdefinition un Width ni ayarlayip(GridUnitType.Star oldugu icin yuzdelik olarak ayarlar) _count'u bir artirir.
            grdProcessesTimes.ColumnDefinitions[Count].Width = new GridLength(burstTime, GridUnitType.Star);

            //column definition ekleme islemi
            grdLines.ColumnDefinitions.Add(
                new ColumnDefinition {
                                         Width = new GridLength(30, GridUnitType.Pixel)
                                     });
            grdProcessesTimes.ColumnDefinitions.Add(
                new ColumnDefinition {
                                         Width = new GridLength(30, GridUnitType.Pixel)
                                     });

            /*process adinin yazimi*/
            var tbProcess = new TextBlock {
                                              Margin = new Thickness(8, 18, -8, 0),
                                              Text = string.Format("{0}({1})", name, burstTime),
                                              FontWeight = FontWeights.Bold,
                                              Height = 42,
                                              Background = Brushes.Transparent,
                                              VerticalAlignment = VerticalAlignment.Top,
                                              TextAlignment = TextAlignment.Center
                                              //, BorderThickness = new Thickness(0)
                                          };
            Grid.SetColumn(tbProcess, Count);
            grdProcessesTimes.Children.Add(tbProcess);

            //yeni line ekleme islemi
            var line = GiveMeALine();
            Grid.SetColumn(line, Count + 1);
            /*processlerin arka renginin ayarlanmasi*/
            var lblBackGround = new Label {
                                              Background = Count % 2 == 0 ? Brushes.CornflowerBlue : Brushes.RoyalBlue,
                                              VerticalAlignment = VerticalAlignment.Top,
                                              Height = 42
                                          };
            grdLines.Children.Add(lblBackGround);
            Grid.SetColumn(lblBackGround, Count);
            grdLines.Children.Add(line);

            Sum += burstTime;

            /*proceslerin bitis surelerinin ayarlanmasi*/
            var lblProcess = new Label {
                                           Margin = new Thickness(0, 45, 0, 0),
                                           Content = Sum,
                                           //Background = _count % 2 == 0 ? Brushes.Transparent : Brushes.LightSlateGray,
                                           HorizontalContentAlignment = HorizontalAlignment.Left,
                                           FontWeight = FontWeights.Bold,
                                           HorizontalAlignment = HorizontalAlignment.Left,
                                           VerticalAlignment = VerticalAlignment.Top
                                       };
            Grid.SetColumn(lblProcess, Count + 1);
            grdProcessesTimes.Children.Add(lblProcess);

            Count++;
        }

        public void AddProcess(string name, int endTime, bool isRed, int sum) {
            grdLines.ColumnDefinitions[Count].Width = new GridLength(endTime, GridUnitType.Star);

            grdProcessesTimes.ColumnDefinitions[Count].Width = new GridLength(endTime, GridUnitType.Star);

            grdLines.ColumnDefinitions.Add(
                new ColumnDefinition {
                                         Width = new GridLength(30, GridUnitType.Pixel)
                                     });

            grdProcessesTimes.ColumnDefinitions.Add(
                new ColumnDefinition {
                                         Width = new GridLength(30, GridUnitType.Pixel)
                                     });

            var line = GiveMeALine();
            Grid.SetColumn(line, Count + 1);
            var lblBackGround = GiveMeALabel(isRed);
            grdLines.Children.Add(lblBackGround);
            Grid.SetColumn(lblBackGround, Count);
            grdLines.Children.Add(line);

            var tbProcess = new TextBlock {
                                              Margin = new Thickness(8, 18, -8, 0),
                                              Text = string.Format("{0}({1})", name, endTime),
                                              FontWeight = FontWeights.Bold,
                                              Height = 42,
                                              Background = Brushes.Transparent,
                                              VerticalAlignment = VerticalAlignment.Top,
                                              TextAlignment = TextAlignment.Center
                                              //, BorderThickness = new Thickness(0)
                                          };
            Grid.SetColumn(tbProcess, Count);
            grdProcessesTimes.Children.Add(tbProcess);

            var lblProcess = new Label {
                                           Margin = new Thickness(0, 45, 0, 0),
                                           Content = sum,
                                           //Background = _count % 2 == 0 ? Brushes.Transparent : Brushes.LightSlateGray,
                                           HorizontalContentAlignment = HorizontalAlignment.Left,
                                           FontWeight = FontWeights.Bold,
                                           HorizontalAlignment = HorizontalAlignment.Left,
                                           VerticalAlignment = VerticalAlignment.Top
                                       };

            Grid.SetColumn(lblProcess, Count + 1);
            grdProcessesTimes.Children.Add(lblProcess);

            Count++;
        }

        public void AddProcess(int burstTime, string name, int arrivalTime) {
            Parent.Children.Clear();
            ctorGraph();
            LstProcesses.Add(new Process(name, burstTime, arrivalTime));

            var lstTemp = this.SortForArrivalTime();

            var lastEndTime = 0;
            var currentTime = 0;
            Count = 0;
            for (var i = 0; i < lstTemp.Count; i++) {
                //if (!lstTemp[i].IsPlotted)
                //{
                if (lastEndTime < lstTemp[i].ArrivalTime) {
                    lastEndTime += lstTemp[i].ArrivalTime;
                    AddProcess("", lstTemp[i].ArrivalTime, true, lastEndTime);
                }
                AddProcess(lstTemp[i].Name, lstTemp[i].BurstTime, false, lastEndTime);
                lstTemp[i].IsPlotted = true;
                //}
                lastEndTime += lstTemp[i].BurstTime;
            }
        }

        private Label GiveMeALabel(bool isRed) {
            var lblBackGround = new Label {
                                              Background = Count % 2 == 0 ? Brushes.CornflowerBlue : Brushes.RoyalBlue,
                                              VerticalAlignment = VerticalAlignment.Top,
                                              Height = 42
                                          };

            if (isRed) {
                lblBackGround.Background = Brushes.Red;
            }

            return lblBackGround;
        }

        public int ProcessesCount() {
            return Count + 1;
        }

        /// <summary>
        ///     Yukaridan asagiya dogru duzgun siyah bir cizgi dondurur
        /// </summary>
        /// <returns></returns>
        private Path GiveMeALine() {
            // Create a blue and a black Brush
            //SolidColorBrush blueBrush = new SolidColorBrush {Color = Colors.Blue};
            var blackBrush = new SolidColorBrush {
                                                     Color = Colors.Black
                                                 };

            // Create a Path with black brush and blue fill
            //Path bluePath = new Path { Stroke = blackBrush, StrokeThickness = 3, Fill = blueBrush };
            var bluePath = new Path {
                                        Stroke = blackBrush,
                                        StrokeThickness = 3
                                    };

            // Create a line geometry
            var blackLineGeometry = new LineGeometry {
                                                         StartPoint = new Point(0, 1),
                                                         EndPoint = new Point(0, 42)
                                                     };

            // Add all the geometries to a GeometryGroup.
            var blueGeometryGroup = new GeometryGroup();
            blueGeometryGroup.Children.Add(blackLineGeometry);

            // Set Path.Data
            bluePath.Data = blueGeometryGroup;
            //grdBase.Children.Add(bluePath);
            return bluePath;
        }

        private List<Process> SortForPriority() {
            var lst = LstProcesses.ToList();

            for (var i = 0; i < lst.Count - 1; i++) {
                for (var j = 1; j < lst.Count - i; j++) {
                    if (lst[j].CompareToPriority(lst[j - 1]) == -1) {
                        var temp = lst[j];
                        lst[j] = lst[j - 1];
                        lst[j - 1] = temp;
                    }
                }
            }
            return lst;
        }

        private List<Process> SortForBurstTime(bool mintomax) {
            var lst = LstProcesses.ToList();

            for (var i = 0; i < lst.Count - 1; i++) {
                for (var j = 1; j < lst.Count - i; j++) {
                    if (mintomax) {
                        if (lst[j].CompareToBurstTime(lst[j - 1]) == -1) {
                            var temp = lst[j];
                            lst[j] = lst[j - 1];
                            lst[j - 1] = temp;
                        }
                    }
                    else {
                        if (lst[j].CompareToBurstTime(lst[j - 1]) == 1) {
                            var temp = lst[j];
                            lst[j] = lst[j - 1];
                            lst[j - 1] = temp;
                        }
                    }
                }
            }
            return ( lst );
        }

        private List<Process> SortForArrivalTime() {
            var lst = LstProcesses.ToList();

            for (var i = 0; i < lst.Count - 1; i++) {
                for (var j = 1; j < lst.Count - i; j++) {
                    if (lst[j].CompareToArrivalTime(lst[j - 1]) == -1) {
                        var temp = lst[j];
                        lst[j] = lst[j - 1];
                        lst[j - 1] = temp;
                    }
                }
            }
            return lst;
        }

        private int SumOfBurstTimes() {
            return LstProcesses.Sum(lstProcess => lstProcess.BurstTime);
        }

        #region RR

        public ArrayList AddProcessRR(string name, int burstTime, int timeQuantum) {
            Parent.Children.Clear();
            ctorGraph();

            LstProcesses.Add(new Process(name, burstTime));
            var lstTemp = new Process[LstProcesses.Count];
            for (var j = 0; j < LstProcesses.Count; j++) {
                lstTemp[j] = new Process(LstProcesses[j].Name, LstProcesses[j].BurstTime);
            }
            //LstProcesses.
            //LstProcesses.CopyTo(lstTemp);

            //var lstTemp = LstProcesses.ToList();

            var isZero = false;
            Sum = 0;
            Count = 0;

            var Waitingtime = 0;

            //TODO waiting times
            while (isZero == false) {
                isZero = true;

                for (var i = 0; i < lstTemp.Length; i++) {
                    var t = lstTemp[i];
                    if (t.BurstTime == 0) {
                        continue;
                    }
                    t.WaitingTime += Sum - t.LastEndTime;

                    if (t.BurstTime < timeQuantum) {
                        //t.WaitingTime += Sum - t.LastEndTime;

                        AddProcessWithoutAddList(t.BurstTime, t.Name);
                        t.LastEndTime = Sum;
                        t.BurstTime = 0;
                    }
                    else {
                        //t.WaitingTime += Sum - t.LastEndTime;
                        AddProcessWithoutAddList(timeQuantum, t.Name);
                        t.BurstTime -= timeQuantum;
                        t.LastEndTime = Sum;
                        isZero = false;
                    }
                }
            }

            float avgOfWaitingTimes = 0;
            for (var i = 0; i < lstTemp.Length; i++) {
                avgOfWaitingTimes += lstTemp[i].WaitingTime;
            }
            avgOfWaitingTimes /= lstTemp.Length;

            float avgCompletionTimes = 0;
            for (var i = 0; i < lstTemp.Length; i++) {
                avgCompletionTimes += lstTemp[i].LastEndTime;
            }
            avgCompletionTimes /= lstTemp.Length;

            var al = new ArrayList();

            al.Add(avgOfWaitingTimes);
            al.Add(avgCompletionTimes);

            var lst = new List<string>(lstTemp.Length);

            for (var i = 0; i < lstTemp.Length; i++) {
                lst.Add(string.Format("{0} = {1}", lstTemp[i].Name, lstTemp[i].WaitingTime));
            }
            al.Add(lst);

            return al;
        }

        #endregion

        #region FCFS

        public List<Process> OrderByBestCase() {
            var lst = SortForBurstTime(true);
            Parent.Children.Clear();
            ctorGraph();
            var sum = 0;
            for (var i = 0; i < lst.Count; i++) {
                var process = lst[i];
                sum += process.BurstTime;
                AddProcessForCases(process.BurstTime, process.Name, i, sum);
            }
            return lst;
        }

        public List<Process> OrderByWorstCase() {
            var lst = SortForBurstTime(false);
            Parent.Children.Clear();
            ctorGraph();
            var sum = 0;
            for (var i = 0; i < lst.Count; i++) {
                var process = lst[i];
                sum += process.BurstTime;
                AddProcessForCases(process.BurstTime, process.Name, i, sum);
            }
            return lst;
        }

        public void OrderByDefaultCase() {
            var lst = LstProcesses;
            Parent.Children.Clear();
            ctorGraph();
            var sum = 0;
            for (var i = 0; i < lst.Count; i++) {
                var process = lst[i];
                sum += process.BurstTime;
                AddProcessForCases(process.BurstTime, process.Name, i, sum);
            }
        }

        /// <summary>
        ///     Average Waiting Time and Average Completion Times calculations
        /// </summary>
        public double AverageWaitingTime(List<Process> lst) {
            double sum = 0;
            double temp = 0;
            for (var i = 1; i < lst.Count; i++) {
                sum += lst[i - 1].BurstTime;
                temp += sum;
            }
            return temp / lst.Count;
        }

        public string[] WaitingTimes(List<Process> lst) {
            double sum = 0;
            var temp = new string[lst.Count];
            temp[0] = string.Format("{0} : {1}", lst[0].Name, sum);
            for (var i = 1; i < lst.Count; i++) {
                sum += lst[i - 1].BurstTime;
                temp[i] = string.Format("{0} : {1}", lst[i].Name, sum);
            }

            return temp;
        }

        public double AverageCompletionTime(List<Process> lst) {
            double sum = 0;
            double temp = 0;
            foreach (var t in lst) {
                sum += t.BurstTime;
                temp += sum;
            }
            return temp / lst.Count;
        }

        #endregion
    }

}