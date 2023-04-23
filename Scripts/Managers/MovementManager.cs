using UnityEngine;
using UnityEngine.AI;

// This controller manages the character movements
namespace LB {
  [RequireComponent(typeof(NavMeshAgent))]
  public class MovementManager : MonoBehaviour {   

    [HideInInspector]
    public NavMeshAgent nvAgent;                      // reference to current nvAgent
    private StatsManager statsManager;           // reference to character stats

    [Header("Target handling")]
      public Transform currentTarget;                 // selected target
      public bool isCloseToCurrentTarget = false;     // tracks if player is in range with currentTarget
      public bool isFollowing = false;                // tracks if player is actively following currentTarget

    // initializing
    void Awake(){
      nvAgent = GetComponent<NavMeshAgent>();
      statsManager = GetComponent<StatsManager>();
      nvAgent.angularSpeed = 9999;
      nvAgent.acceleration = 9999;
    }

    void Start(){
      UpdateAgentSpeed();
    }
    
    void Update(){
        if(currentTarget != null){
            if(isFollowing == true){
                if(isCloseToCurrentTarget == false){
                    MoveToPoint(currentTarget.position);
                } else {
                    nvAgent.ResetPath();
                }
                FaceTarget();
                CalculateDistance(currentTarget);
            }
        }
        float speedPercent = statsManager.Stats["MS"].Value;
    }

    public void CalculateDistance(Transform target){
        float distance = Vector3.Distance(transform.position, target.position);
        if(distance <= nvAgent.stoppingDistance){
            isCloseToCurrentTarget = true;
        } else {
            isCloseToCurrentTarget = false;
        }
    }

    public void MoveToPoint(Vector3 point){
        nvAgent.SetDestination(point);
    }

    public void StartFollowTarget(Interactable target){
        isFollowing = true;
        nvAgent.stoppingDistance = target.radius + 1f;
        nvAgent.updateRotation = false;
        currentTarget = target.transform;
    }

    public void StopFollowTarget(){
        isFollowing = false;
        nvAgent.stoppingDistance = 0f;
        nvAgent.updateRotation = true;
        currentTarget = null;
    }

    public void StopAnyMovement(){
        isFollowing = false;
        nvAgent.stoppingDistance = 0f;
        nvAgent.updateRotation = true;
        currentTarget = null;
        nvAgent.ResetPath();
    }

    void FaceTarget(){
        Vector3 direction = (currentTarget.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    public void UpdateAgentSpeed(float defaultSpeed = 5){
      if(statsManager != null){
        nvAgent.speed = statsManager.Stats["MS"].Value;
      } else {
        nvAgent.speed = defaultSpeed;
      }
    }

    


  }
}
