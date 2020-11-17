using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class UI : MonoBehaviour
{
    public Dropdown resolutionDropdown;
    Resolution[] resolutions;

    // Start is called before the first frame update
    void Start()
    {
        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        for (int i = 0; i < resolutions.Length; i++) {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);

        }

        resolutionDropdown.AddOptions(options);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // METHODS

    /* MAIN MENU METHODS*/

    public void PlayGame() {
        LoadingScreen.scene = "Level 1";
        SceneManager.LoadScene("Loading Screen");
        
    }

    public void BacktoMainScreen(string scene) {
        SceneManager.LoadScene(scene);
    }
    public void QuitGame() {
        Debug.Log("QUIT!");
        Application.Quit();
    }

    public void BacktoClassSelect(string scene) {
        SceneManager.LoadScene(scene);
    }

    public void KnightSelected(string scene) {
        SceneManager.LoadScene(scene);
    }

    public void stageOne(string scene) {
        SceneManager.LoadScene(scene);
    }

    public void PlayAgain() {
        SceneManager.LoadScene("Stage1");
    }

    /* OPTIONS MENU METHODS */
    public void SetQuality(int qualityIndex) {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullscreen(bool isFullscreeen) {
        Screen.fullScreen = isFullscreeen;
    }

    public void SetResolution() {
        Screen.SetResolution(640, 480, true, 60);
    }
    /* CHARACTER CREATION METHODS */

}
