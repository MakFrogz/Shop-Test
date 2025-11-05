using UnityEngine;

namespace Core
{
    public class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T>
    {
        private static T _instance;
        private static readonly object _lock = new object();
        
        public static T Instance
        {
            get
            {
                if (_instance)
                {
                    return _instance;
                }
                
                lock (_lock)
                {
                    _instance = FindAnyObjectByType<T>();

                    if (_instance)
                    {
                        return _instance;
                    }
                    
                    var obj = new GameObject();
                    obj.name = typeof(T).Name;
                    _instance = obj.AddComponent<T>();
                    
                }
                
                return _instance;
            }
        }
    }
}