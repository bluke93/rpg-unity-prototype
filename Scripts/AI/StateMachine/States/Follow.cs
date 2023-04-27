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

            if(aiManager.type == NPCSocialTypes.Hostile){
                if(behaviour.IsInAttackRange(SelfCharacterManager, TargetCharacterManager)){
                    aiManager.stateMachine.ChangeState(new Attack());
                }
            }
        }

        public void BeforeExit(NPCManager aiManager, Comportment behaviour){

        }

    }
}

