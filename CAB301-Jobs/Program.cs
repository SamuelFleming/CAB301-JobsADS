using System;

namespace CAB301_Jobs
{
    class Program
    {
        static void Main(string[] args)
        {

            TestSort();
        }

        static void JobPrint(Job job)
        {
            Console.WriteLine(job.ToString());
        }

        static void TestSort()
        {
            IJobCollection jobs1;
            IJobCollection jobs2;


            IScheduler sched;

            object[] set1 = new IJob[]
            {
                new Job(1, 400, 600, 3),
                new Job(12, 500, 500, 4),
                new Job(300, 1000, 200, 7),
                new Job(20, 2000, 500, 4),
                new Job(13, 3120, 150, 8),
                new Job(15, 498, 3500, 9),
                new Job(78, 2300, 270, 4)

            };
            

            jobs1 = new JobCollection(7);
            for (int i = 0; i < set1.Length; i++)
            {
                jobs1.Add((IJob)set1.GetValue(i));
            }
            

            sched = new Scheduler(jobs1);
            IJob[] fcfs = sched.FirstComeFirstServed();
            
            foreach (IJob job in fcfs){
                Console.WriteLine(job.ToString());
            }
            Console.WriteLine();
            
            IJob[] pri = sched.Priority();
            foreach(IJob job in pri)
            {
                Console.WriteLine(job.ToString());
            }

            Console.WriteLine();
            IJob[] exe = sched.ShortestJobFirst();
            foreach (IJob job in exe)
            {
                Console.WriteLine(job.ToString());
            }
                

            
            
        }
    }
}
