using System.Collections.Generic;
using UnityEngine;

public class Inventory {

    private List<Item> itemList;
    private Inventory inventory;

    public Inventory() {
        itemList = new List<Item>();
    }

    public void setInventory(Inventory inventory) {
        this.inventory = inventory;
    }

    public void AddItem(Item item) {
        itemList.Add(item);
    }

    public void RemoveItem(string name) {
        for (int i = 0; i < itemList.Count; i++) {
            if (itemList[i].itemName == name) {
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
        for (int i = 0; i < itemList.Count; i++) {
            Debug.Log(itemList[i]);
        }
    }

    public void searchItem(string name) {
        for (int i = 0; i < itemList.Count; i++) {
            if (itemList[i].itemName == name) {
                Debug.Log("Item found at " + i + ".slot.");
            }
        }

    }

    public void PrintItemCount() {
        Debug.Log("toplam item: " + itemList.Count);
    }
}
