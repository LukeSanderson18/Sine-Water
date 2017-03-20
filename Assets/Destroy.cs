using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour {

    public float killTime;
	// Use this for initialization
	void Start () {
        Destroy(this.gameObject, killTime);
        
	}

}
