using System;
using Core;
using UnityEngine;

namespace VIP
{
    public class VIPDomainBootstrap : Bootstrap
    {
        [SerializeField] 
        private double _initialVIPDuration;

        [SerializeField] 
        private VIPWidget _widget;

        private void Awake()
        {
            if (PlayerData.Instance.ContainsProperty<VIPProperty>())
            {
                return;
            }
            var property = new VIPProperty(TimeSpan.FromSeconds(_initialVIPDuration));
            PlayerData.Instance.RegisterProperty(property);
        }

        private void Start()
        {
            if (!PlayerData.Instance.TryGetProperty<VIPProperty>(out var property))
            {
                return;
            }

            var controller = new VIPWidgetController(_widget, property);
            controller.Initialize();
            Disposables.Add(controller);
        }
    }
}