using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
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

    public GameObject[] slots;
    
    [SerializeField] private GameObject itemPopupObject;


    [SerializeField] private GameObject itemPrefabb;
    private GameObject newItem;
    private Item itemscript;


    // Start is called before the first frame update
    void Start()
    {
        itemscript = itemPrefabb.GetComponent<Item>();
        //RefreshInventory(player.GetComponent<PlayerScript>().inventory);
        slots = GameObject.FindGameObjectsWithTag("InventorySlot");

        //envertersonbukesinson(player.GetComponent<PlayerScript>().playerInventory);
    }

    // Update is called once per frame
    void Update()
    {
        //RefreshInventory(player.GetComponent<PlayerScript>().inventory);

        // envertersonbukesinson(player.GetComponent<PlayerScript>().inventory);
        Debug.Log("ITem liste kac tane item var: " + player.GetComponent<PlayerScript>().playerInventory.GetItemList().Count);

    }


    /*
     for (int i = 0; i < player.GetComponent<PlayerScript>().inventory.GetItemList().Count; i++ ) {
            if(player.GetComponent<PlayerScript>().inventory.GetItemList()[0] == null) {
                
            }
        }
     */


    public void envertersonbukesinson(Inventory inventory) {
        for (int i = 0; i < player.GetComponent<PlayerScript>().playerInventory.GetItemList().Count;) {
            if(player.GetComponent<PlayerScript>().playerInventory.GetItemList()[i] != null) {

            }
            
            for (int j = 0; j < slots.Length;) {
                if (slots[j].transform.childCount == 0) {
                     Vector3 newPosition = new Vector3(3, -3, 0);
                     newItem = Instantiate(itemPrefabb);
                     newItem.GetComponent<Item>().itemType = player.GetComponent<PlayerScript>().playerInventory.GetItemList()[i].itemType;
                     newItem.GetComponent<Item>().itemAmountt = player.GetComponent<PlayerScript>().playerInventory.GetItemList()[i].itemAmountt;
                     newItem.GetComponent<Item>().itemName = player.GetComponent<PlayerScript>().playerInventory.GetItemList()[i].itemName;
                     newItem.transform.parent = slots[j].transform;
                     newItem.transform.localPosition = newPosition;

                     break;
                 } else {
                    j++;
                 }
                    
            }                
        }
    }





    public void sonenvanterdenemsi(PlayerInventory inventory) {
        for (int i = 0; i < player.GetComponent<PlayerScript>().playerInventory.GetItemList().Count; i++) {
            if(i == 0 && EmptySlot().transform.childCount == 0) {
                Vector3 newPosition = new Vector3(3, -3, 0);
                newItem = Instantiate(itemPrefabb);
                newItem.GetComponent<Item>().itemType = player.GetComponent<PlayerScript>().playerInventory.GetItemList()[0].itemType;
                newItem.GetComponent<Item>().itemAmountt = player.GetComponent<PlayerScript>().playerInventory.GetItemList()[0].itemAmountt;
                newItem.GetComponent<Item>().itemName = player.GetComponent<PlayerScript>().playerInventory.GetItemList()[0].itemName;
                newItem.transform.parent = EmptySlot().transform;
                newItem.transform.localPosition = newPosition;
            }
            else if (i == 1 && EmptySlot().transform.childCount == 0) {
                Vector3 newPosition = new Vector3(3, -3, 0);
                newItem = Instantiate(itemPrefabb);
                newItem.GetComponent<Item>().itemType = player.GetComponent<PlayerScript>().playerInventory.GetItemList()[1].itemType;
                newItem.GetComponent<Item>().itemAmountt = player.GetComponent<PlayerScript>().playerInventory.GetItemList()[1].itemAmountt;
                newItem.GetComponent<Item>().itemName = player.GetComponent<PlayerScript>().playerInventory.GetItemList()[1].itemName;
                newItem.transform.parent = EmptySlot().transform;
                newItem.transform.localPosition = newPosition;
            }
            else if(i == 2 && EmptySlot().transform.childCount == 0) {
                Vector3 newPosition = new Vector3(3, -3, 0);
                newItem = Instantiate(itemPrefabb);
                newItem.GetComponent<Item>().itemType = player.GetComponent<PlayerScript>().playerInventory.GetItemList()[2].itemType;
                newItem.GetComponent<Item>().itemAmountt = player.GetComponent<PlayerScript>().playerInventory.GetItemList()[2].itemAmountt;
                newItem.GetComponent<Item>().itemName = player.GetComponent<PlayerScript>().playerInventory.GetItemList()[2].itemName;
                newItem.transform.parent = EmptySlot().transform;
                newItem.transform.localPosition = newPosition;
            }
        }

    }


    public GameObject EmptySlot() {
        if(slot1.transform.childCount == 0) {
            return slot1;
        }
        if (slot2.transform.childCount == 0) {
            return slot2;
        }
        if (slot3.transform.childCount == 0) {
            return slot3;
        }
        else {
            return null;
        }
    }

    /*
     for (int j = 0; j < slots.Length; j++) {
            if (slots[j].transform.childCount == 0) {                
                break;
            }
            return slots[j];
        }
        return null;
     */




    public void RefreshInventory(PlayerInventory inventory) {
        Debug.Log("inventory calisiyor");
        //inventory.CountItems();
        foreach (Item itemInventory in inventory.GetItemList()) {
            if (slot1.transform.childCount == 0) {
                Vector3 newPosition = new Vector3(3, -3, 0);
                newItem = Instantiate(itemPrefabb);
                newItem.GetComponent<Item>().itemType = itemInventory.itemType;
                newItem.GetComponent<Item>().itemAmountt = itemInventory.itemAmountt;
                newItem.GetComponent<Item>().itemName = itemInventory.itemName;


                newItem.transform.parent = slot1.transform;
                newItem.transform.localPosition = newPosition;
                Debug.Log("slot 1");

            }


            else if (slot2.transform.childCount == 0) {
                Vector3 newPosition = new Vector3(3, -3, 0);
                newItem = Instantiate(itemPrefabb);
                newItem.GetComponent<Item>().itemType = itemInventory.itemType;
                newItem.GetComponent<Item>().itemAmountt = itemInventory.itemAmountt;
                newItem.GetComponent<Item>().itemName = itemInventory.itemName;


                newItem.transform.parent = slot2.transform;
                newItem.transform.localPosition = newPosition;
                Debug.Log("slot 2");
            }
            else if (slot3.transform.childCount == 0) {
                Vector3 newPosition = new Vector3(3, -3, 0);
                newItem = Instantiate(itemPrefabb);
                newItem.GetComponent<Item>().itemType = itemInventory.itemType;
                newItem.GetComponent<Item>().itemAmountt = itemInventory.itemAmountt;
                newItem.GetComponent<Item>().itemName = itemInventory.itemName;

                newItem.transform.parent = slot3.transform;
                newItem.transform.localPosition = newPosition;
                Debug.Log("slot 3");
            }
            else if (slot4.transform.childCount == 0) {
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

    }
}
