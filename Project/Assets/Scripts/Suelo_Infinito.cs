using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Suelo_Infinito : MonoBehaviour
{


    // Start is called before the first frame update
    public GameObject Prota;
    public GameObject Suelo;

    GameObject[] clones = new GameObject[5];
    int cloneCount = 0;

    float NuevoSuelo = 10;
    float zPosition;

    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    { 

        if (Prota.transform.position.z  >= (zPosition - 20))
        {

            Vector3 newPos = Vector3.forward * (20 + NuevoSuelo);

            if (cloneCount >= clones.Length)
            {
                Destroy(clones[0]);
                Array.Copy(clones, 1, clones, 0, clones.Length - 1);
                cloneCount--;
            }

            GameObject newPlane = GameObject.Instantiate(Suelo, newPos, Quaternion.identity);
            clones[cloneCount] = newPlane;
            cloneCount++;

            zPosition = newPlane.transform.position.z;
            NuevoSuelo = (20 + NuevoSuelo);

        }

    }

}
