using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    private Renderer objectRenderer;
    Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            anim.SetBool("semueve", true);
        }
        if (!Input.GetKey(KeyCode.W))
        {
            anim.SetBool("semueve", false);
        }

        if (Input.GetKey(KeyCode.A))
        {
            anim.SetBool("semueve", true);
        }
        if (Input.GetKey(KeyCode.D))
        {
            anim.SetBool("semueve", true);
        }
        if (Input.GetKey(KeyCode.S))
        {
            anim.SetBool("semueve", true);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            anim.SetBool("salto", true);

        }
        else
        {
            anim.SetBool("salto", false);
        }
        

        if (Input.GetKey(KeyCode.B))
        {
            anim.SetBool("bailar", true);
        }
        if (!Input.GetKey(KeyCode.B))
        {
            anim.SetBool("bailar", false);
        }
    }
 
}
