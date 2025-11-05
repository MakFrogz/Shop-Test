using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public class PurchaseService : PersistentMonoSingleton<PurchaseService>
    {
        public event Action<int> OnPurchaseCompleted;
        private Dictionary<int, bool> _purchases = new Dictionary<int, bool>();

        public void Purchase(int id)
        {
            if (_purchases.TryGetValue(id, out var value))
            {
                if (value)
                {
                    return;
                }
            }
            
            _purchases[id] = true;
            StartCoroutine(InternalPurchase(id));
        }

        public bool IsPurchaseProcess(int id)
        {
            return _purchases.GetValueOrDefault(id, false);
        }

        private IEnumerator InternalPurchase(int id)
        {
            yield return new WaitForSeconds(3f);
            _purchases[id] = false;
            OnPurchaseCompleted?.Invoke(id);;
        }
    }
}