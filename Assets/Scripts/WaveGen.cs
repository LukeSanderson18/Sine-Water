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
    public Vector3[] verts;

    int xRes;

    // Update is called once per frame
    void Update()
    {
        xRes = GetComponent<MeshGen>().xRes;
        Mesh mesh = GetComponent<MeshFilter>().mesh;
        
        originalHeight = GetComponent<MeshGen>().verts;

        //all vertices
        Vector3[] vertices = new Vector3[mesh.vertices.Length];
        //vertices on the outside, to pin down

        for (int i = 0; i < vertices.Length; i++)
        {
           // print(GetComponent<MeshGen>().xRes + 2);
            if ((i % (xRes)) == 0)            //left edge
            {

                vertices[i] = new Vector3(vertices[i + 1].x, -500, vertices[i + 1].z);

            }
            else if (i < xRes)    // bottom row
            {
                vertices[i] = new Vector3(vertices[xRes].x, -500, vertices[xRes].z);
            }
            else if (i % (xRes) == (xRes-1)) //right row
            {
                vertices[i] = new Vector3(vertices[xRes-2].x, -500, vertices[xRes-2].z);
            }
            else if (i > ((xRes*xRes)-xRes))
            {
                vertices[i] = new Vector3(vertices[xRes].x, -500, vertices[xRes].z);

            }

            else
            {

                Vector3 vert = originalHeight[i];
                //MOVE VERTS IN GENERIC SINE WAVE
                vert.y += Mathf.Sin(Time.time * speed +
                    ((originalHeight[i].x * moveAmount.x) +
                    (originalHeight[i].z * moveAmount.z)) * scale) * height;
                //ADDING PERLIN NOISE FOR INTERESTING EFFECT
                vert.y += Mathf.PerlinNoise(originalHeight[i].x, originalHeight[i].y + Mathf.Sin(Time.time * 0.1f)) * noiseScale;
                vertices[i] = vert;
            }
            
        }

        mesh.vertices = vertices;


        mesh.RecalculateNormals();

        GetComponent<MeshFilter>().sharedMesh = mesh;
        GetComponent<MeshCollider>().sharedMesh = mesh;


        //
        //  updating slider values
        //

        if (!PlayerPrefs.HasKey("height"))
        {
            PlayerPrefs.SetFloat("height", 0.5f);
        }
        else
        {
            height = PlayerPrefs.GetFloat("height");
        }

        //

        if (!PlayerPrefs.HasKey("scale"))
        {
            PlayerPrefs.SetFloat("scale", 1);
        }
        else
        {
            scale = PlayerPrefs.GetFloat("scale");
        }

        //

        if (!PlayerPrefs.HasKey("speed"))
        {
            PlayerPrefs.SetFloat("speed", 1);
        }
        else
        {
            speed = PlayerPrefs.GetFloat("speed");
        }

        //

        if (!PlayerPrefs.HasKey("noise"))
        {
            PlayerPrefs.SetFloat("noise", 0);
        }
        else
        {
            noiseScale = PlayerPrefs.GetFloat("noise");
        }

        //

        if (!PlayerPrefs.HasKey("xmult"))
        {
            PlayerPrefs.SetFloat("xmult", 1);
        }
        else
        {
            moveAmount.x = PlayerPrefs.GetFloat("xmult");
        }

        //

        if (!PlayerPrefs.HasKey("zmult"))
        {
            PlayerPrefs.SetFloat("zmult", 1);
        }
        else
        {
            moveAmount.z = PlayerPrefs.GetFloat("zmult");
        }

    }
}
