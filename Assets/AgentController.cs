using DG.Tweening;
using PLayer;
using UnityEngine;
using UnityEngine.AI;

public class AgentController : MonoBehaviour
{
    public Transform target;
    public AgentState state;
    
    private NavMeshAgent _navMeshAgent;
    private Tween _jumpTween;
    
    void Start()
    {
        state = AgentState.Move;
        _navMeshAgent = GetComponent<NavMeshAgent>();
        
    }


    private void OnCollisionEnter(Collision other)
    {
        var tag = other.transform.tag;

        if (tag.Equals("Player"))
        {
            var player = other.transform.GetComponent<PlayerController>();
            var playerState = player.state;
            
            if (playerState == PlayerState.Attac)
            {
                Death();
            }
            
//            state = AgentState.Stop;
//            _navMeshAgent.ResetPath();
//            Debug.Log("stop");
        }
        else if(tag.Equals("Buyer"))
        {
            var state = other.transform.GetComponent<AgentController>().state;

            if (state == AgentState.Stop)
            {
                state = AgentState.Stop;
                _navMeshAgent.ResetPath();
                Debug.Log("spec stop");
            }
        }
    }

    public void Death()
    {
        Destroy(gameObject);
    }

    public void Jump()
    {
        Vector3 endPosition = transform.position + transform.forward * 5f;
        
        _jumpTween = transform.DOJump(endPosition, 1f, 0, .5f)
            .OnComplete(() => { Destroy(gameObject); });            
    }

    private void Update()
    {
        if (state == AgentState.Move)
            _navMeshAgent.SetDestination(target.position);    
    }

    private void OnDestroy()
    {
        _jumpTween.Kill();
    }
}




public enum AgentState
{
    Stop,
    Move
}
