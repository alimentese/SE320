using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : MonoBehaviour
{
    // Start is called before the first frame update

    private GameObject head, chest, hand, pants, player;
    [SerializeField] private GameObject itemPopupObject;
    private Equipment PlayerEquipment;
    private List<Item> ItemsInEquipment;

    public Equipment () {
        ItemsInEquipment = new List<Item>();
    }

    public void setEquipment(Equipment equipment) {
        this.PlayerEquipment = equipment;
    }

    public List<Item> GetItemList() {
        return ItemsInEquipment;
    }

    public void AddItem(Item item) {
        ItemsInEquipment.Add(item);
    }

    public void RemoveItem(string name) {
        for (int i = 0; i < ItemsInEquipment.Count; i++) {
            if (ItemsInEquipment[i].itemName == name) {
                ItemsInEquipment.RemoveAt(i);
            }
        }
    }

    public void CountItems() {
        Debug.Log("toplam equipment item: " + ItemsInEquipment.Count);
    }

    private void Awake() {
        //DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        head = GameObject.FindGameObjectWithTag("head");
        chest = GameObject.FindGameObjectWithTag("chest");
        hand = GameObject.FindGameObjectWithTag("hand");
        pants = GameObject.FindGameObjectWithTag("pants");
    }

    // Update is called once per frame
    void Update() {
        
    }

    /* public void RefreshEquipment() {
        foreach (Item itemEquipment in PlayerEquipment.GetItemList()) {
            if (head.transform.childCount == 0) {

                Debug.Log("slot 1");
            }
            else if (chest.transform.childCount == 0) {
                Vector3 newPosition = new Vector3(3, -3, 0);
                newItem = Instantiate(itemPrefabb);
                newItem.GetComponent<Item>().itemType = itemInventory.itemType;
                newItem.GetComponent<Item>().itemAmountt = itemInventory.itemAmountt;
                newItem.GetComponent<Item>().itemName = itemInventory.itemName;



                newItem.transform.parent = slot2.transform;
                newItem.transform.localPosition = newPosition;
                Debug.Log("slot 2");
            }
            else if (hand.transform.childCount == 0) {
                Vector3 newPosition = new Vector3(3, -3, 0);
                newItem = Instantiate(itemPrefabb);
                newItem.GetComponent<Item>().itemType = itemInventory.itemType;
                newItem.GetComponent<Item>().itemAmountt = itemInventory.itemAmountt;
                newItem.GetComponent<Item>().itemName = itemInventory.itemName;



                newItem.transform.parent = slot3.transform;
                newItem.transform.localPosition = newPosition;
                Debug.Log("slot 3");
            }
            else if (pants.transform.childCount == 0) {
                Vector3 newPosition = new Vector3(3, -3, 0);
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

    }*/


}
