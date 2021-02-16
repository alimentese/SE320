using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class info : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject currentwaveObject;
    public GameObject remainingtimeObject;
    public GameObject Wave1;
    public GameObject Wave2;
    float wave1time;
    float wave2time;
    int time = 0;

    void Start()
    {

        currentwaveObject.GetComponent<Text>().text = "1";


    }

    // Update is called once per frame
    void Update()
    {
        wave1time = Wave1.GetComponent<Wave>().timer;
        wave2time = Wave2.GetComponent<Wave>().timer;

        time = (int)wave1time;
        if (wave1time <= 0) {
            time = (int)wave2time;
            
        }
        remainingtimeObject.GetComponent<Text>().text = time.ToString();
        if(wave2time <= 0) {
            currentwaveObject.GetComponent<Text>().text = "2";
        }
    }
}
