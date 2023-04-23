using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace LB {
    public class Ranged : Comportment {

        public AiBehavioursId GetId(){
            return AiBehavioursId.Ranged;
        }

        public void Attack(NPCManager aiManager){
            Debug.Log("Follow di tipo ranged");
            Debug.Log(aiManager.CharacterManager.Name);
        }

    }
}

