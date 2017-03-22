using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour {

    bool clicked;

    public void Clicked()
    {
        clicked = !clicked;

        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(clicked);
        }

    }
}
