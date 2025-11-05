using System;
using System.Collections.Generic;
using Core;
using UnityEngine.SceneManagement;

namespace Shop
{
    public class BundleCardController : IDisposable
    {
        private readonly BundleCardView _view;
        private readonly BundleData _model;

        private List<INotifyPropertyChanged> _properties =  new List<INotifyPropertyChanged>();

        public BundleCardController(BundleCardView bundleView, BundleData model)
        {
            _view = bundleView;
            _model = model;
        }

        public void Initialize()
        {
            _view.SetName(_model.Name);
            _view.PurchaseButton.interactable = _model.CanPurchase();
            if (PurchaseService.Instance.IsPurchaseProcess(_model.GetInstanceID()))
            {
                _view.PurchaseButton.interactable = false;
                _view.SetPurchaseButtonText("Processing...");
            }
            
            _view.PurchaseButton.onClick.AddListener(OnPurchaseClick);
            _view.InfoButton.onClick.AddListener(OnInfoClick);
            PurchaseService.Instance.OnPurchaseCompleted += OnPurchaseCompleted;

            foreach (var cost in _model.Costs)
            {
                if (!cost.TryGetProperty(out var property))
                {
                    continue;
                }
                
                property.OnPropertyChanged += OnPropertyChanged;
                _properties.Add(property);
            }
        }

        private void OnInfoClick()
        {
            if (!PlayerData.Instance.TryGetProperty<BundleProperty>(out var property))
            {
                return;
            }
            
            property.SetValue(_model);
            SceneManager.LoadScene("BundleInfo");
        }

        private void OnPurchaseClick()
        {
            if (!_model.CanPurchase())
            {
                return;
            }
            
            _view.PurchaseButton.interactable = false;
            _view.SetPurchaseButtonText("Processing...");

            PurchaseService.Instance.Purchase(_model.GetInstanceID());
        }

        private void OnPurchaseCompleted(int id)
        {
            if (_model.GetInstanceID() != id)
            {
                return;
            }
            _model.Purchase();
            _view.SetPurchaseButtonText("Purchase");
        }

        private void OnPropertyChanged()
        {
            _view.PurchaseButton.interactable = _model.CanPurchase();
        }

        public void Dispose()
        {
            _view.PurchaseButton.onClick.RemoveListener(OnPurchaseClick);
            _view.InfoButton.onClick.RemoveListener(OnInfoClick);
            
            if (PurchaseService.Instance)
            {
                PurchaseService.Instance.OnPurchaseCompleted -= OnPurchaseCompleted;
            }
            
            foreach (var property in _properties)
            {
                property.OnPropertyChanged -= OnPropertyChanged;
            }
        }
    }
}