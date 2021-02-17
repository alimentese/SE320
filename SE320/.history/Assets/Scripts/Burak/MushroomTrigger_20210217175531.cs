using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomTrigger : MonoBehaviour
{
    public GameObject player;
    public bool trigger = false;
    void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void OnTriggerEnter2D(Collider2D col){
        
         if(col.gameObject.tag == "Player"){
            trigger = true;
             
         }
    }

    void OnTriggerExit2D(Collider2D col){
        if(col.gameObject.tag == "Player"){
            trigger = false;
             
         }
        
    }

    
}
