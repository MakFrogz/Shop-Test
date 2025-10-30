using System;
using Core;
using UnityEngine;

namespace Gold
{
    [CreateAssetMenu(fileName = "SpendGold", menuName = "Gold/Actions/Spend Gold", order = 1)]
    public class SpendGoldAction : ScriptableAction
    {
        [SerializeField] 
        private int _amount;

        public override Type PropertyType => typeof(GoldProperty);

        public override bool CanApply()
        {
            var playerData = PlayerData.Instance;
            return playerData.TryGetProperty<GoldProperty>(out var gold) && gold.CanModify(-_amount);
        }

        public override void Apply()
        {
            var playerData = PlayerData.Instance;
            if (!playerData.TryGetProperty<GoldProperty>(out var gold))
            {
                return;
            }
            gold.Modify(-_amount);
        }
    }
}