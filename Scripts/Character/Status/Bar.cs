using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LB {

    public class Bar : MonoBehaviour {
        
        [Header("ENTITY")]
        public GameObject AttachedEntity;
        public bool isPlayer = false;


        [Header("BAR SETUP")]
        public StatsList SelectedStat;
        public Slider RealBar;
        public Slider SecondBar;
        private StatsManager StatsManager;

        public void Awake(){
            AttachedEntity = transform.parent.parent.gameObject;
            if(AttachedEntity.GetComponent<StatsManager>()){
                StatsManager = AttachedEntity.GetComponent<StatsManager>();
            } else {
                AttachedEntity = GameObject.FindWithTag("Player");
                StatsManager = AttachedEntity.GetComponent<StatsManager>();
                isPlayer = true;
            }
        }

        public void Start(){
            SetupBar();
        }

        private void LateUpdate(){
            ManageUIOrientation();
            AdjustBarMaxValue();
            AnimateRealBar();
            AnimateSecondaryBar();
        }

        public void SetupBar(){
            RealBar.maxValue = StatsManager.Stats[SelectedStat.ToString()].Value;
            RealBar.value = StatsManager.Stats[SelectedStat.ToString()].CurrentValue;
            SecondBar.maxValue = StatsManager.Stats[SelectedStat.ToString()].Value;
            SecondBar.value = StatsManager.Stats[SelectedStat.ToString()].CurrentValue;
        }

        public void AnimateSecondaryBar(){
            if(SecondBar.value > RealBar.value){
                SecondBar.value--;
            } else {
                SecondBar.value = RealBar.value;
            }
        }

        public void AnimateRealBar(){
            if(RealBar.value != StatsManager.Stats[SelectedStat.ToString()].CurrentValue){
                RealBar.value = StatsManager.Stats[SelectedStat.ToString()].CurrentValue;
            }
        }

        public void AdjustBarMaxValue(){
            if(StatsManager.Stats[SelectedStat.ToString()].Value != RealBar.maxValue){
                SetupBar();
            } else return;
        }

        public void ManageUIOrientation(){
            if(!isPlayer){
                Quaternion lookRotation = Camera.main.transform.rotation;
                transform.rotation = lookRotation;
            }
        }

    }
}

