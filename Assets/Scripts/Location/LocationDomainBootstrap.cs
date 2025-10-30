using Core;
using UnityEngine;

namespace Location
{
    public class LocationDomainBootstrap : Bootstrap
    {
        [SerializeField] 
        private string _initialLocation;

        [SerializeField] 
        private LocationWidget _widget;

        private void Awake()
        {
            if (PlayerData.Instance.ContainsProperty<LocationProperty>())
            {
                return;
            }
            var property = new LocationProperty(_initialLocation);
            PlayerData.Instance.RegisterProperty(property);
        }

        private void Start()
        {
            if (!PlayerData.Instance.TryGetProperty<LocationProperty>(out var property))
            {
                return;
            }

            var controller = new LocationWidgetController(_widget, property);
            controller.Initialize();
            Disposables.Add(controller);
        }
    }
}