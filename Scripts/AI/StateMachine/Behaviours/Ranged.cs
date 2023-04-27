using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace LB {
    public class Ranged : Comportment {

        public AiBehavioursId GetId(){
            return AiBehavioursId.Ranged;
        }

        public bool IsInAttackRange(CharacterManager Self, CharacterManager Target){
            Self.MovementManager.nvAgent.stoppingDistance = Self.StatsManager.Stats["RANGE"].Value;
            int distanceFromtarget = (int) Vector3.Distance(Self.transform.position, Target.transform.position);
            Debug.Log(Self.StatsManager.Stats["RANGE"].Value);
            Debug.Log(distanceFromtarget);
            if(Self.StatsManager.Stats["RANGE"].Value >= distanceFromtarget){
                return true;
            } else {
                return false;
            }
        }

    }
}

