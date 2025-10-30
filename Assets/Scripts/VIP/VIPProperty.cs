using System;
using Core;

namespace VIP
{
    public class VIPProperty : IProperty<TimeSpan>, INotifyPropertyChanged
    {
        public event Action OnPropertyChanged;
        public TimeSpan Value { get; private set; }

        public VIPProperty(TimeSpan value)
        {
            Value = value;
        }

        public void SetValue(TimeSpan value)
        {
            Value =  value;
            OnPropertyChanged?.Invoke();
        }

        public bool CanModify(TimeSpan delta)
        {
            return Value + delta >= TimeSpan.Zero;
        }

        public void Modify(TimeSpan delta)
        {
            var newValue = Value + delta;
            if (newValue < TimeSpan.Zero)
            {
                return;
            }
            Value = newValue;
            OnPropertyChanged?.Invoke();
        }
    }
}