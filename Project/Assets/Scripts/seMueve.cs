using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seMueve : MonoBehaviour
{
    public float speed = 0.05f;
    public float salto = 5;
    public bool saltar = true;

    public GameObject Prota;

    float posV = -11.94f;
    float posR = -5.58f;
    float posAm = 0.33f;
    float posAz = 6.03f;
    float posN = 12.12f;

    int color = 3;
    float position = 0;

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, 0, speed);
        if (Input.GetKeyDown(KeyCode.D)) InvokeRepeating("MoveRight", 0.0f, 0.5f);
        if (Input.GetKeyDown(KeyCode.A)) InvokeRepeating("MoveLeft", 0.0f, 0.5f);

        if (Input.GetKeyUp(KeyCode.D)) CancelInvoke("MoveRight");
        if (Input.GetKeyUp(KeyCode.A)) CancelInvoke("MoveLeft");

        if (Input.GetKey(KeyCode.Space) && saltar)
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * salto, ForceMode.Impulse);
            saltar = false;
        }
    }

    void MoveRight()
    {
        color++;
        if (color > 5) color = 5;
        SetPosition();
        Prota.transform.position = new Vector3(position, Prota.transform.position.y, Prota.transform.position.z);
    }

    void MoveLeft()
    {
        color--;
        if (color < 1) color = 1;
        SetPosition();
        Prota.transform.position = new Vector3(position, Prota.transform.position.y, Prota.transform.position.z);
    }

    void SetPosition()
    {
        switch (color)
        {
            case 1:
                position = posV;
                break;
            case 2:
                position = posR;
                break;
            case 3:
                position = posAm;
                break;
            case 4:
                position = posAz;
                break;
            case 5:
                position = posN;
                break;

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag.Equals("suelo"))
        {
            saltar = true;
        }
    }
}
