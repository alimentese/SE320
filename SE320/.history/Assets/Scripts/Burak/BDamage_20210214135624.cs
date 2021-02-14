using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BDamage : MonoBehaviour
{
    
   

    public GameObject Playerr;
    private PlayerScript PlTake;

     public GameObject Skeleton_Enemy;
    private BEnemy Skeleton_Damage;

    void Start()
    {
        Playerr = GameObject.Find("Player");
        PlTake = Playerr.GetComponent<PlayerScript>();
        Skeleton_Damage = Skeleton_Enemy.GetComponent<BEnemy>();
    }
   
         
    void OnTriggerEnter2D(Collider2D col){
        
         if(col.gameObject.tag == "Player"){
               PlTake.TakeDamage(Skeleton_Damage.SkeletonDamage);
             
            }
    }    
    
}
