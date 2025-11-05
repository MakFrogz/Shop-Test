using System;
using Core;
using UnityEngine;

namespace Health
{
    [CreateAssetMenu(fileName = "SpendHealth", menuName = "Health/Actions/Spend Health", order = 1)]
    public class SpendHealthAction : ScriptableAction
    {
        [SerializeField] 
        private int _amount;

        protected override Type PropertyType => typeof(HealthProperty);

        public override bool CanApply()
        {
            var playerData = PlayerData.Instance;
            return playerData.TryGetProperty<HealthProperty>(out var property) && property.CanModify(-_amount);
        }

        public override void Apply()
        {
            var playerData = PlayerData.Instance;
            if (!playerData.TryGetProperty<HealthProperty>(out var property))
            {
                return;
            }
            property.Modify(-_amount);
        }
    }
}