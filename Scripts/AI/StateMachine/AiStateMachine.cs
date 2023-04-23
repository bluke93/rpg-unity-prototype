using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LB {
    public class AiStateMachine {

        public AiState[] states;
        public NPCManager aiManager;
        public AiState currentState;

        public AiStateMachine(NPCManager aiManager){
            this.aiManager = aiManager;
            int numStates = System.Enum.GetNames(typeof(AiStateId)).Length;
            states = new AiState[numStates];
        }

        public void Run(){
            currentState?.Tick(aiManager);
        }

        public void ChangeState(AiState nextState){
            currentState?.BeforeExit(aiManager);
            currentState = nextState;
            currentState?.AfterEnter(aiManager);
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
