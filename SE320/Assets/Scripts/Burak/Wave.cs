using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Wave : MonoBehaviour
{
    public float timer;
    [SerializeField] public EnemySpawn[] enemySpawnArray;

    public void SpawnEnemies() {
        foreach (EnemySpawn EnemySpawn in enemySpawnArray) {
            EnemySpawn.Spawn();
        }
    }

    public bool IsWaveOver() {
        if (timer < 0) {

            foreach (EnemySpawn enemySpawn in enemySpawnArray) {
                if (enemySpawn.IsAlive()) {
                    return false;
                }

            }
            return true;
        }
        else {
            return false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Update()
    {
        if (timer > 0) {
            timer -= Time.deltaTime;
            if (timer < 0) {
                SpawnEnemies();
            }
        }
    }
}
