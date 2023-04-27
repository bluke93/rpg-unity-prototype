using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LB {

    public interface Comportment {

        AiBehavioursId GetId();

        // Verifies if is in attack range
        bool IsInAttackRange(CharacterManager Self, CharacterManager Target);
        
    }
}


