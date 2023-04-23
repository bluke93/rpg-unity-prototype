using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LB {
    public class AiStateMachine {

        public AiState[] states;
        public NPCManager aiManager;
        public AiState currentState;
        public Comportment behaviour;

        public AiStateMachine(NPCManager aiManager){
            this.aiManager = aiManager;
            int numStates = System.Enum.GetNames(typeof(AiStateId)).Length;
            states = new AiState[numStates];
        }

        public void Run(){
            if(aiManager.currentBehaviour == AiBehavioursId.Melee){
                currentState?.Tick(aiManager, new Melee());
            } else {
                currentState?.Tick(aiManager, new Ranged());
            }
        }

        public void ChangeState(AiState nextState){
            currentState?.BeforeExit(aiManager, new Melee());
            currentState = nextState;
            currentState?.AfterEnter(aiManager, new Melee());
        }

        public void RegisterState(AiState state){
            int index = (int)state.GetId();
            states[index] = state;
        }

        public AiState GetState(AiStateId stateId){
            int index = (int)stateId;
            return states[index];
        }

    }
}
