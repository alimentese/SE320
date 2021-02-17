using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private GameObject player;

    public List<GameObject> slots;
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

    

    [SerializeField] private GameObject itemPopupObject;
    [SerializeField] private GameObject itemPrefabb;
    private GameObject newItem;


    // Start is called before the first frame update
    private void Awake() {
        RefreshInventory();
    }
    void Start() {
        RefreshInventory();
        slots = new List<GameObject> {
            slot1,
            slot2,
            slot3,
            slot4,
            slot5,
            slot6,
            slot7,
            slot8
        };
    }

    // Update is called once per frame
    void Update() {

        RefreshInventory();

        Debug.Log("ITem liste kac tane item var: " + player.GetComponent<PlayerScript>().playerInventory.GetItemList().Count);

    }

    public bool inventoryCheck() {
        for (int i = 0; i < player.GetComponent<PlayerScript>().playerInventory.GetItemList().Count;) {
            for (int j = 0; j < slots.Count;) {
                if(slots[j].transform.GetChild(0).GetComponent<Item>().itemAmountt == player.GetComponent<PlayerScript>().playerInventory.GetItemList()[i].itemAmountt &&
                slots[j].transform.GetChild(0).GetComponent<Item>().itemName == player.GetComponent<PlayerScript>().playerInventory.GetItemList()[i].itemName) {
                    i++;
                    j++;                   
                   // Debug.Log("envanter ve ui esit");

                }
                else {
                 //   Debug.Log("envanter ve ui esit değil");

                        return false;
                }
                
            }
        }
        return true;
    }


    public void removeItemFromUI(string itemname) {
        for (int i = 0; i < player.GetComponent<PlayerScript>().playerInventory.GetItemList().Count; i++) {
            if (slots[i].transform.GetChild(0).GetComponent<Item>().itemName == itemname) {
                Destroy(slots[i].transform.GetChild(0).gameObject);
                player.GetComponent<PlayerScript>().playerInventory.RemoveItem(itemname);
               // Debug.Log("item silindi!");
            }
        }
    }


    public void RefreshInventory() {
        for (int i = 0; i < player.GetComponent<PlayerScript>().playerInventory.GetItemList().Count; i++) {
            if (player.GetComponent<PlayerScript>().playerInventory.GetItemList()[i] != null) {
                if (slots[i].transform.childCount == 1) {
                    player.GetComponent<PlayerScript>().playerInventory.AddItem(new Item {
                        itemType = slots[i].transform.GetChild(0).GetComponent<Item>().itemType,
                        itemName = slots[i].transform.GetChild(0).GetComponent<Item>().itemName,
                        itemAmountt = slots[i].transform.GetChild(0).GetComponent<Item>().itemAmountt,
                        itemSTR = slots[i].transform.GetChild(0).GetComponent<Item>().itemSTR,
                        itemDEX = slots[i].transform.GetChild(0).GetComponent<Item>().itemDEX,
                        itemAGI = slots[i].transform.GetChild(0).GetComponent<Item>().itemDEX,
                        itemINT = slots[i].transform.GetChild(0).GetComponent<Item>().itemINT,
                        itemHP = slots[i].transform.GetChild(0).GetComponent<Item>().itemHP,
                        itemSTA = slots[i].transform.GetChild(0).GetComponent<Item>().itemSTA
                    });
                   // Debug.Log("if blogu");
                }
                else {
                  //  Debug.Log("else blogu");
                }
            }
            else {
                if (slots[i].transform.childCount == 0) {
                    Vector3 newPosition = new Vector3(3, -3, 0);
                    newItem = Instantiate(itemPrefabb);
                    newItem.GetComponent<Item>().itemType = player.GetComponent<PlayerScript>().playerInventory.GetItemList()[i].itemType;
                    newItem.GetComponent<Item>().itemAmountt = player.GetComponent<PlayerScript>().playerInventory.GetItemList()[i].itemAmountt;
                    newItem.GetComponent<Item>().itemName = player.GetComponent<PlayerScript>().playerInventory.GetItemList()[i].itemName;
                    newItem.GetComponent<Item>().itemSTR = player.GetComponent<PlayerScript>().playerInventory.GetItemList()[i].itemSTR;
                    newItem.GetComponent<Item>().itemDEX = player.GetComponent<PlayerScript>().playerInventory.GetItemList()[i].itemDEX;
                    newItem.GetComponent<Item>().itemAGI = player.GetComponent<PlayerScript>().playerInventory.GetItemList()[i].itemAGI;
                    newItem.GetComponent<Item>().itemINT = player.GetComponent<PlayerScript>().playerInventory.GetItemList()[i].itemINT;
                    newItem.GetComponent<Item>().itemHP = player.GetComponent<PlayerScript>().playerInventory.GetItemList()[i].itemHP;
                    newItem.GetComponent<Item>().itemSTA = player.GetComponent<PlayerScript>().playerInventory.GetItemList()[i].itemSTA;
                    newItem.transform.parent = slots[i].transform;
                    newItem.transform.localPosition = newPosition;
                }
            }
        }

    }   
}
