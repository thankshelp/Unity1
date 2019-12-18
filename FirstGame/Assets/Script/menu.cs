using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    public GameObject levelSelection;
    //public Slider progressBar;
    //public GameObject text;
    //public GameObject loadingScreen;

    // Start is called before the first frame update
    public void menuStart(Button Start)
    {
        EventSystem.current.GetComponent<EventSystem>().SetSelectedGameObject(null);

        if (levelSelection.activeSelf == true)
            levelSelection.SetActive(false);
        else
            levelSelection.SetActive(true);
    }

    public void menuExit()
    {
        Application.Quit();
    }

    // Update is called once per frame
    public void levelSelectionHide()
    {
        levelSelection.SetActive(false);
    }
    public void lvlselect(int lvl)
    {
        //loadingScreen.SetActive(true);
        PlayerPrefs.SetInt("nextLVL", lvl);
        Time.timeScale = 1f;
        StartCoroutine(LoadLevelAsinc(3));
    }

    private IEnumerator LoadLevelAsinc(int lvl)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(lvl);

        //asyncLoad.allowSceneActivation = false;

        while (!asyncLoad.isDone)
        {
            //progressBar.value = asyncLoad.progress;

            if (asyncLoad.progress >= 0.9f && !asyncLoad.allowSceneActivation)
            {
                //text.SetActive(true);
                //progressBar.value = 1.0f;

                //if (Input.anyKeyDown)
                    //asyncLoad.allowSceneActivation = true;
            }
            yield return null;
        }
    }

}

