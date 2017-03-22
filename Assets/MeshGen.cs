using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshGen : MonoBehaviour
{

    public float size;

    public Vector3[] verts;
    public int xRes = 2;
    public int zRes = 2;

    public GameObject grid;


    Mesh mesh;
    // Use this for initialization
    void Start()
    {
        if (!PlayerPrefs.HasKey("size"))
        {
            PlayerPrefs.SetFloat("size", 5);
        }
        else
        {
            size = PlayerPrefs.GetFloat("size");
        }

        if (!PlayerPrefs.HasKey("reso"))
        {
            PlayerPrefs.SetInt("reso", 50);
        }
        else
        {
            xRes = PlayerPrefs.GetInt("reso");
        }

        if (!PlayerPrefs.HasKey("height"))
        {
            PlayerPrefs.SetFloat("height", 0.5f);
        }
        else
        {
            size = PlayerPrefs.GetFloat("height");
        }

        //

        if (!PlayerPrefs.HasKey("scale"))
        {
            PlayerPrefs.SetFloat("scale", 1);
        }
        else
        {
            size = PlayerPrefs.GetFloat("scale");
        }

        //

        if (!PlayerPrefs.HasKey("speed"))
        {
            PlayerPrefs.SetFloat("speed", 1);
        }
        else
        {
            size = PlayerPrefs.GetFloat("speed");
        }

        //

        if (!PlayerPrefs.HasKey("noise"))
        {
            PlayerPrefs.SetFloat("noise", 0);
        }
        else
        {
            size = PlayerPrefs.GetFloat("noise");
        }

        //

        if (!PlayerPrefs.HasKey("xmult"))
        {
            PlayerPrefs.SetFloat("xmult", 1);
        }
        else
        {
            size = PlayerPrefs.GetFloat("xmult");
        }

        //

        if (!PlayerPrefs.HasKey("zmult"))
        {
            PlayerPrefs.SetFloat("zmult", 1);
        }
        else
        {
            size = PlayerPrefs.GetFloat("zmult");
        }
        //for simplicities sake
        zRes = xRes;

        MeshFilter meshFilter = GetComponent<MeshFilter>();
        mesh = meshFilter.mesh;
        //mesh = new Mesh();                      //Create new mesh
        mesh.Clear();
        mesh.name = "Wave";
         verts = new Vector3[xRes * zRes];     //Inst vertices
        Vector3[] normals = new Vector3[verts.Length];  //Inst normals
        Vector2[] uvs = new Vector2[verts.Length];      //Inst uvs


        //
        //  VERTS
        //
        for (int i = 0; i < xRes; i++)          //loop through verts, assign position
        {
            float xPos = ((float)i / (xRes-1) - 0.5f) * size;

            for (int j = 0; j < zRes; j++)
            {
                float zPos = ((float)j / (zRes - 1) - 0.5f) * size;
                verts[i + j * zRes] = new Vector3(xPos, 0, zPos);
            }

        }

        //
        //  NORMALS
        //
        for (int i = 0; i < normals.Length; i++)
        {
            normals[i] = Vector3.up;
        }

        //
        //  UVS
        //
        for (int i = 0; i < xRes; i++)
        {
            for (int j = 0; j < zRes; j++)
            {
                uvs[i + j * xRes] = new Vector2((float)j / (xRes - 1),(float)i / (zRes - 1));
            }
        }

        //
        //  TRIANGLES
        //

        int faces = (xRes - 1) * (zRes - 1);
        int[] triangles = new int[faces * 6];       //who knows why
        int a = 0;
        for(int i = 0; i< faces; i++)
        {
            //% GETS REMAINDER
            int j = i % (xRes - 1) + (i / (zRes - 1) * xRes);   //gets lowest left vert (basically 0)

            triangles[a++] = j + xRes;
            triangles[a++] = j + 1;
            triangles[a++] = j;

            triangles[a++] = j + xRes;
            triangles[a++] = j + xRes + 1;
            triangles[a++] = j + 1;
        }

        mesh.vertices = verts;
        mesh.normals = normals;
        mesh.uv = uvs;
        mesh.triangles = triangles;
        mesh.RecalculateBounds();

        //grid.transform.localScale = Vector3.one * (size * 0.05f);


        /*mesh.vertices = new Vector3[]           //Assign verts
        {   
            new Vector3(-size,-size,0.001f),
            new Vector3(size,-size,0.001f),
            new Vector3(size,size,0.001f),
            new Vector3(-size,size,0.001f),
        };
        mesh.uv = new Vector2[]                 //Assign UV cords for texture
        {
            new Vector2(0,0),
            new Vector2(0,1),
            new Vector2(1,1),
            new Vector2(1,0)
        };
        mesh.triangles = new int[]              //Assign tris (good for normals later)
        {
            0,2,1, 0,3,2
        };
        mesh.RecalculateNormals();              //Recalculate everything;

        GetComponent<MeshFilter>().mesh = mesh;
         * /*/

        
    }

    

}
