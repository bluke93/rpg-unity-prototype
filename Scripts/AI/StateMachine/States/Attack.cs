using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace LB {
    public class Attack : AiState {

        public StatsManager TargetStatsManager;
        public CharacterManager TargetCharacterManager;
        public CharacterManager SelfCharacterManager;



        


        public AiStateId GetId(){
            return AiStateId.Attack;
        }

        public void AfterEnter(NPCManager aiManager, Comportment behaviour){
            TargetStatsManager = aiManager.CurrentFocus.GetComponentInParent<StatsManager>();
            TargetCharacterManager = aiManager.CurrentFocus.GetComponentInParent<CharacterManager>();
            SelfCharacterManager = aiManager.GetComponentInParent<CharacterManager>();
        }

        public void Tick(NPCManager aiManager, Comportment behaviour){

            if(behaviour.IsInAttackRange(SelfCharacterManager, TargetCharacterManager)){
                if(SelfCharacterManager.canAttack){
                    // TODO: handle better the attack timer reset
                    SelfCharacterManager.canAttack = false;
                    SelfCharacterManager.attackTimer = SelfCharacterManager.maxAttackTimer - (SelfCharacterManager.baseAtkSpeed * (1 + SelfCharacterManager.attackSpeed / 100));

                    // TODO: handle better the damage function smhw
                    var Damage = (int)(SelfCharacterManager.StatsManager.Stats[StatsList.PATK.ToString()].Value  * (100 / (100 +TargetStatsManager.Stats[StatsList.PDEF.ToString()].Value)));
                    TargetStatsManager.Stats[StatsList.HP.ToString()].CurrentValue -= Damage;
                    TargetCharacterManager.TakeDamage(Damage.ToString(), DamageTypes.Physical, false); 
                }
            } else {
                aiManager.stateMachine.ChangeState(new Follow());
            }
        }

        public void BeforeExit(NPCManager aiManager, Comportment behaviour){
            
        }

    }
}

