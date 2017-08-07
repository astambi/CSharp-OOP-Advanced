using System;

namespace Demo.Attributes
{
    public class AuthorAttribute : Attribute
    {
        public AuthorAttribute(string name)
        {
            this.Name = name;
        }

        public string Name { get; private set; }

        
    }
}
