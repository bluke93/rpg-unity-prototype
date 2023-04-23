using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace LB {

  public class StatsManager : MonoBehaviour {

    public BaseStats Stats;

    public void ApplyModifierList(List<StatModifier> StatsModifierList){
        foreach(StatModifier mod in StatsModifierList){
            mod.Source = StatsModifierList;
            Stats[mod.Key.ToString()].AddModifier(mod);
        }
    }

      

      
  }


}
