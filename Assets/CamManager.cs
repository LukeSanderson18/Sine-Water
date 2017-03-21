using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamManager : MonoBehaviour {

    Camera cam1;
    Camera cam2;
    void Start()
    {
        cam1 = transform.GetChild(0).GetComponent<Camera>();
        cam2 = transform.GetChild(1).GetComponent<Camera>();
    }
    public void Clicked()
    {
        cam1.enabled = !cam1.enabled;
        cam2.enabled = !cam2.enabled;
    }
}
