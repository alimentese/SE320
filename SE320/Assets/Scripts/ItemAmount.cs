using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemAmount : MonoBehaviour
{
    private Item itemscript;
    public Text textbook;
    [SerializeField] private GameObject itemPrefab;


    // Start is called before the first frame update
    void Start()
    {
        
        textbook = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("amount test");
        textbook.text = "" + itemPrefab.GetComponent<Item>().itemAmountt;
    }
}
