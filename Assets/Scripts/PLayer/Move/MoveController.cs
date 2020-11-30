using DefaultNamespace;
using UnityEngine;
using UnityEngine.Events;

namespace PLayer.Move
{
    public class MoveController : MonoBehaviour
    {
        [SerializeField] 
        private bool isMove;

        [SerializeField] private float amplitude;
        
        
        
        [SerializeField] 
        private float defaultMoveSpeed;
        [SerializeField] 
        private float crazyMoveSpeed;

        public UnityEvent moveEvent;
        
        private float _speed;
        private PlayerController _playerController;
        
        
        private void Start()
        {
            _speed = defaultMoveSpeed;
        }

        private void Move()
        {        
            //transform.localPosition += Vector3.forward * _speed * Time.deltaTime;
            float x = Mathf.Sin(Time.time) * amplitude;
            float y = transform.position.y;
            float z = transform.position.z + 1 * Time.deltaTime;

            transform.position = new Vector3(x,y,z); 
        }


        public void LoadDefaultSpeed()
        {
            _speed = defaultMoveSpeed;
        }
        
        public void LoadCrazySpeed()
        {
            _speed = crazyMoveSpeed;
        }

        public void StopPlayer()
        {
            isMove = false;
        }

        public void MovePlayer()
        {
            isMove = true;
            moveEvent.Invoke();
        }

        private void Update()
        {   
            if (isMove)
                Move();    
        
        }

        public float Speed => _speed;
    }
}