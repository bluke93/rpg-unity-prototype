using UnityEngine;
using System.Collections.Generic;
using System;
using System.Reflection;


namespace LB {

    [Serializable]
    public class Stat {

        public string Name;
        public float BaseValue = 0f; // base value
        public List<StatModifier> Modifiers = new List<StatModifier>();

        public float _value;        // holds the calculated value
        public float _currentValue; // holds the current value
        public bool mustRecalculate = true;

        public float Value { // what is called to retrieve the calculated value
            get {
                if(mustRecalculate){
                    _value = CalculateStatValue();
                    mustRecalculate = false;
                }
                
                return _value;
            }
        }

        public float CurrentValue { // what is called to retrieve the current value
            get {
                return _currentValue;
            }
            set {
                if(value < 0){
                    _currentValue = 0;
                } else {
                    _currentValue = value;
                }
            }
        }

        public Stat(string name, float baseValue){
            Name = name;
            BaseValue = baseValue;
            CurrentValue = BaseValue;
            Modifiers = new List<StatModifier>();
        }

        public virtual void AddModifier(StatModifier item){
            mustRecalculate = true;
            Modifiers.Add(item);
            Modifiers.Sort(CompareOrder);
        }

        public virtual bool RemoveModifier(StatModifier item){
            mustRecalculate = true;
            return Modifiers.Remove(item);
        }

        public bool RemoveAllModifiersFromSource(object source){
            bool removed = false;
            for (int i = Modifiers.Count - 1; i >= 0; i--){
                if (Modifiers[i].Source == source){
                    mustRecalculate = true;
                    removed = true;
                    Modifiers.RemoveAt(i);
                }
            }
            return removed;
        }

        private float CalculateStatValue(){
            float finalValue = BaseValue;
            float sumPercentAdd = 0;

            for(int i = 0; i < Modifiers.Count; i++){
                StatModifier mod = Modifiers[i];

                if(mod.Type == ModifierTypes.Flat){
                    finalValue += mod.Value;
                }else if(mod.Type == ModifierTypes.PercentAdd){
                    sumPercentAdd += mod.Value;

                    if(i + 1 >= Modifiers.Count || Modifiers[i + 1].Type != ModifierTypes.PercentAdd){
                        finalValue *= 1 + (sumPercentAdd / 100);
                        sumPercentAdd = 0;
                    }
                }else if(mod.Type == ModifierTypes.PercentMult){
                    finalValue *= 1 + (mod.Value / 100);
                }
            }
            return (float)finalValue;
        }

        private int CompareOrder(StatModifier a, StatModifier b){
            if (a.Order < b.Order)
                return -1;
            else if (a.Order > b.Order)
                return 1;
            return 0;
        }



    }

}
