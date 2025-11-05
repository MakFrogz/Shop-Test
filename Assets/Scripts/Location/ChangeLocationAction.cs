using System;
using Core;
using UnityEngine;

namespace Location
{
    [CreateAssetMenu(fileName = "ChangeLocation", menuName = "Location/Actions/Change Location", order = 0)]
    public class ChangeLocationAction : ScriptableAction
    {
        [SerializeField] 
        private string _locationName;

        protected override Type PropertyType => typeof(LocationProperty);

        public override bool CanApply()
        {
            var playerData = PlayerData.Instance;
            return playerData.ContainsProperty<LocationProperty>();
        }

        public override void Apply()
        {
            var playerData = PlayerData.Instance;
            if (!playerData.TryGetProperty<LocationProperty>(out var property))
            {
                return;
            }
            property.Modify(_locationName);
        }
    }
}