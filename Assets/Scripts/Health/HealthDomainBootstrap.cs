using Core;
using UnityEngine;

namespace Health
{
    public class HealthDomainBootstrap : Bootstrap
    {
        [SerializeField] 
        private int _initialHealth;
        
        [SerializeField]
        private HealthWidget _widget;

        private void Awake()
        {
            if (PlayerData.Instance.ContainsProperty<HealthProperty>())
            {
                return;
            }
            var property = new HealthProperty(_initialHealth);
            PlayerData.Instance.RegisterProperty(property);
        }

        private void Start()
        {
            if (!PlayerData.Instance.TryGetProperty<HealthProperty>(out var property))
            {
                return;
            }

            var controller = new HealthWidgetController(_widget, property);
            controller.Initialize();
            Disposables.Add(controller);
        }
    }
}