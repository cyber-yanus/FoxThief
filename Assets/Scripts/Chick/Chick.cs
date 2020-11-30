using UnityEngine;

namespace DefaultNamespace.Chick
{
    public class Chick : MonoBehaviour
    {
        private Rigidbody _rb;
        private ChickStates _states;
        private Collision _player;
        
        
        private void Start()
        {
            _rb = GetComponent<Rigidbody>();
            _states = ChickStates.Default;
        }

        private void OnCollisionEnter(Collision other)
        {
            var tag = other.transform.tag;

            if (_states == ChickStates.Default)
            {
                if (tag.Equals("Player"))
                {
                    _player = other;
                    Connect(other);
                }
                else if (tag.Equals("Chick"))
                {
                    var chick = other.gameObject.GetComponent<Chick>();
                    var state = chick.States;

                    if (state == ChickStates.Connected)
                    {
                        Connect(chick.Player);
                    }
                }
            }
        }

        private void Connect(Collision other)
        {    
            _states = ChickStates.Connected;
            
            transform.parent = null;

            Vector3 endPosition = other.transform.position - new Vector3(0, -1, 1);
            transform.position = endPosition;

            var joint = gameObject.AddComponent<SpringJoint>();
            joint.connectedBody = other.rigidbody;
            joint.anchor = Vector3.up;
            joint.spring = 1000f;
            joint.minDistance = 1f;            
        }

        public ChickStates States => _states;

        public Collision Player => _player;
    }
}