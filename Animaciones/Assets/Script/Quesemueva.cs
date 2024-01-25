using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quesemueva : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    float speed = 10f;
    void Update()
    {
        Vector3 v = Vector3.zero;
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(new Vector3(0, -speed * Time.deltaTime, 0));
            v = new Vector3(-0.0005f, 0, 0);


        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(new Vector3(0, speed * Time.deltaTime, 0));
            v = new Vector3(0.0005f, 0, 0);

        }
        if (Input.GetKey(KeyCode.W))
        {
            v = new Vector3(0, 0, 0.005f);
        }
        if (Input.GetKey(KeyCode.S))
        {
            v = new Vector3(0, 0, -0.005f);

        }
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            v = new Vector3(0, 0.005f, 0);

        }
        transform.Translate(v);
    }
}
