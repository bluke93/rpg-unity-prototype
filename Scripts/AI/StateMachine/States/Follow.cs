using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace LB {
    public class Follow : AiState {

        public CharacterManager TargetCharacterManager;
        public CharacterManager SelfCharacterManager;

        public AiStateId GetId(){
            return AiStateId.Follow;
        }

        public void AfterEnter(NPCManager aiManager, Comportment behaviour){
            aiManager.MovementManager.StartFollowTarget(aiManager.CurrentFocus);
            TargetCharacterManager = aiManager.CurrentFocus.GetComponentInParent<CharacterManager>();
            SelfCharacterManager = aiManager.GetComponentInParent<CharacterManager>();
        }

        public void Tick(NPCManager aiManager, Comportment behaviour){
            behaviour.Attack(aiManager);

            if(aiManager.type == NPCSocialTypes.Hostile){
                int dist = (int) Vector3.Distance(SelfCharacterManager.transform.position, TargetCharacterManager.transform.position);

                

                if(aiManager.MovementManager.isCloseToCurrentTarget || SelfCharacterManager.StatsManager.Stats["RANGE"].Value >= dist){
                    aiManager.stateMachine.ChangeState(new Attack());
                }
            }
        }

        public void BeforeExit(NPCManager aiManager, Comportment behaviour){

        }

    }
}

