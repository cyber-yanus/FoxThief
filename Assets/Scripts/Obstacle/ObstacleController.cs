using PLayer;
using UnityEngine;

namespace Obstacle
{
    public class ObstacleController : MonoBehaviour
    {
        [SerializeField] private GameObject crashObstacle;
        
        private GameObject _parent;
        
        
        private void Start()
        {
            _parent = transform.parent.gameObject;
        }

        private void OnCollisionEnter(Collision other)
        {
            int layer = other.gameObject.layer;

            if (layer == 8)
            {
                var player = other.transform.GetComponent<PlayerController>();
                var state = player.state;

                if (state == PlayerState.Default)
                {
                    Debug.Log("end Game");
                    player.Dead();
                }
                else if (state == PlayerState.Attac)
                {
                    StartSmesh();
                }
                
            }
        }


        private void StartSmesh()
        {
            crashObstacle.SetActive(true);
            
            Debug.Log("smesh");
            
            gameObject.SetActive(false);
        }



    }
}