using System.Diagnostics;
using System;
using System.IO;
using UnityEngine;

public class suelobool : MonoBehaviour
{
    string cancion = "https://youtu.be/ore8f9cSBbQ";

    void Start()
    {
        // Obtener la ruta a la carpeta Assets de tu proyecto de Unity
        string basePath = Application.dataPath;

        // Agregar la ruta relativa a la carpeta Canciones\Musica
        string path = Path.Combine(basePath, "Assets\\Canciones\\Musica\\");

        // Crear el directorio si no existe
        Directory.CreateDirectory(path);

        // Crear un archivo temporal con el contenido de la variable cancion
        string tempPath = Path.Combine(path, "temp.txt");
        File.WriteAllText(tempPath, cancion);

        // Reemplazar el contenido del archivo cancion.txt con el contenido del archivo temp.txt
        string targetPath = Path.Combine(path, "cancion.txt");
        File.Replace(tempPath, targetPath, null);

        // Eliminar el archivo temporal
        File.Delete(tempPath);
        //////////////////////////////////////
        var start = new ProcessStartInfo();
        start.FileName = @"C:\path\to\your\executable.exe"; // Reemplaza esto con la ruta a tu archivo ejecutable

        using (Process process = Process.Start(start))
        {
            using (StreamReader reader = process.StandardOutput)
            {
                string result = reader.ReadToEnd();
                Console.Write(result);
            }
        }

    }
}
