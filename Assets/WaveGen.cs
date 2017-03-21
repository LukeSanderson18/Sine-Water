using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveGen : MonoBehaviour
{

    public float height = 1f;
    public float scale = 10;
    public float speed = 1;

    public float noiseScale = 2f;

    public Vector3[] originalHeight;

    public Vector3 moveAmount;


    // Update is called once per frame
    void Update()
    {

        Mesh mesh = GetComponent<MeshFilter>().mesh;
        
            originalHeight = GetComponent<MeshGen>().verts;
        

        //all vertices
        Vector3[] vertices = new Vector3[mesh.vertices.Length];
        //vertices on the outside, to pin down

        for (int i = 0; i < vertices.Length; i++)
        {
            


            Vector3 vert = originalHeight[i];
            //MOVE VERTS IN GENERIC SINE WAVE
            vert.y += Mathf.Sin(Time.time * speed +
                ((originalHeight[i].x * moveAmount.x) +
                (originalHeight[i].y * moveAmount.y) +
                (originalHeight[i].z * moveAmount.z)) * scale) * height;
            //ADDING PERLIN NOISE FOR INTERESTING EFFECT
            vert.y += Mathf.PerlinNoise(originalHeight[i].x, originalHeight[i].y + Mathf.Sin(Time.time * 0.1f)) * noiseScale;
            vertices[i] = vert;

            if ((i % GetComponent<MeshGen>().xRes) == 0)            //left edge
            {
                vertices[i] = new Vector3(vertices[i + 1].x, -50, vertices[i + 1].z);
                print(vertices[i+1]);
            }

        }

        mesh.vertices = vertices;

        mesh.RecalculateNormals();

        GetComponent<MeshFilter>().sharedMesh = mesh;
        GetComponent<MeshCollider>().sharedMesh = mesh;


    }
}
