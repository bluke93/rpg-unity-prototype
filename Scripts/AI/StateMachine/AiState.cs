using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace LB {

    public interface AiState {

        AiStateId GetId();

        void AfterEnter(NPCManager aiManager, Comportment behaviour); // fires before tick and after change
        void Tick(NPCManager aiManager, Comportment behaviour);       // fires while staying in state
        void BeforeExit(NPCManager aiManager, Comportment behaviour); // fires before leaving state
        
    }
}

