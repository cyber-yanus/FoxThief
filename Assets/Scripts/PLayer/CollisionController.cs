using UnityEngine;


namespace PLayer
{
    public class CollisionController : MonoBehaviour
    { 
        private PlayerController _playerController;
        
        
        private void Awake()
        {
            _playerController = GetComponent<PlayerController>();
        }

        private void OnCollisionEnter(Collision other)
        {
            var layerNumber = other.gameObject.layer;
            var state = _playerController.state;
            
            if (layerNumber == 9 && state != PlayerState.Dead)
            {
                Debug.Log("dead");
                _playerController.Dead();
            }
        }
    }
}