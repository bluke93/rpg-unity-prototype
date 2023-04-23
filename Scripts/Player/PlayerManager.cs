using UnityEngine;

namespace LB {


    public class PlayerManager : MonoBehaviour {

        public GameObject StatPanel;
        public CharacterRace Race;
        public StatsManager StatsManager;
        public MovementManager MovementManager;
        public string Name = "Lucas";

        void Awake(){
            StatsManager = GetComponent<StatsManager>();
            MovementManager = GetComponent<MovementManager>();
        }

        void Start(){
            if(StatsManager){
                if(Race){
                    StatsManager.ApplyModifierList(Race.Modifiers);
                    MovementManager.UpdateAgentSpeed();
                }
            }
        }


        void Update(){
            if (Input.GetKeyUp("space")){
                ShowStatPanel();
            }
        }

        public void ShowStatPanel(){
            if(StatPanel){
                bool isActive = StatPanel.activeSelf;
                StatPanel.SetActive(!isActive);
            }
        }

    }


}

