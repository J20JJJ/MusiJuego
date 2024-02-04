using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movCamara : MonoBehaviour
{

    void Start()
    {
        StartCoroutine(MoverObjeto(Musica.duracionCanción));
    }

    public IEnumerator MoverObjeto(float tiempoTotal)
    {

        Vector3 origen = transform.position;
        Vector3 destino = new Vector3(origen.x, origen.y, origen.z + Musica.distanciaTotal); // Suponiendo que la distancia es de 200 unidades en el eje Z
        float tiempoTranscurrido = 0f;

        while (tiempoTranscurrido < tiempoTotal)
        {
            tiempoTranscurrido += Time.deltaTime;
            float porcentaje = tiempoTranscurrido / tiempoTotal;
            transform.position = Vector3.Lerp(origen, destino, porcentaje);
            yield return null;
        }

        // Asegurarse de que el objeto llega exactamente al destino al final del tiempo total
        transform.position = destino;
    }

}
