using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour {

    bool clicked = true;
    public Slider[] sliders;

    public void Reset()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
    public void Clicked()
    {
        clicked = !clicked;

        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(clicked);
        }

    }

    public void Default()
    {
        /*
            PlayerPrefs.SetFloat("size", 50);
            PlayerPrefs.SetInt("reso", (int)50);
            PlayerPrefs.SetFloat("height", 0.5f);
            PlayerPrefs.SetFloat("scale", 1);
            PlayerPrefs.SetFloat("speed", 1);
            PlayerPrefs.SetFloat("noise", 0);
            PlayerPrefs.SetFloat("xmult", 1);
            PlayerPrefs.SetFloat("zmult", 1);
         */

            sliders[0].value = 20;
            sliders[1].value = 50;
            sliders[2].value = 0.5f;
            sliders[3].value = 1;
            sliders[4].value = 1;
            sliders[5].value = 0;
            sliders[6].value = 1;
            sliders[7].value = 1;
            Application.LoadLevel(Application.loadedLevel);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
