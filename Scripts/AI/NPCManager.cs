using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LB {

    public class NPCManager : MonoBehaviour {

        [Header("AI Settings")]
        public NPCSocialTypes type; 
        public AiStateMachine stateMachine;
        public AiStateId currentState;
        public Stances currentStance;
        [HideInInspector] public MovementManager MovementManager;
        [HideInInspector] public StatsManager StatsManager;
        [HideInInspector] public CharacterManager CharacterManager;
        [HideInInspector] private Collider SphereCollider;


        [Header("NPC Params")]
        public Interactable CurrentFocus;
        public float InteractionRadius = 10f;
        public Vector3 SpawnPoint;
        public float ReturnToSpawnPointAfter = 5f;


        private void Awake() {
            MovementManager = GetComponent<MovementManager>();
            StatsManager = GetComponent<StatsManager>();
            CharacterManager = GetComponent<CharacterManager>();
            stateMachine = new AiStateMachine(this);
        }

        void Start(){
            SpawnPoint = transform.position;
            stateMachine.RegisterState(new Idle());
            stateMachine.RegisterState(new Reset());
            stateMachine.RegisterState(new Follow());
            stateMachine.RegisterState(new Attack());
            stateMachine.RegisterState(new Heal());
            stateMachine.ChangeState(stateMachine.GetState(currentState));
        }

        void Update(){
            stateMachine.Run();
            currentState = stateMachine.currentState.GetId();
        }

        private void OnTriggerEnter(Collider entity){
            if(type == NPCSocialTypes.Hostile){
                if(entity.transform.parent.gameObject.CompareTag("Player")){
                    CurrentFocus = entity.GetComponentInParent<Interactable>();
                    stateMachine.ChangeState(new Follow());
                }
            }
            
        }

        private void OnTriggerExit(Collider entity){ 
            if(type == NPCSocialTypes.Hostile){
                if(entity.transform.parent.gameObject.CompareTag("Player")){
                    stateMachine.ChangeState(new Idle());
                }
            }
        }


        // Draw our radius in the editor
        void OnDrawGizmosSelected(){
            SphereCollider = gameObject.GetComponentInParent<SphereCollider>();
            Color color = Color.red;
            color.a = 0.30f;
            Gizmos.color = color;
            Gizmos.DrawSphere(transform.position, InteractionRadius);
        }

    }

}