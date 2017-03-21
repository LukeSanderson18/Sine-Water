using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamManager : MonoBehaviour {

    Camera cam1;
    Camera cam2;
    MeshGen meshG;
    void Start()
    {
        meshG = GameObject.Find("Manager").GetComponent<MeshGen>();
        cam1 = transform.GetChild(0).GetComponent<Camera>();
        cam2 = transform.GetChild(1).GetComponent<Camera>();

        cam1.transform.localPosition = new Vector3(0, meshG.size * 0.5f, meshG.size);
        cam2.transform.localPosition = new Vector3(0, meshG.size * 0.5f, meshG.size);
    }
    public void Clicked()
    {
        cam1.enabled = !cam1.enabled;
        cam2.enabled = !cam2.enabled;
    }
}
