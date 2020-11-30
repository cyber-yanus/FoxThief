using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

namespace PLayer
{
    public class JumpController : MonoBehaviour
    {
        [SerializeField] private float jumpForce;
        [SerializeField] private float jumpDuration;
        
        
        public UnityEvent jumpEvent;
        public UnityEvent landingEvent;
        
        
        private Rigidbody _rb;
        private PlayerController _playerController;
        
        
        
        private void Start()
        {
            _rb = GetComponent<Rigidbody>();
            _playerController = GetComponent<PlayerController>();
        }


        public void Jump()
        {
            Debug.Log("Jump");

            var state = _playerController.state;

            if (state == PlayerState.Dead)
            {
                transform.DOJump(transform.position, jumpForce, 0, jumpDuration);
            }
                        
        }

        public void Landing()
        {
            Debug.Log("Down");
        
            _rb.AddForce(Vector3.down * jumpForce, ForceMode.VelocityChange);
            
            landingEvent.Invoke();
        }
    }
}