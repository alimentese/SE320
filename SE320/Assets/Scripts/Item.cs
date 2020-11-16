using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{

    public Item (string name, int amount) {
        itemName = name;
        itemAmountt = amount;

    }

    public Item() {

    }
    /*public int itemAmountt { get; set; }
    public string itemName { get; set; } */
    public enum ItemType
    {
        sword,
        HealthPotion,
        ManaPotion,
        StaminaPotion,
        StrengthPotion,
    }

    public enum Sa
    {
        selamunaleykum,
    }

    public Sa sa;

    public ItemType itemType;
    public int itemAmountt;
    public string itemName;

    // For UI Item
    //[SerializeField] private GameObject name;
    [SerializeField] private GameObject icon;
    [SerializeField] private GameObject level;
    [SerializeField] private GameObject quality;
    // [SerializeField] private GameObject amountt;
    private GameObject playerObject;

    private PlayerScript player;
    



   /* public Item(int ItemType) {
        if(ItemType == 1) {
            itemPrefab.GetComponent<Item>().itemType = Item.ItemType.sword;
            itemPrefab.GetComponent<Item>().itemName = "sword";

        }
        else {
            itemPrefab.GetComponent<Item>().itemType = Item.ItemType.HealthPotion;
            itemPrefab.GetComponent<Item>().itemName = "Healt Potion";
        }
        
    }*/


    [SerializeField] private GameObject itemPrefab;

    



    

    

    public Sprite GetSprite() {
        switch (itemType) {
            default:
            case ItemType.sword: return ItemAssets.Instance.swordSprite;
            case ItemType.HealthPotion: return ItemAssets.Instance.healthPotionSprite;
            case ItemType.StaminaPotion: return ItemAssets.Instance.staminaPotionSprite;


        }

    }   
    
    public void UseItem() { // ItemType itemType
        if (itemType == ItemType.StaminaPotion) {
            Debug.Log("stamina potion is used!");
            if(playerObject.GetComponent<PlayerScript>().currentSTA < playerObject.GetComponent<PlayerScript>().maxSTA) {
                playerObject.GetComponent<PlayerScript>().currentSTA += 30;
                if(playerObject.GetComponent<PlayerScript>().currentSTA > playerObject.GetComponent<PlayerScript>().maxSTA) {
                    playerObject.GetComponent<PlayerScript>().currentSTA = playerObject.GetComponent<PlayerScript>().maxSTA;
                }
                itemAmountt--;
            }
            
        }
        if(itemType == ItemType.HealthPotion) {
            Debug.Log("health potion is used!");
            playerObject.GetComponent<PlayerScript>().currentHP += 30;
        }
    }
    
    
    // Start is called before the first frame update
        void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        icon.GetComponent<Image>().sprite = GetSprite();
    }
}
