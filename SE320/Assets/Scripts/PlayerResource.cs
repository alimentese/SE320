using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerResource : MonoBehaviour
{
    [SerializeField] private Image health;
    [SerializeField] private Image stamina;
    [SerializeField] private Image mana;
    private GameObject player;
    PlayerScript playerscript;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerscript = player.GetComponent<PlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        health.fillAmount = (float)playerscript.currentHP / playerscript.maxHP;
        stamina.fillAmount = (float)playerscript.currentSTA / playerscript.maxSTA; 
        mana.fillAmount = (float)playerscript.currentMAG / playerscript.maxMAG;
    }
}
