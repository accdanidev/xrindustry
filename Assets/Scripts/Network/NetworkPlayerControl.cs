using Fusion;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkPlayerControl : NetworkBehaviour
{
    // Start is called before the first frame update

    public bool isMaster;
    [SerializeField] GameObject UiRef;

    private void Start()
    {
        Invoke("InstantiateUI", 1);
    }

    public void SetMasterPlayer(bool level)
    {
        isMaster = level;
    }

    public bool GetIsMaster()
    {
        return isMaster;
    }

    public void InstantiateUI()
    {
        FindObjectOfType<InstantiateObjectScript>().InstantiateUI(UiRef, isMaster);
    }

}
