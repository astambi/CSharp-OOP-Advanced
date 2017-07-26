namespace E01_GenericBoxOfString
{
    public class Box<T>
    {
        private T boxValue;

        public Box(T value)
        {
            this.boxValue = value;
        }

        public override string ToString()
        {
            return $"{this.boxValue.GetType().FullName}: {this.boxValue}";
            //return $"{typeof(T).FullName}: {this.boxValue}";
        }
    }
}