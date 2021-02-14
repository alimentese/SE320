using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battlesystem : MonoBehaviour
{
    private enum State {
        Idle,
        Active,
        BattleOver,
    }

   [SerializeField] private Wave[] waveArray;
   [SerializeField] private ColliderTrigger colliderTrigger;

   private State state;
   
   private void Awake(){
       state =State.Idle;
    }

    void Start()
    {
        
        colliderTrigger.OnPlayerEnterTrigger += ColliderTrigger_OnPlayerEnterTrigger;
    }



    private void ColliderTrigger_OnPlayerEnterTrigger(object sender,System.EventArgs e){
        if(state == State.Idle){
        Startbattle();
        colliderTrigger.OnPlayerEnterTrigger -= ColliderTrigger_OnPlayerEnterTrigger;
        }
        
    }

    private void Startbattle(){
        Debug.Log("StartBattle");
        state = State.Active;
        
    }

    private void Update(){
        switch (state) {
            case State.Active:

                foreach(Wave wave in waveArray){
                wave.Update();
            }
            break;
        }

        
    } 

    private void TestBattleOver(){
         if(state == State.Active){
                    if(AreaWaveOver()){
                        // wave is over
                        state = State.BattleOver;
                        Debug.Log("Battle Over");
                    }

                }

    }


     private bool AreaWaveOver(){
         foreach(Wave wave in waveArray){
                    if(wave.IsWaveOver()){
                        // wave is over
                    }else{
                        return false;
                    }

            }

            return true;

    }


    /*
    * Wave part
    */
    [System.Serializable]
    private class Wave {

        [SerializeField] private float timer;
        [SerializeField] private EnemySpawn[] enemySpawnArray;

        public void Update(){
         if(timer > 0){
                timer -=Time.deltaTime;
                if(timer<0){
                    SpawnEnemies();
                }
            }
            
        }

        private void SpawnEnemies(){
            foreach(EnemySpawn EnemySpawn in enemySpawnArray){
                EnemySpawn.Spawn();
            }
        }

        public bool IsWaveOver(){
            if(timer <0){

                foreach(EnemySpawn enemySpawn in enemySpawnArray){
                    if(enemySpawn.IsAlive()){
                        return false;
                    }

                }
                return true;
            }
            else{
                return false;
            }
        }
    }  
    
}