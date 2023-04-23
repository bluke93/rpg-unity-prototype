using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace LB {
    public class Heal : AiState {

        public CharacterManager SelfCharacterManager;

        public AiStateId GetId(){
            return AiStateId.Heal;
        }

        public void AfterEnter(NPCManager aiManager){
            aiManager.MovementManager.StopAnyMovement();
            SelfCharacterManager = aiManager.GetComponentInParent<CharacterManager>();
            
        }

        public void Tick(NPCManager aiManager){
            
        }

        public void BeforeExit(NPCManager aiManager){
            

        }

    }
}

