using System;
using Core;
using UnityEngine;

namespace VIP
{
    [CreateAssetMenu(fileName = "SpendVIPDuration", menuName = "VIP/Actions/Spend VIP Duration", order = 1)]
    public class SpendVIPDurationAction : ScriptableAction
    {
        [SerializeField] 
        private int _duration;

        protected override Type PropertyType => typeof(VIPProperty);

        public override bool CanApply()
        {
            var playerData = PlayerData.Instance;
            return playerData.TryGetProperty<VIPProperty>(out var property) && property.CanModify(-TimeSpan.FromSeconds(_duration));
        }

        public override void Apply()
        {
            var playerData = PlayerData.Instance;
            if (!playerData.TryGetProperty<VIPProperty>(out var property))
            {
                return;
            }
            property.Modify(-TimeSpan.FromSeconds(_duration));
        }
    }
}