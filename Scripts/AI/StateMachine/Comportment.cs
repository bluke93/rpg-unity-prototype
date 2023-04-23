using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LB {

    public interface Comportment {

        AiBehavioursId GetId();
        void Attack(NPCManager aiManager);
        
    }
}


