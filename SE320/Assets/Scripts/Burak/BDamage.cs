using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BDamage : MonoBehaviour
{
    public GameObject Playerr;
    public GameObject Skeleton_Enemy;
    private BEnemy Skeleton_Damage;

    void Start()
    {
        Playerr = GameObject.Find("Player");
        Skeleton_Damage = Skeleton_Enemy.GetComponent<BEnemy>();
    }
         
    void OnTriggerEnter2D(Collider2D col){       
        if (col.gameObject.CompareTag("Player")) {
            System.Random random = new System.Random();
            int dex = Playerr.GetComponent<PlayerScript>().maxDEX / 4;
            int damage = random.Next(1, (Skeleton_Damage.SkeletonDamage - dex));
            Playerr.GetComponent<PlayerScript>().currentHP -= damage;
            Debug.Log("Enemy damage: " + damage);
        } 
    }  
}
