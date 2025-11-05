using System;
using UnityEngine;

namespace Core
{
    public abstract class ScriptableAction : ScriptableObject
    {
        protected abstract Type PropertyType { get; } 
        public abstract bool CanApply();
        public abstract void Apply();

        public bool TryGetProperty(out INotifyPropertyChanged property)
        {
            if (!PlayerData.Instance.TryGetProperty(PropertyType, out var obj))
            {
                property = null;
                return false;
            }

            if (obj is INotifyPropertyChanged notifyProperty)
            {
                property = notifyProperty;
                return true;
            }
            
            property = null;
            return false;
        }
    }
}