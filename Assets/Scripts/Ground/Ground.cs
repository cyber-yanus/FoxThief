using PLayer;
using UnityEngine;

namespace DefaultNamespace
{
    public class Ground : MonoBehaviour
    {
        [SerializeField] private PlayerController _playerController;
        
        [SerializeField] private bool isMoving;
        [SerializeField] private float speed;

        public void Move(bool moving)
        {
            isMoving = moving;
        }

        private void Update()
        {
            var playerState = _playerController.state;
            
            if (isMoving && playerState != PlayerState.Dead)
            {
                transform.localPosition -= Vector3.forward * speed * Time.deltaTime;
            }
        }
    }
}