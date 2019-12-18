using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class levelSelection : MonoBehaviour
{
    public Button[] buttons;

    // Start is called before the first frame update
    void Start()
    {
        int curLVL = PlayerPrefs.GetInt("curLVL", 1);

        for (int i = 0; i < buttons.Length; i++)
        {
            if (i + 1 > curLVL)
                buttons[i].interactable = false;
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Delete))
        {
            PlayerPrefs.DeleteAll();
        }
    }
}
