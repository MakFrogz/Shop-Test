using System;
using Core;
using UnityEngine;

namespace Health
{
    public class HealthProperty : IProperty<int>, INotifyPropertyChanged
    {
        public event Action OnPropertyChanged;
        public int Value { get; private set; }

        public HealthProperty(int value)
        {
            Value = value;
        }

        public void SetValue(int value)
        {
            Value = Mathf.Max(0, value);
            OnPropertyChanged?.Invoke();
        }

        public bool CanModify(int delta)
        {
            return Value + delta >= 0;
        }

        public void Modify(int delta)
        {
            Value = Mathf.Max(0, Value + delta);
            OnPropertyChanged?.Invoke();
        }
    }
}