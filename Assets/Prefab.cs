using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Prefab : MonoBehaviour {

    public TextAsset textFile;
    private string wholeString;
    private List<string> eachLine;

    public Slider[] sliders;

    void Start()
    {
        wholeString = textFile.text;

        eachLine = new List<string>();
        eachLine.AddRange(wholeString.Split("\n"[0]));
    }

    public void Clicked()
    {
        for (int i = 0; i < sliders.Length; i++)
        {
            sliders[i].value = float.Parse(eachLine[i]);
        }
        Application.LoadLevel(Application.loadedLevel);

    }
}
