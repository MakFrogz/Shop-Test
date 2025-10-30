using System;
using System.Collections.Generic;

namespace Core
{
    public class PlayerData : Singleton<PlayerData>
    {
        private readonly Dictionary<Type, object> _properties = new Dictionary<Type, object>();

        public void RegisterProperty<T>(T property)
        {
            _properties[typeof(T)] = property;
        }

        public bool TryGetProperty<T>(out T property)
        {
            property = default;
            if (!_properties.TryGetValue(typeof(T), out var obj))
            {
               return false; 
            }
            
            property = (T)obj;
            return property != null;
        }

        public bool TryGetProperties<T>(out List<T> properties)
        {
           properties = new List<T>();
           foreach (var obj in _properties.Values)
           {
               if (obj is not T property)
               {
                  continue;
               }
               properties.Add(property);
           }
           return properties.Count > 0;
        }

        public bool TryGetProperty(Type type, out object property)
        {
            property = null;
            return type is not null && _properties.TryGetValue(type, out property);
        }

        public bool ContainsProperty<T>()
        {
            return _properties.ContainsKey(typeof(T));
        }
    }
}