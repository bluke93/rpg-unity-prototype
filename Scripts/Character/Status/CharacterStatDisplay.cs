using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;


namespace LB {
    public class CharacterStatDisplay : MonoBehaviour {

        public enum StatDisplayType {
            SoloNumber,
            PerSecond,
            Difference,
            Percent
        }

        [Header("Objects references")]
        public GameObject Player;
        public TextMeshProUGUI Label;
        public TextMeshProUGUI Value;

        [Header("Stat details")]
        public StatsList SelectedStat;
        public StatDisplayType Visualization = StatDisplayType.SoloNumber;
    
        private void OnEnable(){
            Player = GameObject.FindWithTag("Player");
            var CharacterManager = Player.GetComponent<CharacterManager>();
            var Stat = CharacterManager.StatsManager.Stats[SelectedStat.ToString()];
            var MaxValue = CharacterManager.StatsManager.Stats[SelectedStat.ToString()].Value;
            Label.text = Stat.Name;
            switch(Visualization){
                case StatDisplayType.SoloNumber:
                    Value.text = $"{(int)Stat.Value}";
                    break;
                case StatDisplayType.PerSecond:
                    Value.text = $"{(int)Stat.Value}/sec";
                    break;
                case StatDisplayType.Difference:
                    Value.text = $"{(int)Stat.Value}/{(int)MaxValue}";
                    break;
                case StatDisplayType.Percent:
                    Value.text = $"{(int)Stat.Value}%";
                    break;
                default:
                    Value.text = $"{(int)Stat.Value}";
                    break;
            }
            

        }

        private void DisplayUpdate(){
            if(Visualization == StatDisplayType.Difference){
                var CharacterManager = Player.GetComponent<CharacterManager>();
                var Stat = CharacterManager.StatsManager.Stats[SelectedStat.ToString()];
                var MaxValue = CharacterManager.StatsManager.Stats[SelectedStat.ToString()].Value;
                Value.text = $"{(int)Stat.CurrentValue}/{(int)Stat.Value}";
            }
        }

        private void LateUpdate() {
            if(Visualization == StatDisplayType.Difference){
                var CharacterManager = Player.GetComponent<CharacterManager>();
                var Stat = CharacterManager.StatsManager.Stats[SelectedStat.ToString()];
                var MaxValue = CharacterManager.StatsManager.Stats[SelectedStat.ToString()].Value;
                Value.text = $"{(int)Stat.CurrentValue}/{(int)Stat.Value}";
            }
        }

        
    }
}

