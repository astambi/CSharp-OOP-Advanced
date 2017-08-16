using System;

namespace E04_WorkForce.Models
{
    public class Job
    {
        public event StartUp.JobDoneEventHandler JobDone;

        public Job(string name, int workHoursRequired, Employee employee)
        {
            this.Name = name;
            this.WorkHoursRequired = workHoursRequired;
            this.Employee = employee;
            this.IsDone = false;
        }

        public string Name { get; private set; }

        public int WorkHoursRequired { get; private set; }

        public Employee Employee { get; private set; }

        public bool IsDone { get; private set; }

        public void Update()
        {
            this.WorkHoursRequired -= this.Employee.WorkHoursPerWeek;

            if (this.WorkHoursRequired <= 0 &&
                !this.IsDone)
            {
                if (JobDone != null)
                {
                    JobDone(this, new JobEventArgs(this));
                }
            }
        }

        public void OnJobDone(object sender, JobEventArgs e)
        {
            Console.WriteLine($"Job {this.Name} done!");
            this.IsDone = true;
        }

        public override string ToString()
        {
            return $"Job: {this.Name} Hours Remaining: {this.WorkHoursRequired}";
        }
    }
}