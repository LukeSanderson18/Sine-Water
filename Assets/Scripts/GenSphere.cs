using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenSphere : MonoBehaviour {

    public GameObject prefab;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Instantiate(prefab, transform.position, transform.rotation);
        }
    }
}
