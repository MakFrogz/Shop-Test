namespace Core
{
    public interface IProperty<T>
    {
        T Value { get; }
        void SetValue(T value);
        bool CanModify(T delta);
        void Modify(T delta);
    }
}