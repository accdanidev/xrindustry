using Fusion;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkPlayerControl : NetworkBehaviour
{
    // Start is called before the first frame update

    public bool isMaster;
    [SerializeField] GameObject UiRef, UIPersonal;
    private GameObject instantiatedUI;

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

    public void ActivatePersonalUI()
    {
        if (HasStateAuthority)
        {
            // Si el jugador tiene la autoridad de estado, llama al RPC
            RPC_ActivateUIForAllPlayers();
        }
        else
        {
            Debug.LogWarning("Solo el jugador con autoridad puede activar la UI.");
        }
    }

    [Rpc(RpcSources.StateAuthority, RpcTargets.All)]
    private void RPC_ActivateUIForAllPlayers()
    {
        // Verifica si la UI ya está activada
        if (instantiatedUI == null)
        {
            // Instancia la UI personal localmente
            FindObjectOfType<InstantiateObjectScript>().DeleteUI();
            instantiatedUI = Instantiate(UIPersonal, UiRef.transform);
            Debug.Log($"UI Personal activada para el jugador: {Object.InputAuthority}");
        }
        else
        {
            Debug.Log("La UI Personal ya está activada.");
        }
    }

    public void InstantiatePeronsalUI()
    {
        Instantiate(UIPersonal, UiRef.transform);
    }


}
