using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boat : MonoBehaviour {

    public float upForce = 10f;
    public float distance = 2f;
    public LayerMask waterLayer;
    public GameObject[] hoverPoints;
    Rigidbody rb;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        RaycastHit hit;
        for (int i = 0; i < hoverPoints.Length; i++)
        {
            var hoverPoint = hoverPoints[i];
            if (Physics.Raycast(hoverPoint.transform.position, -Vector3.up, out hit, distance, waterLayer))
            {
                // print("FUCKING HITTIN");
                rb.AddForceAtPosition(Vector3.up * upForce, hoverPoint.transform.position);
            }
            else
            {
                rb.AddForceAtPosition(-Vector3.up * upForce, hoverPoint.transform.position);

            }
        }

     //   rb.centerOfMass = new Vector3(transform.position.x,transform.position.y-20,transform.position.z);
        
	}
}
