using UnityEngine;

namespace Camera
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private Transform target;

        private Vector3 _diff;
        
        
        private void Awake()
        {
            _diff = transform.position - target.position;
        }

        private void Update()
        {
            moveTo();
        }

        private void moveTo()
        {
            transform.position = target.position + _diff;
        }
    }
}