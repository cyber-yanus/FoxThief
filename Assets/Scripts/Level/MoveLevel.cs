using UnityEngine;
using UnityEngine.Events;

namespace Level
{
    public class MoveLevel : MonoBehaviour
    {

        public UnityEvent startMoveEvent;
        public UnityEvent endMoveEvent;
        
        [SerializeField] private float defaultSpeed;

        
        private bool _isMoved;

        
        
        private void Update()
        {
            if (_isMoved)
                Move();                
        }
        
        private void Move()
        {
            transform.position += Vector3.forward * defaultSpeed * Time.deltaTime;
        }

        public void StartMove()
        {
            _isMoved = true;
            startMoveEvent.Invoke();
        }

        public void EndMove()
        {
            _isMoved = false;
            endMoveEvent.Invoke();
        }
    }
}