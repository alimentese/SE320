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
        //boxcollider = GetComponent<BoxCollider2D>();
    }

    public Item() {

    }


    
    /*public int itemAmountt { get; set; }
    public string itemName { get; set; } */
    public enum ItemType
    {
        kilic,
        sword,
        sword2,
        sword3,
        armor,
        armor2,
        armor3,
        helmet,
        helmet2,
        helmet3,
        shoes,
        shoes2,
        point,
        HealthPotion,
        ManaPotion,
        StaminaPotion,
        StrengthPotion,
    }

    BoxCollider2D boxcollider;

    public ItemType itemType;
    public int itemAmountt;
    public string itemName;

    public int itemHP;
    public int itemSTA;
    public int itemMAG;
    public int itemSTR;
    public int itemDEX;
    public int itemAGI;
    public int itemINT;


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


    public InventoryUI ui;
    public List<GameObject> slots;
    private GameObject slot1;
    private GameObject slot2;
    private GameObject slot3;
    private GameObject slot4;
    private GameObject slot5;
    private GameObject slot6;
    private GameObject slot7;
    private GameObject slot8;
    private GameObject slot9;
    private GameObject slot10;
    private GameObject slot11;
    private GameObject slot12;

    private GameObject playerObject;
    private PlayerScript player;
       
    public Sprite GetSprite() {
        switch (itemType) {
            default:
            case ItemType.sword: return ItemAssets.Instance.swordSprite;
            case ItemType.kilic: return ItemAssets.Instance.sword2Sprite;
            case ItemType.sword3: return ItemAssets.Instance.sword3Sprite;
            case ItemType.armor: return ItemAssets.Instance.armorSprite;
            case ItemType.armor2: return ItemAssets.Instance.armor2Sprite;
            case ItemType.armor3: return ItemAssets.Instance.armor3Sprite;
            case ItemType.helmet: return ItemAssets.Instance.helmetSprite;
            case ItemType.helmet2: return ItemAssets.Instance.helmet2Sprite;
            case ItemType.helmet3: return ItemAssets.Instance.helmet3Sprite;
            case ItemType.shoes: return ItemAssets.Instance.shoesSprite;
            case ItemType.shoes2: return ItemAssets.Instance.shoes2Sprite;
            case ItemType.point: return ItemAssets.Instance.point;
            case ItemType.HealthPotion: return ItemAssets.Instance.healthPotionSprite; // icon 102
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
        if (itemType == ItemType.sword || itemType == ItemType.sword2 || itemType == ItemType.sword3) {            
            if(itemWorn == false) {
                uiequipment.AddItem(FindIteminInventory(gameObject.transform.GetComponent<Item>().itemName));                
                this.gameObject.transform.parent = hand.transform;
                this.gameObject.transform.position = hand.transform.position;
                player.currentSTR += gameObject.transform.GetComponent<Item>().itemSTR;
                player.maxSTR += gameObject.transform.GetComponent<Item>().itemSTR;               
                //Destroy(gameObject);
                player.GetComponent<PlayerScript>().playerInventory.RemoveItem(gameObject.transform.GetComponent<Item>().itemName);
                Debug.Log("item silindi!");                
                itemWorn = true;
            } else if (itemWorn == true) {
                inventory.AddItem(FindIteminEquipment(gameObject.transform.GetComponent<Item>().itemName));
                uiequipment.RemoveItem("Sword");

                player.GetComponent<PlayerScript>().playerInventory.RemoveItem(gameObject.transform.GetComponent<Item>().itemName);
                // this.gameObject.transform.parent = slot1.transform;
                // this.gameObject.transform.position = slot1.transform.position;
                for (int i = 0; i < slots.Count; i++) {
                    if (slots[i].transform.childCount == 0) {
                        this.gameObject.transform.parent = slots[i].transform;
                        this.gameObject.transform.position = slots[i].transform.position;
                        break;
                    }
                }
                player.currentSTR -= gameObject.transform.GetComponent<Item>().itemSTR;
                player.maxSTR -= gameObject.transform.GetComponent<Item>().itemSTR;
                itemWorn = false;
                Debug.Log("equipment tıklanabiliyor");
            }               
        }
        if (itemType == ItemType.armor || itemType == ItemType.armor2 || itemType == ItemType.armor3) {
            if (itemWorn == false) {
                uiequipment.AddItem(FindIteminInventory(gameObject.transform.GetComponent<Item>().itemName));
                this.gameObject.transform.parent = chest.transform;
                this.gameObject.transform.position = chest.transform.position;
                player.currentSTR += gameObject.transform.GetComponent<Item>().itemSTR;
                player.maxSTR += gameObject.transform.GetComponent<Item>().itemSTR;

                player.currentDEX += gameObject.transform.GetComponent<Item>().itemDEX;
                player.maxDEX += gameObject.transform.GetComponent<Item>().itemDEX;

                player.currentAGI += gameObject.transform.GetComponent<Item>().itemAGI;
                player.maxAGI += gameObject.transform.GetComponent<Item>().itemAGI;

                player.currentHP += gameObject.transform.GetComponent<Item>().itemHP;
                player.maxHP += gameObject.transform.GetComponent<Item>().itemHP;

                player.currentSTA += gameObject.transform.GetComponent<Item>().itemSTA;
                player.currentSTA += gameObject.transform.GetComponent<Item>().itemSTA;
                //Destroy(gameObject);
                player.GetComponent<PlayerScript>().playerInventory.RemoveItem(gameObject.transform.GetComponent<Item>().itemName);
                Debug.Log("item silindi!");
                itemWorn = true;
            }
            else if (itemWorn == true) {
                inventory.AddItem(FindIteminEquipment(gameObject.transform.GetComponent<Item>().itemName));
                uiequipment.RemoveItem("Sword");

                player.GetComponent<PlayerScript>().playerInventory.RemoveItem(gameObject.transform.GetComponent<Item>().itemName);
                // this.gameObject.transform.parent = slot1.transform;
                // this.gameObject.transform.position = slot1.transform.position;
                for (int i = 0; i < slots.Count; i++) {
                    if (slots[i].transform.childCount == 0) {
                        this.gameObject.transform.parent = slots[i].transform;
                        this.gameObject.transform.position = slots[i].transform.position;
                        break;
                    }
                }
                player.currentSTR -= gameObject.transform.GetComponent<Item>().itemSTR;
                player.maxSTR -= gameObject.transform.GetComponent<Item>().itemSTR;

                player.currentDEX -= gameObject.transform.GetComponent<Item>().itemDEX;
                player.maxDEX -= gameObject.transform.GetComponent<Item>().itemDEX;

                player.currentAGI -= gameObject.transform.GetComponent<Item>().itemAGI;
                player.maxAGI -= gameObject.transform.GetComponent<Item>().itemAGI;

                player.currentHP -= gameObject.transform.GetComponent<Item>().itemHP;
                player.maxHP -= gameObject.transform.GetComponent<Item>().itemHP;

                player.currentSTA -= gameObject.transform.GetComponent<Item>().itemSTA;
                player.currentSTA -= gameObject.transform.GetComponent<Item>().itemSTA;
                itemWorn = false;
                Debug.Log("equipment tıklanabiliyor");
            }
        }
        if (itemType == ItemType.shoes || itemType == ItemType.shoes2) {
            if (itemWorn == false) {
                uiequipment.AddItem(FindIteminInventory(gameObject.transform.GetComponent<Item>().itemName));
                this.gameObject.transform.parent = pants.transform;
                this.gameObject.transform.position = pants.transform.position;
                player.currentSTR += gameObject.transform.GetComponent<Item>().itemSTR;
                player.maxSTR += gameObject.transform.GetComponent<Item>().itemSTR;

                player.currentDEX += gameObject.transform.GetComponent<Item>().itemDEX;
                player.maxDEX += gameObject.transform.GetComponent<Item>().itemDEX;

                player.currentAGI += gameObject.transform.GetComponent<Item>().itemAGI;
                player.maxAGI += gameObject.transform.GetComponent<Item>().itemAGI;

                player.currentHP += gameObject.transform.GetComponent<Item>().itemHP;
                player.maxHP += gameObject.transform.GetComponent<Item>().itemHP;

                player.currentSTA += gameObject.transform.GetComponent<Item>().itemSTA;
                player.currentSTA += gameObject.transform.GetComponent<Item>().itemSTA;
                //Destroy(gameObject);
                player.GetComponent<PlayerScript>().playerInventory.RemoveItem(gameObject.transform.GetComponent<Item>().itemName);
                Debug.Log("item silindi!");
                itemWorn = true;
            }
            else if (itemWorn == true) {
                inventory.AddItem(FindIteminEquipment(gameObject.transform.GetComponent<Item>().itemName));
                uiequipment.RemoveItem("Sword");

                player.GetComponent<PlayerScript>().playerInventory.RemoveItem(gameObject.transform.GetComponent<Item>().itemName);
                // this.gameObject.transform.parent = slot1.transform;
                // this.gameObject.transform.position = slot1.transform.position;
                for (int i = 0; i < slots.Count; i++) {
                    if (slots[i].transform.childCount == 0) {
                        this.gameObject.transform.parent = slots[i].transform;
                        this.gameObject.transform.position = slots[i].transform.position;
                        break;
                    }
                }
                player.currentSTR -= gameObject.transform.GetComponent<Item>().itemSTR;
                player.maxSTR -= gameObject.transform.GetComponent<Item>().itemSTR;

                player.currentDEX -= gameObject.transform.GetComponent<Item>().itemDEX;
                player.maxDEX -= gameObject.transform.GetComponent<Item>().itemDEX;

                player.currentAGI -= gameObject.transform.GetComponent<Item>().itemAGI;
                player.maxAGI -= gameObject.transform.GetComponent<Item>().itemAGI;

                player.currentHP -= gameObject.transform.GetComponent<Item>().itemHP;
                player.maxHP -= gameObject.transform.GetComponent<Item>().itemHP;

                player.currentSTA -= gameObject.transform.GetComponent<Item>().itemSTA;
                player.currentSTA -= gameObject.transform.GetComponent<Item>().itemSTA;
                itemWorn = false;
                Debug.Log("equipment tıklanabiliyor");
            }
        }
        if (itemType == ItemType.helmet || itemType == ItemType.helmet2 || itemType == ItemType.helmet3) {
            if (itemWorn == false) {
                uiequipment.AddItem(FindIteminInventory(gameObject.transform.GetComponent<Item>().itemName));
                this.gameObject.transform.parent = head.transform;
                this.gameObject.transform.position = head.transform.position;
                player.currentSTR += gameObject.transform.GetComponent<Item>().itemSTR;
                player.maxSTR += gameObject.transform.GetComponent<Item>().itemSTR;

                player.currentDEX += gameObject.transform.GetComponent<Item>().itemDEX;
                player.maxDEX += gameObject.transform.GetComponent<Item>().itemDEX;

                player.currentAGI += gameObject.transform.GetComponent<Item>().itemAGI;
                player.maxAGI += gameObject.transform.GetComponent<Item>().itemAGI;

                player.currentHP += gameObject.transform.GetComponent<Item>().itemHP;
                player.maxHP += gameObject.transform.GetComponent<Item>().itemHP;

                player.currentSTA += gameObject.transform.GetComponent<Item>().itemSTA;
                player.currentSTA += gameObject.transform.GetComponent<Item>().itemSTA;
                //Destroy(gameObject);
                player.GetComponent<PlayerScript>().playerInventory.RemoveItem(gameObject.transform.GetComponent<Item>().itemName);
                Debug.Log("item silindi!");
                itemWorn = true;
            }
            else if (itemWorn == true) {
                inventory.AddItem(FindIteminEquipment(gameObject.transform.GetComponent<Item>().itemName));
                uiequipment.RemoveItem("Sword");

                player.GetComponent<PlayerScript>().playerInventory.RemoveItem(gameObject.transform.GetComponent<Item>().itemName);
                // this.gameObject.transform.parent = slot1.transform;
                // this.gameObject.transform.position = slot1.transform.position;
                for (int i = 0; i < slots.Count; i++) {
                    if (slots[i].transform.childCount == 0) {
                        this.gameObject.transform.parent = slots[i].transform;
                        this.gameObject.transform.position = slots[i].transform.position;
                        break;
                    }
                }
                player.currentSTR -= gameObject.transform.GetComponent<Item>().itemSTR;
                player.maxSTR -= gameObject.transform.GetComponent<Item>().itemSTR;

                player.currentDEX -= gameObject.transform.GetComponent<Item>().itemDEX;
                player.maxDEX -= gameObject.transform.GetComponent<Item>().itemDEX;

                player.currentAGI -= gameObject.transform.GetComponent<Item>().itemAGI;
                player.maxAGI -= gameObject.transform.GetComponent<Item>().itemAGI;

                player.currentHP -= gameObject.transform.GetComponent<Item>().itemHP;
                player.maxHP -= gameObject.transform.GetComponent<Item>().itemHP;

                player.currentSTA -= gameObject.transform.GetComponent<Item>().itemSTA;
                player.maxSTA -= gameObject.transform.GetComponent<Item>().itemSTA;
                itemWorn = false;
                Debug.Log("equipment tıklanabiliyor");
            }
        }


    }
    
    public void DescOpen() {
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

    public void CloseDesc () {
        itemDesc.SetActive(false);
    }

    private void Awake() {
        //DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {

        slot1 = GameObject.Find("slot (1)");
        slot2 = GameObject.Find("slot (2)");
        slot3 = GameObject.Find("slot (3)");
        slot4 = GameObject.Find("slot (4)");
        slot5 = GameObject.Find("slot (5)");
        slot6 = GameObject.Find("slot (6)");
        slot7 = GameObject.Find("slot (7)");
        slot8 = GameObject.Find("slot (8)");
        slot9 = GameObject.Find("slot (9)");
        slot10 = GameObject.Find("slot (10)");
        slot11 = GameObject.Find("slot (11)");
        slot12 = GameObject.Find("slot (12)");

        slots = new List<GameObject> {
            slot1,
            slot2,
            slot3,
            slot4,
            slot5,
            slot6,
            slot7,
            slot8,
            slot9,
            slot10,
            slot11,
            slot12
        };

        playerObject = GameObject.FindGameObjectWithTag("Player");
        player = playerObject.GetComponent<PlayerScript>();
        uiequipment = playerObject.GetComponent<PlayerScript>().playerEquipment;
        inventory = playerObject.GetComponent<PlayerScript>().playerInventory;
        boxcollider = itemPrefab.GetComponent<BoxCollider2D>();
         

        head = GameObject.FindGameObjectWithTag("head");
        chest = GameObject.FindGameObjectWithTag("chest");
        hand = GameObject.FindGameObjectWithTag("hand");
        pants = GameObject.FindGameObjectWithTag("pants");

        slot1 = GameObject.FindGameObjectWithTag("inventorySlot1"); //?

        itemDescPopup = GameObject.FindGameObjectWithTag("itemDesc");
        itemDesc = itemDescPopup.transform.GetChild(0).gameObject;
        itemdescname = itemDesc.transform.GetChild(1).gameObject.GetComponent<Text>();
        itemdescbonus = itemDesc.transform.GetChild(2).gameObject.GetComponent<Text>();




        Debug.Log("Item STR: " + gameObject.GetComponent<Item>().itemSTR);


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
