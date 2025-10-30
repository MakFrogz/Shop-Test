using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Core
{
    public class SceneRoute : MonoBehaviour
    {
        [SerializeField]
        private string _sceneName;

        [SerializeField] 
        private Button _button;

        private void OnEnable()
        {
            _button.onClick.AddListener(Route);
        }

        private void Route()
        {
            SceneManager.LoadScene(_sceneName);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(Route);
        }
    }
}