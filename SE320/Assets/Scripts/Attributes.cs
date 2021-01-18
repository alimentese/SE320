using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // This is so that it should find the Text component
using UnityEngine.Events; // This is so that you can extend the pointer handlers
using UnityEngine.EventSystems; // This is so that you can extend the pointer handlers


public class Attributes : MonoBehaviour
{
    // player knight prefab setup
    private GameObject playerGameObject;

    
    // needed texts for showing stats from ui
    public Text attributePoints;
    public Text hpNumber, staNumber, magNumber, strNumber, dexNumber, agiNumber, intNumber;


    // + and - Buttons
    public GameObject increaseHP,  decreaseHP;
    public GameObject increaseSTA, decreaseSTA;
    public GameObject increaseMAG, decreaseMAG;
    public GameObject increaseSTR, decreaseSTR;
    public GameObject increaseDEX, decreaseDEX;
    public GameObject increaseAGI, decreaseAGI;
    public GameObject increaseINT, decreaseINT;
    

    private int defaultMaxHP, defaultMaxSTA, defaultMaxMAG, defaultMaxSTR, defaultMaxDEX, defaultMaxAGI, defaultMaxINT, defaultAttributePoints;

    
    
// Start is called before the first frame update
    void Start()  {

        playerGameObject = GameObject.FindGameObjectWithTag("Player");
        //maxHP.gameObject.tag = "maxHP";
        //playerGameObject.GetComponent<PlayerScript>().defaultAttributes();
        defaultAttributePoints = playerGameObject.GetComponent<PlayerScript>().attributePoints;
        defaultMaxHP = playerGameObject.GetComponent<PlayerScript>().maxHP;
        defaultMaxSTA = playerGameObject.GetComponent<PlayerScript>().maxSTA;
        defaultMaxMAG = playerGameObject.GetComponent<PlayerScript>().maxMAG;
        defaultMaxSTR = playerGameObject.GetComponent<PlayerScript>().maxSTR;
        defaultMaxDEX = playerGameObject.GetComponent<PlayerScript>().maxDEX;
        defaultMaxAGI = playerGameObject.GetComponent<PlayerScript>().maxDEX;
        defaultMaxINT = playerGameObject.GetComponent<PlayerScript>().maxINT;

        decreaseHP.SetActive(false);
        decreaseSTA.SetActive(false);
        decreaseMAG.SetActive(false);
        decreaseSTR.SetActive(false);
        decreaseDEX.SetActive(false);
        decreaseAGI.SetActive(false);
        decreaseINT.SetActive(false);


    }

    // Update is called once per frame
    void Update()
    {

        attributePoints.text = playerGameObject.GetComponent<PlayerScript>().attributePoints.ToString();
        hpNumber.text = playerGameObject.GetComponent<PlayerScript>().maxHP.ToString();
        staNumber.text = playerGameObject.GetComponent<PlayerScript>().maxSTA.ToString();
        magNumber.text = playerGameObject.GetComponent<PlayerScript>().maxMAG.ToString();
        strNumber.text = playerGameObject.GetComponent<PlayerScript>().maxSTR.ToString();
        dexNumber.text = playerGameObject.GetComponent<PlayerScript>().maxDEX.ToString();
        agiNumber.text = playerGameObject.GetComponent<PlayerScript>().maxAGI.ToString();
        intNumber.text = playerGameObject.GetComponent<PlayerScript>().maxINT.ToString();

    }

    public void resetSkillPoint()
    {

    }

    public void increasePoint(GameObject stat)
    {       
        if (playerGameObject.GetComponent<PlayerScript>().attributePoints > 0) {
            playerGameObject.GetComponent<PlayerScript>().attributePoints -= 1;
            switch(stat.gameObject.tag) {
                case "maxHP":
                    playerGameObject.GetComponent<PlayerScript>().maxHP += 10;
                    decreaseHP.SetActive(true);
                break;
                case "maxSTA":
                    playerGameObject.GetComponent<PlayerScript>().maxSTA += 10;
                    decreaseSTA.SetActive(true);
                break;
                case "maxMAG":
                    playerGameObject.GetComponent<PlayerScript>().maxMAG += 10;
                    decreaseMAG.SetActive(true);
                break;
                case "maxSTR":
                    playerGameObject.GetComponent<PlayerScript>().maxSTR += 10;
                    decreaseSTR.SetActive(true);
                break;
                case "maxDEX":
                    playerGameObject.GetComponent<PlayerScript>().maxDEX += 10;
                    decreaseDEX.SetActive(true);
                break;
                case "maxAGI":
                    playerGameObject.GetComponent<PlayerScript>().maxAGI += 10;
                    decreaseAGI.SetActive(true);
                break;
                case "maxINT":
                    playerGameObject.GetComponent<PlayerScript>().maxINT += 10;
                    decreaseINT.SetActive(true);
                break;
            }
        }
        else if(playerGameObject.GetComponent<PlayerScript>().attributePoints == defaultAttributePoints) {
            decreaseSTA.SetActive(false);
            decreaseHP.SetActive(false);
            decreaseSTR.SetActive(false);
            decreaseDEX.SetActive(false);
            decreaseAGI.SetActive(false);
            decreaseINT.SetActive(false);
        }
       
    }

