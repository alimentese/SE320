using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    private List<Item> itemList;
    private Inventory inventory;

    [SerializeField] private GameObject player;
    [SerializeField] private GameObject slot1;
    [SerializeField] private GameObject slot2;
    [SerializeField] private GameObject slot3;
    [SerializeField] private GameObject slot4;
    [SerializeField] private GameObject slot5;
    [SerializeField] private GameObject slot6;
    [SerializeField] private GameObject slot7;
    [SerializeField] private GameObject slot8;
    [SerializeField] private GameObject slot9;
    [SerializeField] private GameObject slot10;
    [SerializeField] private GameObject slot11;
    [SerializeField] private GameObject slot12;

    [SerializeField] private GameObject itemPrefabb;
    private GameObject newItem;

    private Item itemscript;

    public Inventory() {
        itemList = new List<Item>();
        /*Debug.Log("Inventory");
        AddItem(new Item {
            itemType = Item.ItemType.HealthPotion,
            amount = 5
        });
        AddItem(new Item {
            itemType = Item.ItemType.HealthPotion,
            amount = 5
        });
        Debug.Log(itemList.Count);*/
    }

    public void setInventory(Inventory inventory) {
        this.inventory = inventory;
    }

    public void AddItem(Item item) {
        itemList.Add(item);
    }

    public void RemoveItem(string name) {
        for (int i = 0; i < itemList.Count; i++) {
            if(itemList[i].itemName == name) {
                itemList.RemoveAt(i);
                
            }
        }
    }

    public void CountItems() {
        Debug.Log("toplam item: " + itemList.Count);
    }

    public List<Item> GetItemList() {
        return itemList;
    }

    public void printList() {
        for(int i = 0; i < itemList.Count; i++) {
            Debug.Log(itemList[i]);
        }
    }


    public void searchItem(string name) {
        for (int i = 0; i < itemList.Count; i++) {
            if(itemList[i].itemName == name) {
                Debug.Log("Item found at " + i + ".slot.");
            }
        }

    }



    public void RefreshInventory() {
        Debug.Log("inventory calisiyor");
        inventory.CountItems();
        foreach (Item itemInventory in inventory.GetItemList()) {
            if (slot1.transform.childCount == 0) {
                Vector3 newPosition = new Vector3(47, -47, 0);
                newItem = Instantiate(itemPrefabb);
                newItem.GetComponent<Item>().itemType = itemInventory.itemType;
                newItem.GetComponent<Item>().itemAmountt = itemInventory.itemAmountt;
                newItem.GetComponent<Item>().itemName = itemInventory.itemName;


                newItem.transform.parent = slot1.transform;
                newItem.transform.localPosition = newPosition;
                Debug.Log("slot 1");
            }
            else if (slot2.transform.childCount == 0) {
                Vector3 newPosition = new Vector3(47, -47, 0);
                newItem = Instantiate(itemPrefabb);
                newItem.GetComponent<Item>().itemType = itemInventory.itemType;
                newItem.GetComponent<Item>().itemAmountt = itemInventory.itemAmountt;
                newItem.GetComponent<Item>().itemName = itemInventory.itemName;



                newItem.transform.parent = slot2.transform;
                newItem.transform.localPosition = newPosition;
                Debug.Log("slot 2");
            }
            else if (slot3.transform.childCount == 0) {
                Vector3 newPosition = new Vector3(47, -47, 0);
                newItem = Instantiate(itemPrefabb);
                newItem.GetComponent<Item>().itemType = itemInventory.itemType;
                newItem.GetComponent<Item>().itemAmountt = itemInventory.itemAmountt;
                newItem.GetComponent<Item>().itemName = itemInventory.itemName;



                newItem.transform.parent = slot3.transform;
                newItem.transform.localPosition = newPosition;
                Debug.Log("slot 3");
            }
            else if (slot4.transform.childCount == 0) {
                Vector3 newPosition = new Vector3(47, -47, 0);
                newItem = Instantiate(itemPrefabb);
                newItem.GetComponent<Item>().itemType = itemInventory.itemType;
                newItem.GetComponent<Item>().itemAmountt = itemInventory.itemAmountt;
                newItem.GetComponent<Item>().itemName = itemInventory.itemName;



                newItem.transform.parent = slot4.transform;
                newItem.transform.localPosition = newPosition;
                Debug.Log("slot 4");
            }
            else {
                Debug.Log("inventory full");
            }

        }
    }

    // Start is called before the first frame update
    public void Start() {
        itemscript = itemPrefabb.GetComponent<Item>();
        inventory.AddItem(new Item {
            itemType = Item.ItemType.sword,
            itemAmountt = 5,
            itemName = "sword",

        });

        inventory.AddItem(new Item {
            itemType = Item.ItemType.HealthPotion,
            itemAmountt = 5,
            itemName = "sword",

        });

        inventory.AddItem(new Item {
            itemType = Item.ItemType.StaminaPotion,
            itemAmountt = 10,
            itemName = "sta"
        });

       

        inventory.printList();
        Debug.Log("-----------");
        inventory.searchItem("sta");
        inventory.RemoveItem("sta");

        RefreshInventory();
        
        //CountItems();
        /* inventory.AddItem(new Item {
             itemType = Item.ItemType.HealthPotion,
             amount = 5
         });*/
        //inventory = player.GetComponents<PlayerScript>().
        //playerrScript = player.GetComponent<PlayerScript>();
        //playerrScript.playerInventory
    }

    // Update is called once per frame
    public void Update()
    {
        
        
        Debug.Log("amount tesT: " + slot2.transform.GetComponentInChildren<Item>().itemAmountt);

    }
}
