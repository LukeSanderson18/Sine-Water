using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalsCalculate : MonoBehaviour
{
    Mesh mesh;
    public GameObject prefab;
    public List<Vector3> centers;
    // Use this for initialization
    void Start()
    {
        Invoke("Test", 0.1f);
    }

    // Update is called once per frame
    void Test()
    {

        mesh = GetComponent<MeshFilter>().mesh;

        Vector3[] verts = mesh.vertices;
        int[] indices = mesh.triangles;
        print(mesh.triangles.Length);
        for (int i = 0; i < mesh.triangles.Length; i++)
        {
            Vector3 P1 = verts[indices[i++]];
            Vector3 P2 = verts[indices[i++]];
            Vector3 P3 = verts[indices[i++]];

            Vector3 center = ((P1 + P2 + P3) *0.33333f);

            centers.Add(center);

            //Instantiate(prefab, center, Quaternion.identity);
        }

    }
}
