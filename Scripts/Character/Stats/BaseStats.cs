using UnityEngine;
using System;
using System.Collections.Generic;

namespace LB {

    [Serializable]
    public class BaseStats {

        public Dictionary<string, Stat> Stats = new Dictionary<string, Stat>(){
            ["STR"] = new Stat("Strength", 50),
            ["DEX"] = new Stat("Dexterity", 50),
            ["INT"] = new Stat("Intelligence", 50),
            ["HP"] = new Stat("Health", 100),
            ["HPR"] = new Stat("Health Regen.", 1f),
            ["MP"] = new Stat("Mana", 100),
            ["MPR"] = new Stat("Mana Regen.", 1f),
            ["PATK"] = new Stat("Physical Attack", 10),
            ["PDEF"] = new Stat("Physical Defense", 10),
            ["ATKSPEED"] = new Stat("Attack speed", 0.6f),
            ["MATK"] = new Stat("Magical Attack", 0),
            ["MDEF"] = new Stat("Magical Defense", 0),
            ["CASTSPEED"] = new Stat("Casting Speed", 0),
            ["CDR"] = new Stat("Cooldown Reduction", 0),
            ["MS"] = new Stat("Movement Speed", 5),
            ["RANGE"] = new Stat("Range", 100),
        };

        public Stat this[string statName]{
            get {
                return Stats[statName];
            }
            set {
                Stats[statName] = value;
            }
        }

        public void ApplyModifierList(List<StatModifier> StatsModifierList){
            foreach(StatModifier mod in StatsModifierList){
                mod.Source = StatsModifierList;
                Stats[mod.Key.ToString()].AddModifier(mod);
            }
        }
        

    }

    


}
