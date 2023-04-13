using System;
using System.Diagnostics;


public class JobCollection : IJobCollection {
	private IJob[] jobs;
	private uint count;

	public JobCollection( uint capacity ) {
		if( !( capacity >= 1 ) ) throw new ArgumentException();
		jobs = new IJob[capacity];
        count = 0;
	}

	public uint Capacity {
		get { return (uint) jobs.Length; }
	}

	public uint Count {
		get { return count; }
	}

    

	public bool Add( IJob job ) {
        //adds job to collection if is valid
        if (job == null)
        {
            return false;
        }
        if (!Contains(job.Id) &&  Count < Capacity)
        {
            IJob newJob = job;
            jobs[count] = newJob;
            count = count + 1;
            return true;
        }
        else
        {
            return false;
        }
        
    }

    public bool Contains(uint id) {
        //checks for job with id in collection
        //  using Find() implementation
        if (Find(id) == null)
        {
            return false;
        }
        else
        {
            return true;
        }

    }

    public IJob? Find( uint id ) {
        //finds job with id in the collection
        //  implementing sequential search algorithm
        int i = 0;
        while (i < Count && jobs[i].Id != id)
        {
            i = i + 1;
        }
        if (i < Count)
        {
            return jobs[i];
        }
        else
        {
            return null;
        }

    }

    public bool Remove(uint id) {
        //removes job with id
        // if collection Contains(id)

        if (Contains(id))
        {
            for (int i = 0; i < Count; i++)
            {
                if (jobs[i].Id == id)
                {
                    for (int j = i; j < Count - 2; j++)
                    {
                        IJob job = jobs[j + 1];
                        jobs[j] = job;
                    }
                    jobs[Count - 1] = null;
                    break;
                }
                
            }
            count = count - 1;
            return true;
        }
        else
        {
            return false;
        }
        
    }

    public IJob[] ToArray() {
        //returns collection with same values
        IJob[] jobArray = new Job[Capacity];
        for (int i = 0; i < Capacity; i++)
        {
            IJob job = jobs[i];
            jobArray[i] = job;
        }
        return jobArray;
    }
}
