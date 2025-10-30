using System;
using Core;

namespace Location
{
    public class LocationProperty : IProperty<string>, INotifyPropertyChanged
    {
        public event Action OnPropertyChanged;
        public string Value { get; private set; }

        public LocationProperty(string value)
        {
            Value = value;
        }

        public void SetValue(string value)
        {
            Value = value;
            OnPropertyChanged?.Invoke();
        }

        public bool CanModify(string value)
        {
            return true;
        }

        public void Modify(string value)
        {
            SetValue(value);
        }
    }
}