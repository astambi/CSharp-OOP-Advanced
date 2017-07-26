public interface IBox<T>
{
    int Count { get; }

    void Add(T element);
    T Remove();
}