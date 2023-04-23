using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;


namespace LB {
    public class RaceDisplay : MonoBehaviour {

        [Header("Objects references")]
        public GameObject Player;
        public SpriteRenderer Icon;
        public TextMeshProUGUI Label;

                    
        private void OnEnable(){
            Player = GameObject.FindWithTag("Player");
            var CharacterManager = Player.GetComponent<CharacterManager>();
            if(CharacterManager.CharacterRace){
                Label.text = CharacterManager.CharacterRace.Name;
                Icon.sprite = CharacterManager.CharacterRace.RaceIcon;
            } else {
                gameObject.SetActive(false);
            }
        }

        
    }
}

