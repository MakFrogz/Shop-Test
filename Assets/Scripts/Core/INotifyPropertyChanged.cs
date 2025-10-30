using System;

namespace Core
{
    public interface INotifyPropertyChanged
    {
        event Action OnPropertyChanged;
    }
}