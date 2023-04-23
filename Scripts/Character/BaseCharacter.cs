using UnityEngine;

namespace LB {

    public class BaseCharacter : MonoBehaviour {

        [Header("CHARACTER SETUP")]
        public Bar HealthBar;
        public Bar ManaBar;

        [Header("DATA")]
        public string Name = "New character...";
        public CharacterRace Race;
        public BaseStats Stats;

        void Awake(){
            if(Race != null){
                AddRaceTraits();
            }
        }

        // void Start(){
        //     InvokeRepeating("RegenerateHP", 0.0f, 1.0f / Stats["HPR"].Value);
        //     InvokeRepeating("RegenerateMP", 0.0f, 1.0f / Stats["MPR"].Value);
        // }


        // public void RegenerateHP() {
        //     if (HealthBar && HealthBar.slider.value < Stats["HP"].Value){
        //         HealthBar.SetNewValue(1);
        //     }
        // }   

        // public void RegenerateMP() {
        //     if (ManaBar && ManaBar.slider.value < Stats["MP"].Value){
        //         ManaBar.SetNewValue(1);
        //     }
        // }   

        public void AddRaceTraits(){
            foreach(StatModifier mod in Race.Modifiers){
                mod.Source = Race;
                Stats[mod.Key.ToString()].AddModifier(mod);
            }
        }

        

        
    }


}
