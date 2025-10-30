using Core;
using UnityEngine;

namespace Shop
{
    public class BundleInfoBootstrap : Bootstrap
    {
        [SerializeField]
        private BundleCardView _bundleCardView;

        private void Start()
        {
            if (!PlayerData.Instance.TryGetProperty<BundleProperty>(out var property))
            {
                return;
            }

            var controller = new BundleCardController(_bundleCardView, property.Value);
            controller.Initialize();
            Disposables.Add(controller);
        }
    }
}