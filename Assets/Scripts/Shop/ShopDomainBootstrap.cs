using System.Collections.Generic;
using Core;
using UnityEngine;

namespace Shop
{
    public class ShopDomainBootstrap : Bootstrap
    {
        [SerializeField] 
        private List<BundleData> _bundles;
        
        [SerializeField]
        private BundleCardView _bundleCardPrefab;
        
        [SerializeField]
        private Transform _container;

        private void Awake()
        {
            if (PlayerData.Instance.ContainsProperty<BundleProperty>())
            {
                return;
            }
            var property = new BundleProperty();
            PlayerData.Instance.RegisterProperty(property);
        }

        private void Start()
        {
            foreach (var bundle in _bundles)
            {
                var bundleCard = Instantiate(_bundleCardPrefab, _container);
                var controller = new BundleCardController(bundleCard, bundle);
                controller.Initialize();
                Disposables.Add(controller);
            }
        }
    }
}