using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class itemPopup : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown("escape") || Input.GetKeyDown("i")) {
            if(gameObject.activeInHierarchy) {
                gameObject.SetActive(false);
                Debug.Log("escapeye basıldı0");
            }           
        }
    }
}
