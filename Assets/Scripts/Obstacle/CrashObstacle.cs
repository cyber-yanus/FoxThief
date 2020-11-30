using System.Collections;
using UnityEngine;

namespace Obstacle
{
    public class CrashObstacle : MonoBehaviour
    {           
        
        
        private void OnEnable()
        {
            StartCoroutine(DestroyObstacle());
        }
        
        private IEnumerator DestroyObstacle()
        {
            yield return new WaitForSeconds(2f);

            var parent = transform.parent.gameObject;
            Destroy(parent);            
        }

    }
}