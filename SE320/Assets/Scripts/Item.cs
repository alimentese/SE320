using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    private GameObject head, chest, hand, pants;
    public GameObject itemPopupObject;
    public Item temp, temp2;

    private Vector3 mousePosition;
    public float moveSpeed = 0.1f;

    public Item (string name, int amount, int str) {
        itemName = name;
        itemAmountt = amount;
        itemSTR = str;
        boxcollider = GetComponent<BoxCollider2D>();
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

    BoxCollider2D boxcollider;

    public ItemType itemType;
    public int itemAmountt;
    public string itemName;
    public int itemSTR;
    public bool itemWorn;
    private Equipment uiequipment;
    private Inventory inventory;

    // For UI Item
    //[SerializeField] private GameObject name;
    [SerializeField] private GameObject icon;
    [SerializeField] private GameObject level;
    [SerializeField] private GameObject quality;
    [SerializeField] private GameObject itemPrefab;

    public GameObject itemDescPopup;
    public GameObject itemDesc;


    public GameObject itemDescName;
    public GameObject itemDescBonus;
    public Text itemdescname;
    public Text itemdescbonus;


    public GameObject slot1;
    [SerializeField] public GameObject slot2;
    [SerializeField] public GameObject slot3;
    [SerializeField] public GameObject slot4;
    [SerializeField] public GameObject slot5;
    [SerializeField] private GameObject slot6;
    [SerializeField] private GameObject slot7;
    [SerializeField] private GameObject slot8;
    [SerializeField] private GameObject slot9;
    [SerializeField] private GameObject slot10;
    [SerializeField] private GameObject slot11;
    [SerializeField] private GameObject slot12;

    private GameObject playerObject;
    private PlayerScript player;
       
    public Sprite GetSprite() {
        switch (itemType) {
            default:
            case ItemType.sword: return ItemAssets.Instance.swordSprite;
            case ItemType.HealthPotion: return ItemAssets.Instance.healthPotionSprite;
            case ItemType.StaminaPotion: return ItemAssets.Instance.staminaPotionSprite;


        }

    }

    public Item FindIteminInventory(string name) {       
        for (int i = 0; i < inventory.GetItemList().Count; i++) {
            if (inventory.GetItemList()[i].itemName == name) {
                temp = inventory.GetItemList()[i];              
            }
        }
        return temp;
    }

    public Item FindIteminEquipment(string name) {
        for (int i = 0; i < uiequipment.GetItemList().Count; i++) {
            if (uiequipment.GetItemList()[i].itemName == name) {
                temp2 = uiequipment.GetItemList()[i];
            }
        }
        return temp2;
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
        if (itemType == ItemType.sword) {            
            if(itemWorn == false) {
                
                uiequipment.AddItem(FindIteminInventory("sword"));
                inventory.RemoveItem("sword");
                this.gameObject.transform.parent = hand.transform;
                this.gameObject.transform.position = hand.transform.position;
                player.currentSTR += 10;
                player.maxSTR += 10;

                itemWorn = true;
            } else if (itemWorn == true) {
                inventory.AddItem(FindIteminEquipment("sword"));
                uiequipment.RemoveItem("sword");
                this.gameObject.transform.parent = slot1.transform;
                this.gameObject.transform.position = slot1.transform.position;
                player.currentSTR -= 10;
                player.maxSTR -= 10;

                itemWorn = false;
                Debug.Log("equipment tıklanabiliyor");
            }               
        }

    }
    
    public void itemPickUp() {
    }

    public void sa() {
        Debug.Log("Item name: "+ this.gameObject.GetComponent<Item>().itemName);
        itemdescname.text = "Name: " + this.gameObject.GetComponent<Item>().itemName;
        itemdescbonus.text = "Bonus: " + this.gameObject.GetComponent<Item>().itemSTR;
        if(!itemWorn) {
            mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            itemDesc.transform.position = Vector2.Lerp(transform.position, mousePosition, moveSpeed);
            itemDesc.transform.position = new Vector2(itemDesc.transform.position.x + 300, itemDesc.transform.position.y -90);
        }
        else {
            mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            itemDesc.transform.position = Vector2.Lerp(transform.position, mousePosition, moveSpeed);
            itemDesc.transform.position = new Vector2(itemDesc.transform.position.x + 175, itemDesc.transform.position.y - 90);
        }

        itemDesc.SetActive(true);
        
    }

    public void As () {
        itemDesc.SetActive(false);
    }

    private void Awake() {
        //DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
        playerObject = GameObject.FindGameObjectWithTag("Player");
        player = playerObject.GetComponent<PlayerScript>();
        uiequipment = playerObject.GetComponent<PlayerScript>().playerEquipment;
        inventory = playerObject.GetComponent<PlayerScript>().playerInventory;
        boxcollider = itemPrefab.GetComponent<BoxCollider2D>();
        itemDescPopup = GameObject.FindGameObjectWithTag("itemDesc");
        itemDesc = itemDescPopup.transform.GetChild(0).gameObject;




        head = GameObject.FindGameObjectWithTag("head");
        chest = GameObject.FindGameObjectWithTag("chest");
        hand = GameObject.FindGameObjectWithTag("hand");
        pants = GameObject.FindGameObjectWithTag("pants");

        slot1 = GameObject.FindGameObjectWithTag("inventorySlot1"); //?

        itemdescname = itemDesc.transform.GetChild(1).gameObject.GetComponent<Text>();
        itemdescbonus = itemDesc.transform.GetChild(2).gameObject.GetComponent<Text>();







    }

    // Update is called once per frame
    void Update()
    {
        icon.GetComponent<Image>().sprite = GetSprite(); // For UI
        icon.GetComponent<SpriteRenderer>().sprite = GetSprite(); // For ingame screen  
      
    }


    private void OnMouseOver() {
        //itemPopupObject.SetActive(true);
        Debug.Log("mouse girdi");
    }

    private void OnMouseExit() {
        //itemPopupObject.SetActive(false);

    }



}
