using NUnit.Framework;
//test to commit JobTests

namespace CAB301_JobsTesting
{
    [TestFixture]
    public class JobTests
    {
        private uint[] Data_Id;       
        private uint[] Data_time;
        private uint[] Data_ExecutionTime;
        private uint[] Data_priority;

        private bool[] assert = new bool[] { false, true, true, true, false };

        [SetUp]
        public void Setup()
        {

            Data_Id = new uint[]{1000, 999, 500, 1, 0 };
            Data_ExecutionTime = new uint[] { 0, 1, 100, 10000, 0 };
            Data_time = new uint[] { 0, 1, 100, 1000, 0 };
            Data_priority = new uint[] { 10, 9, 5, 1, 0 };

        }

        //Test 1 regarding method 'Job()'
        [Test]
        public void ValidConstructor()
        {
            IJob testJob = new Job(1, 200, 300, 4);
            Assert.AreEqual(testJob.Id, 1);
            Assert.AreEqual(testJob.TimeReceived, 200);
            Assert.AreEqual(testJob.ExecutionTime, 300);
            Assert.AreEqual(testJob.Priority, 4);
        }

        //Test 2 regarding method 'bool IsValidId()'
        [Test]
        public void ValidIdBoundary()
        {
            for (int i = 0; i < 5; i++)
            {
                if (assert[i])
                {
                    Assert.True(Job.IsValidId(Data_Id[i]));
                }
                else if (!assert[i])
                {
                    Assert.False(Job.IsValidId(Data_Id[i]));
                }
            }
        }

        //Test 3 regarding method 'bool IsTimeRecieved()'
        [Test]
        public void ValidTimeBoundary()
        {
            for (int i = 0; i < 5; i++)
            {
                if (assert[i])
                {
                    Assert.True(Job.IsTimeReceived(Data_time[i]));
                }
                else if (!assert[i])
                {
                    Assert.False(Job.IsTimeReceived(Data_time[i]));
                }
            }
        }

        //Test 4 regarding method 'bool IsValidExecutionTime()'
        [Test]
        public void ValidExecutionTimeBoundary()
        {
            for (int i = 0; i < 5; i++)
            {
                if (assert[i])
                {
                    Assert.True(Job.IsValidExecutionTime(Data_ExecutionTime[i]));
                }
                else if (!assert[i])
                {
                    Assert.False(Job.IsValidExecutionTime(Data_ExecutionTime[i]));
                }
            }
        }

        //Test 5 regarding method 'bool IsValidPriority()'
        [Test]
        public void ValidPriorityBoundary()
        {
            for (int i = 0; i < 5; i++)
            {
                if (assert[i])
                {
                    Assert.True(Job.IsValidPriority(Data_priority[i]));
                }
                else if (!assert[i])
                {
                    Assert.False(Job.IsValidPriority(Data_priority[i]));
                }
            }
        }

    }


    [TestFixture]
    public class JobCollectionTests
    {
        private IJobCollection collectionl;
        private IJobCollection collections;

        

        private object[] list = new IJob[]
        {
            new Job(1, 400, 100, 4),
            new Job(12, 500, 500, 3),
            new Job(300, 1000, 200, 7),
            new Job(20, 2000, 500, 4),
            new Job(13, 3120, 150, 8),
        };
        private IJob addNon = new Job(15, 1500, 200, 4);
        private IJob addNull = null;
        private IJob addExist = new Job(12, 2300, 4000, 9);

        [SetUp]
        public void Setup()
        {
            collectionl = new JobCollection(6);
            collections = new JobCollection(5);
            collectionl.Add((IJob)list.GetValue(0));
            collections.Add((IJob)list.GetValue(0));
            collectionl.Add((IJob)list.GetValue(1));
            collections.Add((IJob)list.GetValue(1));
            collectionl.Add((IJob)list.GetValue(2));
            collections.Add((IJob)list.GetValue(2));
            collectionl.Add((IJob)list.GetValue(3));
            collections.Add((IJob)list.GetValue(3));
            collectionl.Add((IJob)list.GetValue(4));
            collections.Add((IJob)list.GetValue(4));


        }

        //Test 6 Regarding Method 'bool Contians(Id)'
        [Test]
        public void ContainsExistingID()
        {
            //Case, Job with Id already exists in collection
            Assert.True(collectionl.Contains(12));
            //Case, Id doen't exist in collection
            Assert.False(collectionl.Contains(30));
        } 

        //Tests 7 & 8 Regarding Method 'IJob Find(Id)'
        [Test]
        public void FindExistingID()
        {
            //Case, correctly finds eisting Id
            Assert.AreEqual(collectionl.Find(12), (IJob)list.GetValue(1));
        }
        [Test]
        public void FindNonExistingID()
        {
            //Case, does not find job that does not exist // detects job doesn't exist
            Assert.AreEqual(collectionl.Find(15), null);
        }

