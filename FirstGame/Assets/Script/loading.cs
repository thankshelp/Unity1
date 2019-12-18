using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class loading : MonoBehaviour
{

    public Slider progressBar;
    public GameObject text;
    // Start is called before the first frame update
    void Start()
    {
        int lvl = PlayerPrefs.GetInt("nextLVL", 1);
        StartCoroutine(LoadLevelAsinc(lvl));
    }

    private IEnumerator LoadLevelAsinc(int lvl)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(lvl);

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

    // Update is called once per frame
    void Update()
    {
        
    }
}
