using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AsignSnapShot : MonoBehaviour
{

    [SerializeField] RawImage image;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("AsignImage", 0.6f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AsignImage()
    {
        string filePath = Application.dataPath + "/snapshot1.png";

        if (File.Exists(filePath))
        {
            byte[] fileData = File.ReadAllBytes(filePath);
            Texture2D texture = new Texture2D(2, 2);
            if (texture.LoadImage(fileData)) // Carga la textura desde los datos binarios
            {
                image.texture = texture;
            }
            else
            {
                Debug.LogError("No se pudo cargar la textura desde los datos del archivo.");
            }
        }
        else
        {
            Debug.LogError($"El archivo no existe en la ruta especificada: {filePath}");
        }
    }
}
