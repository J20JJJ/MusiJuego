using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seMueve : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(MoverObjeto(Musica.duracionCanción));
    }

    private int color = 0;
    private float[] posicionesX = new float[] { -11.94f, -5.58f, 0.33f, 6.03f, 12.12f };

    public IEnumerator MoverObjeto(float tiempoTotal)
    {
        Vector3 origen = transform.position;
        Vector3 destino = new Vector3(origen.x, origen.y, origen.z + Musica.distanciaTotal);
        float tiempoTranscurrido = 0f;

        while (tiempoTranscurrido < tiempoTotal)
        {
            tiempoTranscurrido += Time.deltaTime;
            float porcentaje = tiempoTranscurrido / tiempoTotal;
            transform.position = Vector3.Lerp(origen, destino, porcentaje);

            // Comprobar las entradas de teclado y mover el objeto a la posición X correspondiente
            if (color > 0 && color <= posicionesX.Length)
            {
                transform.position = new Vector3(posicionesX[color - 1], transform.position.y, transform.position.z);
            }

            yield return null;
        }

        // Asegurarse de que el objeto llega exactamente al destino al final del tiempo total
        transform.position = destino;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D)) { color = 1; }
        else if (Input.GetKeyDown(KeyCode.F)) { color = 2; }
        else if (Input.GetKeyDown(KeyCode.H)) { color = 3; }
        else if (Input.GetKeyDown(KeyCode.J)) { color = 4; }
        else if (Input.GetKeyDown(KeyCode.K)) { color = 5; }
    }
}
