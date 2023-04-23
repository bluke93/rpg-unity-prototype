using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace LB {

    public interface AiState {

        AiStateId GetId();

        void AfterEnter(NPCManager aiManager); // fires before tick and after change
        void Tick(NPCManager aiManager);       // fires while staying in state
        void BeforeExit(NPCManager aiManager); // fires before leaving state
        
    }
}

