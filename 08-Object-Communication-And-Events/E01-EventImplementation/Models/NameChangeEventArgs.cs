using System;

namespace E01_EventImplementation.Models
{
    public class NameChangeEventArgs : EventArgs
    {
        private string name;

        public NameChangeEventArgs(string name)
        {
            this.name = name;
        }

        public string Name
        {
            get => this.name;
            private set => this.name = value;
        }
    }
}
