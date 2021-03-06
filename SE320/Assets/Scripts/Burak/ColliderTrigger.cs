﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderTrigger : MonoBehaviour
{
    public event EventHandler OnPlayerEnterTrigger;

     private void OnTriggerEnter2D(Collider2D collider){
         PlayerScript player = collider.GetComponent<PlayerScript>();
         if(player !=null){
             Debug.Log("Player inside trigger!");
             OnPlayerEnterTrigger?.Invoke(this, EventArgs.Empty);
         }
     }
    
}
