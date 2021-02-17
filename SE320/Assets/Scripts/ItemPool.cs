using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ItemPool : MonoBehaviour
{

    private List<Item> itemPoolList;
    private ItemPool itemPoolReference;
    public GameObject itemPoolUi;
    public GameObject newItem;
    [SerializeField] private GameObject itemPrefab;
    


    public ItemPool() {
        itemPoolList = new List<Item>();
    }

    public void setItemPool(ItemPool itemPool) {
        this.itemPoolReference = itemPool;
    }

    public void AddItem(Item item) {
        itemPoolList.Add(item);
    }

    public List<Item> GetItemPoolList() {
        return itemPoolList;
    }



    public void spawnItem(string name) {
        foreach (Item item in itemPoolReference.GetItemPoolList()) {
            if(item.itemName == name) {
                newItem = Instantiate(itemPrefab);
                newItem.GetComponent<Item>().itemType = item.itemType;
                newItem.GetComponent<Item>().itemName = item.itemName;
                newItem.GetComponent<Item>().itemAmountt = item.itemAmountt;
                newItem.GetComponent<Item>().itemSTR = item.itemSTR;
                newItem.transform.parent = itemPoolUi.transform;
                newItem.gameObject.name = item.itemName;
                newItem.SetActive(false);
            }
        }
    }



    // Start is called before the first frame update
    void Start()
    {
        ItemPool itempool = new ItemPool();
        setItemPool(itempool);
        itempool.AddItem(new Item {
            itemType = Item.ItemType.sword,
            itemAmountt = 1,
            itemName = "sword",
            itemWorn = false,
            itemSTR = 5,
            
        });
        itempool.AddItem(new Item {
            itemType = Item.ItemType.sword2,
            itemAmountt = 1,
            itemName = "sword2",
            itemWorn = false,
            itemSTR = 10,

        });
        itempool.AddItem(new Item {
            itemType = Item.ItemType.sword3,
            itemAmountt = 1,
            itemName = "sword3",
            itemWorn = false,
            itemSTR = 15,
        });


        itempool.AddItem(new Item {
            itemType = Item.ItemType.armor,
            itemAmountt = 1,
            itemName = "armor",
            itemWorn = false,
            itemDEX = 7,
            itemAGI = 10
        });
        itempool.AddItem(new Item {
            itemType = Item.ItemType.armor2,
            itemAmountt = 1,
            itemName = "armor2",
            itemWorn = false,
            itemDEX = 10,
            itemAGI = 4
        });
        itempool.AddItem(new Item {
            itemType = Item.ItemType.armor3,
            itemAmountt = 1,
            itemName = "armor3",
            itemWorn = false,
            itemDEX = 15,
            itemAGI = 1
        });


        itempool.AddItem(new Item {
            itemType = Item.ItemType.helmet,
            itemAmountt = 1,
            itemName = "helmet",
            itemWorn = false,
            itemDEX = 4,
            itemAGI = 3
        });
        itempool.AddItem(new Item {
            itemType = Item.ItemType.helmet2,
            itemAmountt = 1,
            itemName = "helmet2",
            itemWorn = false,
            itemDEX = 6,
            itemAGI = 2
        });
        itempool.AddItem(new Item {
            itemType = Item.ItemType.helmet3,
            itemAmountt = 1,
            itemName = "helmet3",
            itemWorn = false,
            itemDEX = 8,
            itemAGI = 1
        });


        itempool.AddItem(new Item {
            itemType = Item.ItemType.shoes,
            itemAmountt = 1,
            itemName = "shoes",
            itemWorn = false,
            itemDEX = 2,
            itemAGI = 5
        });
        itempool.AddItem(new Item {
            itemType = Item.ItemType.shoes2,
            itemAmountt = 1,
            itemName = "shoes2",
            itemWorn = false,
            itemDEX = 3,
            itemAGI = 6
        });


        itempool.AddItem(new Item {
            itemType = Item.ItemType.point,
            itemAmountt = 1,
            itemName = "point",
            itemWorn = false,
            itemSTR = 10,
        });

        itempool.AddItem(new Item {
            itemType = Item.ItemType.HealthPotion,
            itemAmountt = 5,
            itemName = "health potion",
        });
        itempool.AddItem(new Item {
            itemType = Item.ItemType.StaminaPotion,
            itemAmountt = 10,
            itemName = "stamina potion"
        });

        spawnItem("sword");
        spawnItem("sword2");
        spawnItem("sword3");
        spawnItem("armor");
        spawnItem("armor2");
        spawnItem("armor3");
        spawnItem("helmet");
        spawnItem("helmet2");
        spawnItem("helmet3");
        spawnItem("shoes");
        spawnItem("shoes2");
        spawnItem("point");
        spawnItem("shoes");
        spawnItem("stamina potion");
        spawnItem("health potion");




    }
    /*
     *  ITEM LIST
     * ID, TYPE, NAME, AMOUNT, 
     * ID: 1
     * TYPE: WEAPON
     * 
     * 
     */
    // Update is called once per frame
    void Update()
    {
        
    }

}
