namespace E05_BorderControl
{
    public abstract class SocietyMember : IIdentifiable
    {
        private string id;

        public SocietyMember(string id)
        {
            this.Id = id;
        }

        public string Id
        {
            get { return this.id; }
            private set { this.id = value; }
        }

        public bool HasInvalidIdEnding(string pattern)
        {
            return this.id.EndsWith(pattern);
        }
    }
}