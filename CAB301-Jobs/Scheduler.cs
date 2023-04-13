

public class Scheduler : IScheduler {
	public Scheduler( IJobCollection jobs ) {
		Jobs = jobs;
	}

	public IJobCollection Jobs { get; }

	public IJob[] FirstComeFirstServed() {
        //implements insertion sort to sort in non-descending order of TimeRecieved
        IJob[] jobs = Jobs.ToArray();
        int c = (int)Jobs.Count;
        for (int i = 1; i < c; i++)
        {
            IJob v = jobs[i];
            int j = i - 1;
            while (j>=0 && jobs[j].TimeReceived > v.TimeReceived)
            {
                jobs[j + 1] = jobs[j];
                j = j - 1;
            }
            jobs[j + 1] = v;
        }
        return jobs;
    }

    public IJob[] Priority() {
        //implements insertion sort to sort in ascending order of priority
        IJob[] jobs = Jobs.ToArray();
        int c = (int)Jobs.Count;
        for (int i = 1; i < c; i++)
        {
            IJob v = jobs[i];
            int j = i - 1;
            while (j >= 0 && jobs[j].Priority < v.Priority)
            {
                jobs[j + 1] = jobs[j];
                j = j - 1;
            }
            jobs[j + 1] = v;
        }
        return jobs;

    }

    public IJob[] ShortestJobFirst() {
        //Implements insertion sort to sort in non-descending ordder of ExecutionTime
        IJob[] jobs = Jobs.ToArray();
        int c = (int)Jobs.Count;
        for (int i = 1; i < c; i++)
        {
            IJob v = jobs[i];
            int j = i - 1;
            while (j >= 0 && jobs[j].ExecutionTime > v.ExecutionTime)
            {
                jobs[j + 1] = jobs[j];
                j = j - 1;
            }
            jobs[j + 1] = v;
        }
        return jobs;

    }
}