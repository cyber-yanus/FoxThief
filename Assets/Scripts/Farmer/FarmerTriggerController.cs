
using PLayer;

namespace UnityEngine
{
    public class FarmerTriggerController : MonoBehaviour
    {
        [SerializeField] private AgentController agentController;



        private void OnTriggerEnter(Collider other)
        {
            var tag = other.tag;

            if (tag.Equals("Player"))
            {
               if (agentController.state == AgentState.Move)
                {
                    agentController.state = AgentState.Stop;
                    agentController.Jump();    
                }

            }

        }
    }
}