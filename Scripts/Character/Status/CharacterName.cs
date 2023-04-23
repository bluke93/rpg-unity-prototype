using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


namespace LB {
    public class CharacterName : MonoBehaviour {

        public GameObject Player;
        public TextMeshProUGUI NameLabel;
    
    
        private void OnEnable(){
            Player = GameObject.FindWithTag("Player");
            var CharacterManager = Player.GetComponent<CharacterManager>();
            NameLabel.text = CharacterManager.Name;
        }

    }
}

