using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LB {

    // Required Components to work
    [RequireComponent(typeof(MovementManager))]
    [RequireComponent(typeof(StatsManager))]

    public class CharacterManager : MonoBehaviour {

        [Header("RELATED MANAGERS")]
        public MovementManager MovementManager;
        public StatsManager StatsManager;
        private DamagePopup DamagePopup;

        [Header("CHARACTER SETUP")]
        public string Name;
        public CharacterRace CharacterRace;

        private Coroutine HPRegenRoutine;
        private Coroutine MPRegenRoutine;
        private Coroutine AtkTimerRoutine;

        [HideInInspector]
        public float attackTimer = 0;
        public float maxAttackTimer = 2.5f;
        public float attackSpeed = 0f;
        public float baseAtkSpeed = 0f;
        public bool canAttack = false;
        public bool canMove = true;

        void Awake(){
            StatsManager = GetComponent<StatsManager>();
            MovementManager = GetComponent<MovementManager>();
            DamagePopup = GetComponent<DamagePopup>();
        }

        void Start(){
            SetupRaceTraits();
            HPRegenRoutine = StartCoroutine(StatRegen(StatsList.HP, StatsList.HPR, 1f));
            MPRegenRoutine = StartCoroutine(StatRegen(StatsList.MP, StatsList.MPR, 1f));
        }

        void Update(){
            AttackTimerReset();
        }

        public void SetupRaceTraits(){
            if(CharacterRace != null){
                foreach(StatModifier mod in CharacterRace.Modifiers){
                    mod.Source = CharacterRace;
                    StatsManager.Stats[mod.Key.ToString()].AddModifier(mod);
                }
            } else {
                Debug.LogWarning($"No Race has been declared for \"{Name}\" entity");
            };
        }

        public void TakeDamage(string value, DamageTypes type, bool crit = false){
            DamagePopup.InstantiateDamage(value, type, crit); 
        }

        // TODO: handle better the attack timer reset  (attack state)
        public void AttackTimerReset(){
            if(attackTimer <= 0){
                canAttack = true;
            } else {
                attackTimer -= Time.deltaTime;
            }
        }

        IEnumerator StatRegen(StatsList stat, StatsList ratio, float interval = 1f){
            while(true){
                if(StatsManager.Stats[stat.ToString()].CurrentValue < StatsManager.Stats[stat.ToString()].Value){
                    StatsManager.Stats[stat.ToString()].CurrentValue += StatsManager.Stats[ratio.ToString()].Value;
                    if(StatsManager.Stats[stat.ToString()].CurrentValue > StatsManager.Stats[stat.ToString()].Value){
                        StatsManager.Stats[stat.ToString()].CurrentValue = StatsManager.Stats[stat.ToString()].Value;
                    }
                }
                yield return new WaitForSeconds(interval);
            }
        }

    }

}

