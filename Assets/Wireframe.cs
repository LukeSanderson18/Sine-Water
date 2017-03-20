using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wireframe : MonoBehaviour {

    bool isWireframe = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

       /* if (Input.GetKeyDown(KeyCode.W))
        {
            isWireframe = !isWireframe;
            print(isWireframe);
        }

        if (isWireframe)
        {
            GL.wireframe = true;
        }
        else
        {
            GL.wireframe = false;
        }
        * */


		
	}

    void OnRenderObject()
    {
        GL.wireframe = true;
    }
    void OnPostRender()
    {
        GL.wireframe = true;
    }
}
