namespace Managment;

public interface IManageable<T>
{
    void Add(T item);
    void Remove(T item);
    T? Find(string name);
}
