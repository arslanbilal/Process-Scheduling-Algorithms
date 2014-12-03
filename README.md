Process-Scheduling-Algorithms
=============================

* [First-Come First-Serve(FCFS)](#First-Come First-Serve(FCFS))
* [Shortest Job First(SJF)](#Shorhest Job First(SJF))
* [Priority](#Priority)
* [Round-Robin](#Round-Robin)

<hr>
###First-Come First-Serve(FCFS)
1) Policy: Process that requests the CPU FIRST  is allocated the CPU FIRST.<br>
2) FCFS is a non-preemptive algorithm. <br>
3) Implementation - using FIFO queues. Incoming process is added to the tail of the queue. Process selected for execution is taken from head of queue. <br>
4) Performance metric - Average waiting time in queue. <br>
<hr>
###Shortest Job First(SJF)
1)  Associate with each process the length of its next CPU burst. <br>
2) Use these lengths to schedule the process with the shortest time. <br>
3) Two Schemes:
#####Scheme 1: Non-preemptive 
  i. Once CPU is given to the process it cannot be preempted 
until it completes its CPU burst. 
#####Scheme 2: Preemptive 
  i. If a new CPU process arrives with CPU burst length less
than remaining time of current executing process, preempt.
  ii. Also called Shortest-Remaining-Time-First (SRTF).. <br>
<hr>
###Priority

<hr>
###Round-Robin

<hr>