    public void decreasePoint(GameObject stat) {
        if (playerGameObject.GetComponent<PlayerScript>().attributePoints < defaultAttributePoints) {
            switch(stat.gameObject.tag) {
                case "maxHP":
                    if (playerGameObject.GetComponent<PlayerScript>().maxHP > defaultMaxHP) {
                        playerGameObject.GetComponent<PlayerScript>().maxHP -= 10;
                        playerGameObject.GetComponent<PlayerScript>().attributePoints += 1;
                    }
                    if(playerGameObject.GetComponent<PlayerScript>().maxHP == defaultMaxHP) {
                        decreaseHP.SetActive(false);
                    }
                break;
                case "maxSTA":
                    if (playerGameObject.GetComponent<PlayerScript>().maxSTA > defaultMaxSTA) {
                        playerGameObject.GetComponent<PlayerScript>().maxSTA -= 10;
                        playerGameObject.GetComponent<PlayerScript>().attributePoints += 1;
                    }
                    if (playerGameObject.GetComponent<PlayerScript>().maxSTA == defaultMaxSTA) {
                        decreaseSTA.SetActive(false);
                    }
                break;
                case "maxMAG":
                    if (playerGameObject.GetComponent<PlayerScript>().maxMAG > defaultMaxMAG) {
                        playerGameObject.GetComponent<PlayerScript>().maxMAG -= 10;
                        playerGameObject.GetComponent<PlayerScript>().attributePoints += 1;
                    }
                    if (playerGameObject.GetComponent<PlayerScript>().maxMAG == 100) {
                        decreaseSTA.SetActive(false);
                    }
                break;
                case "maxSTR":
                    if (playerGameObject.GetComponent<PlayerScript>().maxSTR > defaultMaxSTR) {
                        playerGameObject.GetComponent<PlayerScript>().maxSTR -= 10;
                        playerGameObject.GetComponent<PlayerScript>().attributePoints += 1;
                    }
                    if (playerGameObject.GetComponent<PlayerScript>().maxSTR == defaultMaxSTR) {
                        decreaseSTR.SetActive(false);
                    }
                break;
                case "maxDEX":
                    if (playerGameObject.GetComponent<PlayerScript>().maxDEX > defaultMaxDEX) {
                        playerGameObject.GetComponent<PlayerScript>().maxDEX -= 10;
                        playerGameObject.GetComponent<PlayerScript>().attributePoints += 1;
                    }
                    if (playerGameObject.GetComponent<PlayerScript>().maxDEX == defaultMaxDEX) {
                        decreaseDEX.SetActive(false);
                    }
                break;
                case "maxAGI":
                    if (playerGameObject.GetComponent<PlayerScript>().maxAGI > defaultMaxAGI) {
                        playerGameObject.GetComponent<PlayerScript>().maxAGI -= 10;
                        playerGameObject.GetComponent<PlayerScript>().attributePoints += 1;
                    }
                    if (playerGameObject.GetComponent<PlayerScript>().maxAGI == defaultMaxAGI) {
                        decreaseAGI.SetActive(false);
                    }
                break;
                case "maxINT":
                    if (playerGameObject.GetComponent<PlayerScript>().maxINT > defaultMaxINT) {
                        playerGameObject.GetComponent<PlayerScript>().maxINT -= 10;
                        playerGameObject.GetComponent<PlayerScript>().attributePoints += 1;
                    }
                    if (playerGameObject.GetComponent<PlayerScript>().maxINT == defaultMaxINT) {
                        decreaseINT.SetActive(false);
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
