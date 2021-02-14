using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BAttacking : MonoBehaviour
{
    
    public bool trigger = false;
    


    void Start()
    {
        
    }

    
    void Update()
    {
        
    }


    void OnTriggerEnter2D(Collider2D col){
        
         if(col.gameObject.tag == "Player"){
            Debug.Log("Hoşgeldim");
            trigger = true;
             
         }
    }

    void OnTriggerExit2D(Collider2D col){
        if(col.gameObject.tag == "Player"){
            trigger = false;
             
         }
        
    }
}