        //Tests 9 - 14 Regarding Method 'bool Adds(IJob)'
        [Test]
        public void AddsNewIJob()
        {
            //Case, IJob doesn't exists in collection, is not null, and there is room in collection to be added
            IJobCollection col = collectionl;

            int oldcount = (int)col.Count;
            object oldcol = col.ToArray();
            Assert.True(col.Add(addNon));
            int newcount = (int)col.Count;
            object newcol = col.ToArray();
            Assert.AreNotEqual(oldcol, newcol);
            Assert.AreNotEqual(oldcount, newcount);

        }
        [Test]
        public void NoAddCapacity()
        {
            //Case, IJob doesn't exist in collection, is not null, but there is no room in collection to be added
            IJobCollection col = collections;

            int oldcount = (int)col.Count;
            object oldcol = col.ToArray();
            Assert.False(col.Add(addNon));
            int newcount = (int)col.Count;
            object newcol = col.ToArray();
            Assert.AreEqual(oldcol, newcol);
            Assert.AreEqual(oldcount, newcount);
        }
        [Test]
        public void NoAddNull()
        {
            //Case, IJob doesn't exist in collction, is null, and there is room in the collection to add
            IJobCollection col = collectionl;

            
            int oldcount = (int)col.Count;
            object oldcol = col.ToArray();
            Assert.False(col.Add(addNull));
            int newcount = (int)col.Count;
            object newcol = col.ToArray();
            Assert.AreEqual(oldcol, newcol);
            Assert.AreEqual(oldcount, newcount);
        }
        [Test]
        public void NoAddNullCapacity()
        {
            //Case, IJob doesn't exist in collction, is null, but there is no room in the collection to add
            IJobCollection col = collections;

            int oldcount = (int)col.Count;
            object oldcol = col.ToArray();
            Assert.False(col.Add(addNull));
            int newcount = (int)col.Count;
            object newcol = col.ToArray();
            Assert.AreEqual(oldcol, newcol);
            Assert.AreEqual(oldcount, newcount);
        }
        [Test]
        public void NoAddId()
        {
            //Case, IJob does exists in collection, is not null, and there is no room in collection to be added
            IJobCollection col = collectionl;

            int oldcount = (int)col.Count;
            object oldcol = col.ToArray();
            Assert.False(col.Add(addExist));
            int newcount = (int)col.Count;
            object newcol = col.ToArray();
            Assert.AreEqual(oldcol, newcol);
            Assert.AreEqual(oldcount, newcount);
        }
        [Test]
        public void NoAddIdCapacity()
        {
            //Case, IJob does exists in collection, is not null, but there is no room in collection to be added
            IJobCollection col = collections;

            int oldcount = (int)col.Count;
            object oldcol = col.ToArray();
            Assert.False(col.Add(addExist));
            int newcount = (int)col.Count;
            object newcol = col.ToArray();
            Assert.AreEqual(oldcol, newcol);
            Assert.AreEqual(oldcount, newcount);
        }


        //Tests 15 - 18  Regarding Method 'bool Remove(Id)'
        [Test]
        public void RemovesJob()
        {
            //Case, Id exists in collection, removes job
            IJobCollection col = collectionl;
            object oldcol = col.ToArray();
            Assert.True(col.Remove(12));
            object newcol = col.ToArray();
            Assert.AreNotEqual(oldcol, newcol);

        }
        [Test]
        public void RemovesCount()
        {
            //Case, Id exists in collection,  count decremented correctly
            IJobCollection col = collectionl;
            int oldcount = (int)col.Count;
            Assert.True(col.Remove(12));
            int newcount = (int)col.Count;
            Assert.AreNotEqual(oldcount, newcount);
        }
        [Test]
        public void RemovesCorrectJob()
        {
            //Case, Id exists in collection,  correct Job removed
            IJobCollection col = collectionl;
            Assert.True(col.Contains(12));
            Assert.True(col.Remove(12));
            Assert.False(col.Contains(12));
        }
        [Test]
        public void RemovesNonExist()
        {
            //Case, Id doesn't existin collection, don't remove job, count not incremented
            IJobCollection col = collectionl;
            object oldcol = col.ToArray();
            int oldcount = (int)col.Count;
            Assert.False(col.Remove(15));
            object newcol = col.ToArray();
            int newcount = (int)col.Count;
            Assert.AreEqual(oldcol, newcol);
            Assert.AreEqual(oldcount, newcount);
        }
    }

    [TestFixture]
    public class SchedulerTests
    {
        IJobCollection jobs;
        

        IScheduler sched;

        private object[] set = new IJob[]
        {
            new Job(1, 400, 100, 4),
            new Job(2, 500, 500, 3),
            new Job(3, 1000, 200, 7),
            new Job(4, 2000, 500, 4),
            new Job(5, 3120, 150, 8),
            new Job(6, 498, 3500, 9),
            new Job(7, 2300, 270, 4)

        };
        private int[] setReceived = new int[] { 1, 6, 2, 3, 4, 7, 5 };
        private int[] setExecution = new int[] { 1, 5, 3, 7, 2, 4, 6 };
        private int[] setPriority = new int[] { 6, 5, 3, 1, 4, 7, 2 };

        [SetUp]
        public void SetUp()
        {
            jobs = new JobCollection(7);
            for (int i = 0; i < 7; i++)
            {
                jobs.Add((IJob)set.GetValue(i));
            }
            
        }

        //Test 19 regarding Method FirstComeFirstServed()
        [Test]
        public void SortRecieved()
        {
            sched = new Scheduler(jobs);
            IJob[] sort = sched.FirstComeFirstServed();
            for (int i = 0; i < sched.Jobs.Capacity; i++)
            {
                Assert.AreEqual((int)sort[i].Id, setReceived[i]);
            }
        }

        //Test 20 regarding Method ShortestJobFirst()
        [Test]
        public void SortExecution()
        {
            sched = new Scheduler(jobs);
            IJob[] sort = sched.ShortestJobFirst();
            for (int i = 0; i < sched.Jobs.Capacity; i++)
            {
                Assert.AreEqual((int)sort[i].Id, setExecution[i]);
            }
        }

        //Test 21 regarding Method Priority()
        [Test]
        public void SortPriority()
        {
            sched = new Scheduler(jobs);
            IJob[] sort = sched.Priority();
            for (int i = 0; i < sched.Jobs.Capacity; i++)
            {
                Assert.AreEqual((int)sort[i].Id, setPriority[i]);
            }
        }


    }
}
