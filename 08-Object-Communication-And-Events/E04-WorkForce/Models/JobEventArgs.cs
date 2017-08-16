using System;

namespace E04_WorkForce.Models
{
    public class JobEventArgs : EventArgs
    {
        public JobEventArgs(Job job)
        {
            this.Job = job;
        }

        public Job Job { get;  set; }
    }
}
