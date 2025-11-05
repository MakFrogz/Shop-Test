using System;
using Core;
using UnityEngine;

namespace Health
{
    [CreateAssetMenu(fileName = "AddHealthPercent", menuName = "Health/Actions/Add Health Percent", order = 2)]
    public class AddHealthPercentAction : ScriptableAction
    {
        [SerializeField] 
        private int _percent;

        protected override Type PropertyType => typeof(HealthProperty);

        public override bool CanApply()
        {
            var playerData = PlayerData.Instance;
            return playerData.ContainsProperty<HealthProperty>();
        }

        public override void Apply()
        {
            var playerData = PlayerData.Instance;
            if (!playerData.TryGetProperty<HealthProperty>(out var property))
            {
                return;
            }
            var amount = (int)(property.Value * (_percent / 100f));
            property.Modify(amount);
        }
    }
}