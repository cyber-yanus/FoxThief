using UnityEngine;

namespace PLayer.Canvas
{
    public class CanvasController : MonoBehaviour
    {
        [SerializeField] private GameObject startGameUI;
        [SerializeField] private GameObject endGameUI;

        [SerializeField] private PlayerController _playerController;

        private void Update()
        {
            var playerState = _playerController.state;
            
            if (playerState == PlayerState.Dead)
            {
                endGameUI.SetActive(true);
            }
        }
    }
}