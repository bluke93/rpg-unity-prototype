using UnityEngine;
using System.Collections.Generic;
using System;


namespace LB {

    [Serializable]
    public class StatModifier {

        public StatsList Key; 
        public ModifierTypes Type;
        public object Source;
        [Space(10)]
        public float Value = 0f;
        public float Timer = 0f;
        public int Order;

        public StatModifier(float value, ModifierTypes type, int order, object source, float timer){
            Value = value;
            Type = type;
            Order = order;
            Source = source;
            Timer = timer; 
        }

        public StatModifier(float value, ModifierTypes type) : this(value, type, (int)type,  null, 0) { }
        

    }

    


}
