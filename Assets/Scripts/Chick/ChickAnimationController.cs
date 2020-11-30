using UnityEngine;

namespace DefaultNamespace.Chick
{
    public class ChickAnimationController : MonoBehaviour
    {
        private Animator animator;

        private void Start()
        {
            animator = GetComponent<Animator>();
        }
    }
}