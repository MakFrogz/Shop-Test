using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Shop
{
    public class BundleCardView : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text _name;

        [SerializeField] 
        private Button _infoButton;
        
        [SerializeField]
        private Button _purchaseButton;

        [SerializeField] 
        private TMP_Text _purchaseButtonText;
        
        public Button InfoButton => _infoButton;
        public Button PurchaseButton => _purchaseButton;

        public void SetName(string title)
        {
            _name.text = title;
        }

        public void SetPurchaseButtonText(string text)
        {
            _purchaseButtonText.text = text;
        }
    }
}