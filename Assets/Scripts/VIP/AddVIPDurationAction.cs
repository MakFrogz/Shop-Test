using System;
using Core;
using UnityEngine;

namespace VIP
{
    [CreateAssetMenu(fileName = "AddVIPDuration", menuName = "VIP/Actions/Add VIP Duration", order = 0)]
    public class AddVIPDurationAction : ScriptableAction
    {
        [SerializeField] 
        private double _duration;

        protected override Type PropertyType => typeof(VIPProperty);

        public override bool CanApply()
        {
            var playerData = PlayerData.Instance;
            return playerData.ContainsProperty<VIPProperty>();
        }

        public override void Apply()
        {
            var playerData = PlayerData.Instance;
            if (!playerData.TryGetProperty<VIPProperty>(out var property))
            {
                return;
            }
            property.Modify(TimeSpan.FromSeconds(_duration));
        }
    }
}