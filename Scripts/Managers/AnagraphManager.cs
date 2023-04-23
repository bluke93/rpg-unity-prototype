using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LB {

    public class AnagraphManager : MonoBehaviour {

        public CharacterManager CharacterManager;

        [Header("DATA")]
        public string CharacterName = "New Character...";
        public string fameValue = "0";
        public string karmaValue = "0";
        public List<string> Quests = new List<string>();



        [Header("Character model")]
        public float raceModel;
        public float gender;
        public float hairstyle;


        void Awake(){
            if(CharacterManager){
                CharacterName = CharacterManager.Name;
                fameValue = CharacterManager.Name;
                karmaValue = CharacterManager.Name;
            }
        }

        void Start(){

        }

    }


}

