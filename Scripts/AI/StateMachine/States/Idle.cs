using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace LB {
    public class Idle : AiState {

        private float currentWaitTime = 0;


        public AiStateId GetId(){
            return AiStateId.Idle;
        }

        public void AfterEnter(NPCManager aiManager){
            aiManager.CurrentFocus = null;
            aiManager.MovementManager.StopAnyMovement();
            currentWaitTime = 0;

        }

        public void Tick(NPCManager aiManager){
            if(currentWaitTime <= aiManager.ReturnToSpawnPointAfter){
                currentWaitTime += Time.deltaTime;
            } else {
                currentWaitTime = 5;
                aiManager.MovementManager.MoveToPoint(aiManager.SpawnPoint);
            }

        }

        public void BeforeExit(NPCManager aiManager){

        }

    }
}

