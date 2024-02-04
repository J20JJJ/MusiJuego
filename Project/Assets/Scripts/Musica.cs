using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;

[Serializable]
public class OnsetData
{
    public List<float> transientes;
    public List<string> carriles;
    public float duracion;
}

public class Musica : MonoBehaviour
{

    public GameObject objetoConSeMueve;
    public GameObject CamaramovCamara;


    public GameObject notaVerde;
    public GameObject notaRoja;
    public GameObject notaAmarrilla;
    public GameObject notaAzul;
    public GameObject notaNaranja;

    float posV = -11.94f;
    float posR = -5.58f;
    float posAm = 0.33f;
    float posAz = 6.03f;
    float posN = 12.12f;

    float distancia_seg;
    int i = 0;

    float zPosition = 17.86f;
    public float separacion = 10;

    public static float speedJugador;

    public static float distanciaTotal;

    public static float duracionCanción;

    public void CreateCaril(string color, float position)
    {
        GameObject lanePrefab = GetLanePrefab(color);
        if (lanePrefab != null)
        {

            Vector3 spawnPosition = new Vector3(position, 0, (zPosition * distancia_seg) + 38.7f); // Ajusta esto seg�n sea necesario
            GameObject laneInstance = Instantiate(lanePrefab, spawnPosition, Quaternion.identity);

        }
    }

    private GameObject GetLanePrefab(string color)
    {
        switch (color)
        {
            case "verde":
                return notaVerde;
            case "naranja":
                return notaNaranja;
            case "amarillo":
                return notaAmarrilla;
            case "rojo":
                return notaRoja;
            case "azul":
                return notaAzul;
            default:
                Debug.LogError($"No existe un prefabricado para el color {color}");
                return null;
        }
    }

    void Start()
    {

        seMueve script = objetoConSeMueve.GetComponent<seMueve>();
        movCamara script2 = CamaramovCamara.GetComponent<movCamara>();

        // Para desactivar el script
        script.enabled = false;
        script2.enabled = false;


        string json = File.ReadAllText("Assets\\Canciones\\chipi.json");
        OnsetData onsetData = JsonUtility.FromJson<OnsetData>(json);

        float duracion = onsetData.duracion;

        int countTransientes = onsetData.transientes.Count;
        Debug.Log("countTransientes " + countTransientes);
        float distancia_total = 50 * (countTransientes / 10);
        Debug.Log("distancia_total " + distancia_total);
        distancia_seg = distancia_total / duracion;
        Debug.Log("distancia_seg " + distancia_seg);

        //speedJugador = (distancia_total + 38.7f) / duracion; // Calcula la velocidad

        distanciaTotal = distancia_total;
        duracionCanción = duracion+2.5f;


        foreach (var color in onsetData.carriles)
        {
            float position = onsetData.transientes[onsetData.carriles.IndexOf(color)];

            switch (color)
            {
                case "verde":
                    position = posV;
                    break;
                case "naranja":
                    position = posN;
                    break;
                case "amarillo":
                    position = posAm;
                    break;
                case "rojo":
                    position = posR;
                    break;
                case "azul":
                    position = posAz;
                    break;

            }

            Debug.Log("Valor de onsetData.transientes[" + i + "]: " + onsetData.transientes[i]);
            zPosition = onsetData.transientes[i];
            i++;

            CreateCaril(color, position);

            //Debug.Log("position -" +position);
            //Debug.Log("position -" + color);
            //Debug.Log("Creando...");
        }
        Debug.Log("Creado!!!!!");
        // Para activar el script
        script.enabled = true;
        script2.enabled = true;

    }
}