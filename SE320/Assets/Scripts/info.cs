using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class info : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject currentwaveObject;
    public GameObject remainingtimeObject;

    public GameObject boss;
    public GameObject Wave1;
    public GameObject Wave2;
    public GameObject Wave3;
    public GameObject gameover;

    float endtime = 60f;
    float wave1time;
    float wave2time;
    float wave3time;
    int time = 0;

    void Start()
    {

        currentwaveObject.GetComponent<Text>().text = "1";


    }

    // Update is called once per frame
    void Update()
    {
        remainingtimeObject.GetComponent<Text>().text = time.ToString();

        wave1time = Wave1.GetComponent<Wave>().timer;
        wave2time = Wave2.GetComponent<Wave>().timer;
        wave3time = Wave3.GetComponent<Wave>().timer;
        
        time = (int)wave1time;
        if(wave1time <= 0) {
            time = (int)wave2time;
            currentwaveObject.GetComponent<Text>().text = "1";
        }
        if(wave2time <= 0) {           
            time = (int)wave3time;
            currentwaveObject.GetComponent<Text>().text = "2";
        }
        if(wave3time <=0) {                       
            currentwaveObject.GetComponent<Text>().text = "3(Boss Fight)";
            time = (int)endtime;
        }
        if(endtime <= 0) {
            gameover.SetActive(true);
        }
        if(boss != null) {
            if (boss.GetComponent<BEnemy>().SkeletonHealth <= 0) {
                gameover.SetActive(true);
                boss = null;
            }
        }
        
    }
}
