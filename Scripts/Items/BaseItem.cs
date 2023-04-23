using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace LB {

    [CreateAssetMenu(fileName = "New item", menuName = "Item/BaseItem")]
    [Serializable]

    public class BaseItem : ScriptableObject {

        public string Name = "Item name";
        public ItemsType Type;
       
    }
}

