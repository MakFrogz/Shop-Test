using System;
using System.Collections;
using System.Collections.Generic;
using Core;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Shop
{
    public class BundleCardController : IDisposable
    {
        private readonly BundleCardView _view;
        private readonly BundleData _model;

        private bool _purchaseProcessing;
        private List<INotifyPropertyChanged> _properties =  new List<INotifyPropertyChanged>();

        public BundleCardController(BundleCardView bundleView, BundleData model)
        {
            _view = bundleView;
            _model = model;
        }

        public void Initialize()
        {
            _purchaseProcessing = false;
            _view.SetName(_model.Name);
            _view.PurchaseButton.interactable = _model.CanPurchase();
            _view.PurchaseButton.onClick.AddListener(OnPurchaseClick);
            _view.InfoButton.onClick.AddListener(OnInfoClick);

            foreach (var cost in _model.Costs)
            {
                if (!PlayerData.Instance.TryGetProperty(cost.PropertyType, out var obj))
                {
                    continue;
                }
                
                if (obj is not INotifyPropertyChanged property)
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
            if (_purchaseProcessing)
            {
                return;
            }
            
            if (!_model.CanPurchase())
            {
                return;
            }

            _view.StartCoroutine(Purchase());
        }

        private IEnumerator Purchase()
        {
            _purchaseProcessing = true;
            _view.PurchaseButton.interactable = false;
            _view.SetPurchaseButtonText("Processing...");
            yield return new WaitForSeconds(3f);
            _model.Purchase();
            _purchaseProcessing = false;
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
            foreach (var property in _properties)
            {
                property.OnPropertyChanged -= OnPropertyChanged;
            }
        }
    }
}