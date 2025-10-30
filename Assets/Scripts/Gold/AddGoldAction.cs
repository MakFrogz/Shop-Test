using System;
using Core;
using UnityEngine;

namespace Gold
{
    [CreateAssetMenu(fileName = "AddGold", menuName = "Gold/Actions/Add Gold", order = 0)]
    public class AddGoldAction : ScriptableAction
    {
        [SerializeField] 
        private int _amount;

        public override Type PropertyType => typeof(GoldProperty);

        public override bool CanApply()
        {
            var playerData = PlayerData.Instance;
            return playerData.ContainsProperty<GoldProperty>();
        }

        public override void Apply()
        {
            var playerData = PlayerData.Instance;
            if (!playerData.TryGetProperty<GoldProperty>(out var property))
            {
                return;
            }
            property.Modify(_amount);
        }
    }
}