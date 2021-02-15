/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class info : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject currentwaveObject;
    public GameObject remainingtimeObject;
    public GameObject BattleSystem;
   

    void Start()
    {


         

    }

    // Update is called once per frame
    void Update()
    {
        float time = BattleSystem.GetComponent<Battlesystem.Wave>().timer;
        remainingtimeObject.GetComponent<Text>().text = time.ToString();
    }
}
*/