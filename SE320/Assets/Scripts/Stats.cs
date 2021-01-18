using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // This is so that it should find the Text component
using UnityEngine.Events; // This is so that you can extend the pointer handlers
using UnityEngine.EventSystems; // This is so that you can extend the pointer handlers


public class Stats : MonoBehaviour
{
    // player knight prefab setup
    public GameObject playerPrefab;
    PlayerScript playerscript;

    
    // needed texts for showing stats from ui
    public Text attributePoints;
    public Text hpText;
    public Text staText;
    public Text magText;
    public Text strText;
    public Text dexText;
    public Text agiText;
    public Text intText;

    // + and - Buttons
    public GameObject reverseHP;
    public GameObject reverseSTA;
    //public GameObject reverseMAG;
    public GameObject reverseSTR;
    public GameObject reverseDEX;
    public GameObject reverseAGI;
    public GameObject reverseINT;
    

    // stat objects
    public GameObject maxHP;    
    public GameObject maxSTA;
    //public GameObject maxMAG;
    public GameObject maxSTR;
    public GameObject maxDEX;
    public GameObject maxAGI;
    public GameObject maxINT;

    public int defaultMaxHP, defaultMaxSTA, defaultMaxSTR, defaultMaxDEX, defaultMaxAGI, defaultMaxINT, defaultAttributePoints;

    
    
// Start is called before the first frame update
    void Start()
    {
       
		playerscript = playerPrefab.GetComponent<PlayerScript>();
        //maxHP.gameObject.tag = "maxHP";
        playerscript.defaultAttributes();
        defaultAttributePoints = playerscript.attributePoints;
        defaultMaxHP = playerscript.maxHP;
        defaultMaxSTA = playerscript.maxSTA;
        //defaultMaxMAG = playerscript.maxMAG;
        defaultMaxSTR = playerscript.maxSTR;
        defaultMaxDEX = playerscript.maxDEX;
        defaultMaxAGI = playerscript.maxDEX;
        defaultMaxINT = playerscript.maxINT;

        reverseHP.SetActive(false);
        reverseSTA.SetActive(false);
        //reverseMAG.SetActive(false);
        reverseSTR.SetActive(false);
        reverseDEX.SetActive(false);
        reverseAGI.SetActive(false);
        reverseINT.SetActive(false);


    }

    // Update is called once per frame
    void Update()
    {

        //attributePoints.text = playerscript.attributePoints.ToString();
        hpText.text = playerscript.maxHP.ToString();
        staText.text = playerscript.maxSTA.ToString();
        strText.text = playerscript.maxSTR.ToString();
        dexText.text = playerscript.maxDEX.ToString();
        agiText.text = playerscript.maxAGI.ToString();
        intText.text = playerscript.maxINT.ToString();

    }

    public void resetSkillPoint()
    {

    }

    public void spendSkillPoint(GameObject stat)
    {
        
        if (playerscript.attributePoints > 0) {
            playerscript.attributePoints -= 1;
            switch(stat.gameObject.tag) {
                case "maxHP":
                    playerscript.maxHP += 10;
                    reverseHP.SetActive(true);
                break;
                case "maxSTA":
                    playerscript.maxSTA += 10;
                    reverseSTA.SetActive(true);
                break;
                /*case "maxMAG":
                    playerscript.maxMAG += 10;
                    reverseMAG.SetActive(true);
                break;*/
                case "maxSTR":
                    playerscript.maxSTR += 10;
                    reverseSTR.SetActive(true);
                break;
                case "maxDEX":
                    playerscript.maxDEX += 10;
                    reverseDEX.SetActive(true);
                break;
                case "maxAGI":
                    playerscript.maxAGI += 10;
                    reverseAGI.SetActive(true);
                break;
                case "maxINT":
                    playerscript.maxINT += 10;
                    reverseINT.SetActive(true);
                break;
            }
        }
        else if(playerscript.attributePoints == defaultAttributePoints) {
            reverseSTA.SetActive(false);
            reverseHP.SetActive(false);
            reverseSTR.SetActive(false);
            reverseDEX.SetActive(false);
            reverseAGI.SetActive(false);
            reverseINT.SetActive(false);
        }
       
    }

    public void reversePoint(GameObject stat) {
        if (playerscript.attributePoints < defaultAttributePoints) {
            switch(stat.gameObject.tag) {
                case "maxHP":
                    if (playerscript.maxHP > defaultMaxHP) {
                        playerscript.maxHP -= 10;
                        playerscript.attributePoints += 1;
                    }
                    if(playerscript.maxHP == defaultMaxHP) {
                        reverseHP.SetActive(false);
                    }
                break;
                case "maxSTA":
                    if (playerscript.maxSTA > defaultMaxSTA) {
                        playerscript.maxSTA -= 10;
                        playerscript.attributePoints += 1;
                    }
                    if (playerscript.maxSTA == defaultMaxSTA) {
                        reverseSTA.SetActive(false);
                    }
                break;
                /*case "maxMAG":
                    if (playerscript.maxSTA > 100) {
                        playerscript.maxSTA -= 10;
                        playerscript.attributePoints += 1;
                    }
                    if (playerscript.maxSTA == 100) {
                        reverseSTA.SetActive(false);
                    }
                break;*/
                case "maxSTR":
                    if (playerscript.maxSTR > defaultMaxSTR) {
                        playerscript.maxSTR -= 10;
                        playerscript.attributePoints += 1;
                    }
                    if (playerscript.maxSTR == defaultMaxSTR) {
                        reverseSTR.SetActive(false);
                    }
                break;
                case "maxDEX":
                    if (playerscript.maxDEX > defaultMaxDEX) {
                        playerscript.maxDEX -= 10;
                        playerscript.attributePoints += 1;
                    }
                    if (playerscript.maxDEX == defaultMaxDEX) {
                        reverseDEX.SetActive(false);
                    }
                break;
                case "maxAGI":
                    if (playerscript.maxAGI > defaultMaxAGI) {
                        playerscript.maxAGI -= 10;
                        playerscript.attributePoints += 1;
                    }
                    if (playerscript.maxAGI == defaultMaxAGI) {
                        reverseAGI.SetActive(false);
                    }
                break;
                case "maxINT":
                    if (playerscript.maxINT > defaultMaxINT) {
                        playerscript.maxINT -= 10;
                        playerscript.attributePoints += 1;
                    }
                    if (playerscript.maxINT == defaultMaxINT) {
                        reverseINT.SetActive(false);
                    }
                break;

                    
            }           
        }
    }

    /*public void OnPointerEnter(PointerEventData eventData)
    {
        GetComponent<Text>().color = Color.gray; // Changes the colour of the text
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        GetComponent<Text>().color = Color.black; // Changes the colour of the text
    }*/
}
