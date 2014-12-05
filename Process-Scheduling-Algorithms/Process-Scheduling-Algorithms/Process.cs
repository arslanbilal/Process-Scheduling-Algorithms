using System;
using System.Collections;

namespace Process_Scheduling_Algorithms
{
    class Process
    {
        public static int _count = 0;

        private int _priority;
        private int _burstTime;
        private int _arrivalTime;
        public string Name { get; set; }

        public int BurstTime
        {
            get { return _burstTime; }
            set { _burstTime = value < 0 ? 0 : value; }
        }

        public int ArrivalTime
        {
            get { return _arrivalTime; }
            set { _arrivalTime = value < 0 ? 0 : value; }
        }

        public int Priority
        {
            get { return _priority; }
            set { _priority = value < 0 ? 0 : value; }
        }

        public Process(string name, int priority, int burstTime, int arrivalTime)
        {
            this.Name = name;
            this.Priority = priority;
            this.BurstTime = burstTime;
            this.ArrivalTime = arrivalTime;
        }

        public Process(int priority, int burstTime, int arrivalTime)
        {
            Name = string.Format("P{0}", _count++);
            this.Priority = priority;
            this.BurstTime = burstTime;
            this.ArrivalTime = arrivalTime;
        }


        public int CompareToPriority(Process obj)
        {
            if (this.Priority > obj.Priority) return 1;
            if (this.Priority < obj.Priority) return -1;
            return 0;
        }

        public int CompareToBurstTime(Process obj)
        {
            if (this.BurstTime > obj.BurstTime) return 1;
            if (this.BurstTime < obj.BurstTime) return -1;
            return 0;
        }
    }
}
