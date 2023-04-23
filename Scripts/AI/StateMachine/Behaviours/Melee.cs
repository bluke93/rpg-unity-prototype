using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace LB {
    public class Melee : Comportment {

        public AiBehavioursId GetId(){
            return AiBehavioursId.Melee;
        }

        public void Attack(NPCManager aiManager){
            Debug.Log( "Follow di tipo melee");
            Debug.Log(aiManager.CharacterManager.Name);
        }

    }
}

