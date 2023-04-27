using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace LB {
    public class Melee : Comportment {

        public AiBehavioursId GetId(){
            return AiBehavioursId.Melee;
        }

        public bool IsInAttackRange(CharacterManager Self, CharacterManager Target){
            if(Self.MovementManager.isCloseToCurrentTarget){
                return true;
            } else {
                return false;
            }
        }
    }
}

