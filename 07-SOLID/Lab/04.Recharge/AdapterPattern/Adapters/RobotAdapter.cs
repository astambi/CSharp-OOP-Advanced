namespace _04.Recharge.AdapterPattern
{
    using System;

    public class RobotAdapter : IRechargeable
    {
        private Robot robot;

        public RobotAdapter(string id, int capacity)
        {
            this.robot = new Robot(id, capacity);
        }

        public void Recharge()
        {
            this.robot.Recharge();
        }

        public void Work(int hours)
        {
            this.robot.Work(hours);
        }
    }
}
