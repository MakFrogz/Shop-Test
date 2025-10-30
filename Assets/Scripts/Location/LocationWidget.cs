using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Location
{
    public class LocationWidget : MonoBehaviour
    {
        [SerializeField] 
        private TMP_Text _label;
        
        [SerializeField]
        private Button _button;
        
        public Button Button => _button;
        
        public void SetText(string text)
        {
            _label.text = text;
        }
    }
}