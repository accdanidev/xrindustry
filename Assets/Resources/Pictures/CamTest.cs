using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamTest : MonoBehaviour
{
    public SnapshotCamera snap;
    // Start is called before the first frame update
    void Start()
    {
        snap = FindObjectOfType<SnapshotCamera>();
        snap.gameObject.SetActive(false);
        Invoke("CallTake", 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CallTake()
    {
        snap.CallTakeSnapShot();
    }
}
