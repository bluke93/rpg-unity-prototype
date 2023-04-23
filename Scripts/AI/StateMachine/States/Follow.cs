using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace LB {
    public class Follow : AiState {

        public AiStateId GetId(){
            return AiStateId.Follow;
        }

        public void AfterEnter(NPCManager aiManager){
            aiManager.MovementManager.StartFollowTarget(aiManager.CurrentFocus);
        }

        public void Tick(NPCManager aiManager){
            if(aiManager.type == NPCSocialTypes.Hostile){
                if(aiManager.MovementManager.isCloseToCurrentTarget){
                    aiManager.stateMachine.ChangeState(new Attack());
                }
            }
        }

        public void BeforeExit(NPCManager aiManager){

        }

    }
}

