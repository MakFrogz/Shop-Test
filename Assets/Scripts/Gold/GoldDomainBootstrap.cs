using Core;
using UnityEngine;

namespace Gold
{
    public class GoldDomainBootstrap : Bootstrap
    {
        [SerializeField] 
        private int _initialGold;
        
        [SerializeField]
        private GoldWidget _widget;

        private void Awake()
        {
            if (PlayerData.Instance.ContainsProperty<GoldProperty>())
            {
                return;
            }
            var property = new GoldProperty(_initialGold);
            PlayerData.Instance.RegisterProperty(property);
        }

        private void Start()
        {
            if (!PlayerData.Instance.TryGetProperty<GoldProperty>(out var property))
            {
                return;
            }
            var controller = new GoldWidgetController(_widget, property);
            controller.Initialize();
            Disposables.Add(controller);
        }
    }
}