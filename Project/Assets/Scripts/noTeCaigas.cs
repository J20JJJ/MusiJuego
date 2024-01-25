using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class noTeCaigas : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody>();
        }

        // Configura el Rigidbody
        rb.mass = 1f;  // Ajusta la masa según tus necesidades
        rb.useGravity = true;  // Activa la gravedad
        rb.freezeRotation = true;  // Evita que el objeto se tumbe debido a la rotación
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
