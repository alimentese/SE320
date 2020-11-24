using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{
    AsyncOperation operation;
    public static string scene;
    [SerializeField] private Image progressBar;
    [SerializeField] private Text loadingbartext;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadAsync(scene));
    }

    // Update is called once per frame
    void Update() {
        if(progressBar.fillAmount == 1f && Input.GetMouseButtonDown(0)) {
            operation.allowSceneActivation = true;         
        }
    }

    public void whichSceneWillLoad(string sceneName) {
        scene = sceneName;
    }

    IEnumerator LoadAsync(string sceneName) {
        operation = SceneManager.LoadSceneAsync(sceneName);       
        operation.allowSceneActivation = false;
        while (progressBar.fillAmount < 1f) {
            progressBar.fillAmount = Mathf.Clamp01(operation.progress / 0.9f);

            //Debug.Log("Loading... " + (int)(progressBar.fillAmount * 100f) + "%");
            //Debug.Log("yüzde: " + operation.progress);
            loadingbartext.text = "Loading... " + (int)(progressBar.fillAmount * 100f) + "%";
            Debug.Log(loadingbartext.text);
            if (progressBar.fillAmount == 1f) {
                loadingbartext.text = "Click here to continue...";
            }
        }
        yield return new WaitForEndOfFrame();
    }  
}
