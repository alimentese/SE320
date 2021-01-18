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
            itemSTR = 10        
    });
        itempool.AddItem(new Item {
            itemType = Item.ItemType.HealthPotion,
            itemAmountt = 5,
            itemName = "health potion",
        });
        itempool.AddItem(new Item {
            itemType = Item.ItemType.StaminaPotion,
            itemAmountt = 10,
            itemName = "sta"
        });
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

    public void nextload() {
        LoadingScreen.scene = "Level 1";
        SceneManager.LoadScene("Loading Screen");
    }
}
