using System.Collections.Generic;

namespace E04_WorkForce.Models
{
    public class JobsList : List<Job>
    {
        public void OnJobDone(object sender, JobEventArgs e)
        {
            this.Remove(e.Job);
        }
    }
}