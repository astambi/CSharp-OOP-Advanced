namespace E05_BorderControl
{
    public class Robot : SocietyMember
    {
        private string model;

        public Robot(string id, string model) 
            : base(id)
        {
            this.Model = model;
        }

        public string Model
        {
            get { return this.model; }
            private set { this.model = value; }
        }        
    }
}
