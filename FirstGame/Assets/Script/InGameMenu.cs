using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InGameMenu : MonoBehaviour
{
    public Slider progressBar;
    public GameObject text;

    // Start is called before the first frame update
    public void ShowMenu(GameObject menu)
    {
        menu.SetActive(true);
        Time.timeScale = 0f;
    }
    // Update is called once per frame
    public void Resume(GameObject menu)
    {
        menu.SetActive(false);
        Time.timeScale = 1f;
    }
    public void MainMenu(GameObject LoadinBG)
    {
        LoadinBG.SetActive(true);
        Time.timeScale = 1f;
        StartCoroutine(LoadLevelAsic());
    }
    private IEnumerator LoadLevelAsic()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(0);

        asyncLoad.allowSceneActivation = false;

        while (!asyncLoad.isDone)
        {
            progressBar.value = asyncLoad.progress;
            
            if (asyncLoad.progress >= 0.9f && !asyncLoad.allowSceneActivation)
            {
                text.SetActive(true);
                progressBar.value = 1.0f;

                if (Input.anyKeyDown)
                    asyncLoad.allowSceneActivation = true;
            }
            yield return null;
        }
    }
    public void Exit()
    {
        Time.timeScale = 1f;
        Application.Quit();
    }
}
