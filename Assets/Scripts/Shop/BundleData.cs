using Core;
using UnityEngine;

namespace Shop
{
    [CreateAssetMenu(fileName = "BundleData", menuName = "Shop/Bundle Data", order = 0)]
    public class BundleData : ScriptableObject
    {
        [SerializeField] 
        private string _name;

        [SerializeField] 
        private ScriptableAction[] _costs;
        
        [SerializeField] 
        private ScriptableAction[] _rewards;

        public string Name => _name;
        
        public ScriptableAction[] Costs => _costs;
        
        public bool CanPurchase()
        {
            if (_costs == null || _costs.Length == 0)
            {
                return true;
            }

            foreach (var cost in _costs)
            {
                if (!cost)
                {
                    continue;
                }

                if (!cost.CanApply())
                {
                    return false; 
                }
            }

            return true;
        }

        public void Purchase()
        {
            if (!CanPurchase())
            {
                Debug.LogWarning($"Cannot purchase bundle: {_name}");
                return;
            }

            ApplyCosts();
            ApplyRewards();
        }

        private void ApplyCosts()
        {
            if (_costs == null)
            {
                return;
            }

            foreach (var cost in _costs)
            {
                if (!cost)
                {
                    continue;
                }
                cost.Apply();
            }
        }

        private void ApplyRewards()
        {
            if (_rewards == null)
            {
                return;
            }

            foreach (var reward in _rewards)
            {
                if (!reward)
                {
                    continue;
                }
                reward.Apply();
            }
        }
    }
}