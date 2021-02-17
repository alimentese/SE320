using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class MushroomDamage : MonoBehaviour
{

    public GameObject Playerr;
    public GameObject MushRoom;
    private EnemyScript MushroomDamage_Damage;
    // Start is called before the first frame update
    void Start()
    {
         Playerr = GameObject.Find("Player");
         MushroomDamage_Damage = MushRoom.GetComponent<EnemyScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


     void OnTriggerEnter2D(Collider2D col){       
        if (col.gameObject.CompareTag("Player")) {
           System.Random random = new System.Random();
            int dex = Playerr.GetComponent<PlayerScript>().maxDEX / 4;
            int damage = random.Next(1, (MushroomDamage_Damage.mashroomdamage - dex));
            Playerr.GetComponent<PlayerScript>().currentHP -= 1;
            Debug.Log("Enemy damage: " + damage);
        } 
    }  
}
