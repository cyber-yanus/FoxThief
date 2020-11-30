using UnityEngine;

namespace DefaultNamespace
{
    public class AnimationStateController : MonoBehaviour
    {

        private Animator _animator;
        
        private void Start()
        {
            _animator = GetComponent<Animator>();
        }


        public void Run()
        {
            _animator.SetBool("Run", true);
        }

        public void Jump()
        {
            _animator.SetTrigger("Jump");   
        }

        public void Dead()
        {
            _animator.SetTrigger("Dead");
        }

        public void Landing()
        {
            _animator.SetTrigger("Landing");
        }

        public void Attac()
        {
            _animator.SetBool("Attac", true);
        }

        public void DestroyAttac()
        {
            _animator.SetBool("Attac", false);
        }
    }
}