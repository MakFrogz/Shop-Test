using System;
using Core;
using UnityEngine;

namespace Health
{
    [CreateAssetMenu(fileName = "SpendHealthPercent", menuName = "Health/Actions/Spend Health Percent", order = 3)]
    public class SpendHealthPercentAction : ScriptableAction
    {
        [SerializeField] 
        private int _percent;

        protected override Type PropertyType => typeof(HealthProperty);

        public override bool CanApply()
        {
            var playerData = PlayerData.Instance;
            if (!playerData.TryGetProperty<HealthProperty>(out var property))
            {
                return false;
            }
            var amount = (int)(property.Value * (_percent / 100f));
            return property.CanModify(-amount);
        }

        public override void Apply()
        {
            var playerData = PlayerData.Instance;
            if (!playerData.TryGetProperty<HealthProperty>(out var property))
            {
                return;
            }
            var amount = (int)(property.Value * (_percent / 100f));
            property.Modify(-amount);
        }
    }
}