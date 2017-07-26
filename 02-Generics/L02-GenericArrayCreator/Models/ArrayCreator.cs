public static class ArrayCreator
{
    public static T[] Create<T>(int length, T item)
    {
        var arr = new T[length];
        for (int i = 0; i < length; i++)
        {
            arr[i] = item;
        }
        return arr;
    }
}