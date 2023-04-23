using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace LB {

    [CreateAssetMenu(fileName = "New race", menuName = "Character/Race")]
    [Serializable]
    public class CharacterRace : ScriptableObject {

        public string Name = "New race...";
        public Sprite RaceIcon = null;
        [TextArea] public string Description = null;
        public List<StatModifier> Modifiers = new List<StatModifier>();

    }

}
