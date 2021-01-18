using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory {

    private List<Item> itemsInsideInventory;
    private PlayerInventory inventory;

    public PlayerInventory() {
        itemsInsideInventory = new List<Item>();
    }

    public void setInventory(PlayerInventory inventory) {
        this.inventory = inventory;
    }

    public void AddItem(Item item) {
        itemsInsideInventory.Add(item);
    }

    public void RemoveItem(string name) {
        for (int i = 0; i < itemsInsideInventory.Count; i++) {
            if (itemsInsideInventory[i].itemName == name) {
                itemsInsideInventory.RemoveAt(i);
            }
        }
    }

    public void PrintItemCount() {
        Debug.Log("toplam item: " + itemsInsideInventory.Count);
    }

    public List<Item> GetItemList() {
        return itemsInsideInventory;
    }

    public void printList() {
        for (int i = 0; i < itemsInsideInventory.Count; i++) {
            Debug.Log(itemsInsideInventory[i]);
        }
    }


    public void searchItem(string name) {
        for (int i = 0; i < itemsInsideInventory.Count; i++) {
            if (itemsInsideInventory[i].itemName == name) {
                Debug.Log("Item found at " + i + ".slot.");
            }
        }

    }

}