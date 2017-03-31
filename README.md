This Project is a Operating System Process scheduling and managing. It will be a WPF program that shows process scheduling.

Process-Scheduling-Algorithms
=============================

* [First-Come First-Serve(FCFS)](#First-Come-First-Serve(FCFS))
* [Shortest Job First(SJF)](#Shorhest-Job-First(SJF))
* [Priority](#Priority)
* [Round-Robin](#Round-Robin)

<hr>

### First-Come First-Serve(FCFS)
1) Policy: Process that requests the CPU FIRST  is allocated the CPU FIRST.<br>

2) FCFS is a non-preemptive algorithm. <br>

3) Implementation - using FIFO queues. Incoming process is added to the tail of the queue. Process selected for execution is taken from head of queue. <br>

4) Performance metric - Average waiting time in queue. <br>

<hr>

### Shortest Job First(SJF)
1) Associate with each process the length of its next CPU burst. <br>

2) Use these lengths to schedule the process with the shortest time. <br>

3) Two Schemes:
##### Scheme 1: Non-preemptive 
  * Once CPU is given to the process it cannot be preempted until it completes its CPU burst. <br>

##### Scheme 2: Preemptive 
  * If a new CPU process arrives with CPU burst length less than remaining time of current executing process, preempt.
  * Also called Shortest-Remaining-Time-First (SRTF).. <br>

<hr>

### Priority
1) A priority value (integer) is associated with each process. Can be based on:
  * Cost to user 
  * Importance to user 
  * Aging 
  * %CPU time used in last X hours.<br>

2) CPU is allocated to process with the highest priority.
  * Preemptive
  * Nonpreemptive<br>

3) SJN is a priority scheme where the priority is the predicted next CPU burst time. <br>

4) Problem:
  * Starvation!! - Low priority processes may never execute.<br>

5) Solution:
  * Aging - as time progresses increase the priority of the process.<br>
 
<hr>

### Round-Robin
1) Each process gets a small unit of CPU time:
  * Time quantum usually 10-100 milliseconds.
  * After this time has elapsed, the process is preempted and added to the end of the ready queue.
  * n processes, time quantum = q:
    1. Each process gets 1/n CPU time in chunks of at most q time units at a time. 
    2. No process waits more than (n-1)q time units. 
    3.Performance:
      * Time slice q too large – response time poor 
      * Time slice (infinity)? - reduces to FIFO behavior 
      * Time slice q too small - Overhead of context switch is too expensive. Throughput poor<br>

<hr>
