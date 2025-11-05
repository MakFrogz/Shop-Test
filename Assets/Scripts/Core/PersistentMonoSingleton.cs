using UnityEngine;

namespace Core
{
    public class PersistentMonoSingleton<T> : MonoSingleton<T> where T : MonoSingleton<T>
    {
        protected virtual void Awake()
        {
            if (Application.isPlaying)
            {
                DontDestroyOnLoad(gameObject);
            }
        }
    }
}