using System.Collections;
using PLayer.Move;
using UnityEngine;
using UnityEngine.Events;

namespace PLayer.Attac
{
    public class AttacController : MonoBehaviour
    {
        [SerializeField] private float destroyStateTime;

        public UnityEvent attacEvent;
        public UnityEvent destroyAttacEvent;
        
        private PlayerController _playerController;
        private MoveController _moveController;
        private Rigidbody _rb;


        private void Start()
        {
            _playerController = GetComponent<PlayerController>();
            _moveController = GetComponent<MoveController>();
            _rb = GetComponent<Rigidbody>();
        }

        public void Attac()
        {
            var state = _playerController.state;

            if (state != PlayerState.Dead)
            {
                Debug.Log("state: Attac");

                _playerController.state = PlayerState.Attac;
                _rb.isKinematic = true;
                _moveController.LoadCrazySpeed();

                attacEvent.Invoke();

                StartCoroutine(DestroyAttac());
            }
        }

        private IEnumerator DestroyAttac()
        {
            yield return new WaitForSeconds(destroyStateTime);

            FastDestroyAttac();
        }

        public void FastDestroyAttac()
        {
            Debug.Log("state: Default");
        
            _playerController.state = PlayerState.Default;
            _rb.isKinematic = false;
            _moveController.LoadDefaultSpeed();
            
            destroyAttacEvent.Invoke();
        }
    }
}