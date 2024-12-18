using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class SnapshotCamera : MonoBehaviour
{
    Camera snapCam;
    int resWidth = 1080, resHeight = 1080;

    private void Awake()
    {
        snapCam = GetComponent<Camera>();
        if (snapCam.targetTexture == null)
        {
            snapCam.targetTexture = new RenderTexture(resWidth, resHeight, 24);
        }
        else
        {
            resWidth = snapCam.targetTexture.width;
            resHeight = snapCam.targetTexture.height;
        }
    }

    public void CallTakeSnapShot()
    {
        // Capturar imagen sin necesidad de activar/desactivar la cámara
        Texture2D snapShot = new Texture2D(resWidth, resHeight, TextureFormat.RGB24, false);
        snapCam.Render();
        RenderTexture.active = snapCam.targetTexture;

        // Leer los píxeles de la textura
        snapShot.ReadPixels(new Rect(0, 0, resWidth, resHeight), 0, 0);
        snapShot.Apply();

        // Guardar la imagen como PNG
        byte[] bytes = snapShot.EncodeToPNG();
        string fileName = SnapShotName();

        if (!Directory.Exists(Application.persistentDataPath))
        {
            Directory.CreateDirectory(Application.persistentDataPath);
        }

        File.WriteAllBytes(fileName, bytes);
        Debug.Log($"Snapshot taken and saved to: {fileName}");
    }
    public string SnapShotName()
    {
        print(Application.persistentDataPath + "/snapshot1.png");
        return Application.persistentDataPath + "/snapshot1.png";
    }

}
