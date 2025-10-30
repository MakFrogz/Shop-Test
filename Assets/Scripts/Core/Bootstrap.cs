using System;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public class Bootstrap : MonoBehaviour
    {
        protected List<IDisposable> Disposables = new List<IDisposable>();

        private void OnDestroy()
        {
            foreach (var disposable in Disposables)
            {
                disposable.Dispose();
            }
            Disposables.Clear();
        }
    }
}