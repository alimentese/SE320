using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{

    [SerializeField] private Image progressBar;
    public static string scene;
    private float _progress = 0f;

    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(LoadAsyncOperation());
        StartCoroutine(LoadAsync(scene));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void whichSceneWillLoad(string sceneName) {
        scene = sceneName;
    }

    IEnumerator LoadAsyncOperation() {
        yield return new WaitForSeconds(1);
        AsyncOperation gameLevel = SceneManager.LoadSceneAsync(scene);
        while(gameLevel.progress < 1) {
            progressBar.fillAmount = gameLevel.progress;
            Debug.Log(progressBar.fillAmount);
            yield return new WaitForEndOfFrame();
        }
    }

    IEnumerator LoadAsync(string sceneName) {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);

        operation.allowSceneActivation = false;

        while (progressBar.fillAmount < 1f) {
            progressBar.fillAmount = Mathf.Clamp01(operation.progress / 0.9f);

            Debug.Log("Loading... " + (int)(progressBar.fillAmount * 100f) + "%");

            yield return null;
        }

        operation.allowSceneActivation = true;
    }


}
