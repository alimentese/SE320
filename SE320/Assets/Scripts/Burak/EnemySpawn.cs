﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool IsAlive(){
        return true;

    }

    public void Spawn(){
          if(gameObject.tag == "enemy"){
            gameObject.SetActive(true);
          }
    }
}
