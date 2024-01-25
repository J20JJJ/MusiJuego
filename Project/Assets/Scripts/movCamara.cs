using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movCamara : MonoBehaviour
{
    public seMueve seMueve;
    private float speed;

    // Start is called before the first frame update
    void Start()
    {
        speed = seMueve.speed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, 0, speed);
    }
}
