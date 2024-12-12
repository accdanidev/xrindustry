using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class SnapshotCamera : MonoBehaviour
{

    Camera snapCam;
    int resWith = 1080, resHeight = 1080;

    private void Awake()
    {
        snapCam = GetComponent<Camera>();
        if (snapCam.targetTexture == null)
        {
            snapCam.targetTexture = new RenderTexture(resWith, resHeight, 24);
        }
        else
        {
            resWith = snapCam.targetTexture.width;
            resHeight = snapCam.targetTexture.height;
        }
        //snapCam.gameObject.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }



    public void CallTakeSnapShot()
    {
        snapCam.gameObject.SetActive (true);
        if (snapCam.gameObject.activeInHierarchy)
        {

            Texture2D snapShot = new Texture2D(resWith, resHeight, TextureFormat.RGB24, false);
            snapCam.Render();
            RenderTexture.active = snapCam.targetTexture;
            snapShot.ReadPixels(new Rect(0, 0, resWith, resHeight), 0, 0);
            byte[] byetes = snapShot.EncodeToPNG();
            string fileName = SnapShotName();
            System.IO.File.WriteAllBytes(fileName, byetes);
            print("Snapshot Taken");
            snapCam.gameObject.SetActive(false);
        }
    }

    void LateUpdate()
    {
       
    }

    public string SnapShotName()
    {
        print(Application.dataPath + "/snapshot1.png");
        return Application.dataPath + "/snapshot1.png";
    }

}
