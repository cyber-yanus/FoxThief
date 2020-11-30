using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace PLayer.Canvas
{
    public class LoadSceneButton : MonoBehaviour
    {
        [SerializeField] private string sceneName;
        
        private Button _button;
        
        private void Start()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(Execute);
        }

        private void Execute()
        {
            SceneManager.LoadScene(sceneName);
        }
        
        
    }
}