using UnityEngine;

namespace DefaultNamespace
{
    public class Finish : MonoBehaviour
    {
        [SerializeField] private GameObject finishUI;

        private Ground _ground;


        private void Start()
        {
            _ground = GetComponentInParent<Ground>();
        }

        private void OnTriggerEnter(Collider other)
        {
            var tag = other.tag;

            if (tag.Equals("Player"))
            {
                _ground.Move(false);
                finishUI.SetActive(true);
            }
        }
    }
}