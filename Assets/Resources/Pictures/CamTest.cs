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
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            snap.CallTakeSnapShot();
        }
    }
}
