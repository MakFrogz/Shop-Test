using System;
using Core;
using UnityEngine;

namespace Health
{
    [CreateAssetMenu(fileName = "AddHealth", menuName = "Health/Actions/Add Health", order = 0)]
    public class AddHealthAction : ScriptableAction
    {
        [SerializeField] 
        private int _amount;

        public override Type PropertyType => typeof(HealthProperty);

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
            property.Modify(_amount);
        }
    }
}