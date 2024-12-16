using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Fusion;

public class InstantiateObjectScript : NetworkBehaviour
{
    [SerializeField] NetworkPrefabRef[] maps;
    [SerializeField] NetworkPrefabRef[] assambleAreas;
    [SerializeField] NetworkPrefabRef card;
    [SerializeField] GameObject UIInit, UIPersonal, cardUI, shortCardUI;
    public string textToShow, textToShowShort;
    public GameObject UIo;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    [Rpc(RpcSources.StateAuthority, RpcTargets.All)]
    public void RPC_SendLargeString(string str)
    {
        textToShow = str;
        textToShowShort = textToShow.Length > 90 ? textToShow.Substring(0, 50) + "..." : textToShow;
    }


    // Instanciar un mapa espec�fico
    public void InstantiateMap(int numberMap)
    {
        if (numberMap >= 0 && numberMap < maps.Length)
        {
            Runner.Spawn(maps[numberMap]);
        }
        else
        {
            Debug.LogError("�ndice de mapa fuera de rango.");
        }
    }

    // Instanciar UI en el lugar correspondiente, solo para el Master
    public void InstantiateUI(GameObject pleaceToInstantiate, bool isMaster)
    {
        if (isMaster)
        {
            Instantiate(UIInit, pleaceToInstantiate.transform);
        }
    }

    // Instanciar la UI personal en el lugar correspondiente
    public void InstantiatePersonalUI(GameObject pleace)
    {
        Instantiate(UIPersonal, pleace.transform);
    }

    // Instanciar la tarjeta en una posici�n espec�fica
    public void InstantiateCard(Vector3 position)
    {
        if (cardUI == null)
        {
            print("ingreso");
            Runner.Spawn(card, position, Quaternion.identity); // Instanciar la carta en la red
            cardUI = GameObject.Find("InfoCard");
            shortCardUI = GameObject.Find("InfoCardShort");
            shortCardUI.transform.parent.gameObject.transform.parent.gameObject.SetActive(false);
            if (cardUI != null)
            {
                cardUI.GetComponent<TextMeshProUGUI>().text = textToShow;
                shortCardUI.GetComponent<TextMeshProUGUI>().text = textToShowShort;
            }
            else
            {
                Debug.LogWarning("No se encontr� el objeto 'InfoCard' en la escena.");
            }
        }
    }

    // Instanciar objetos dependiendo de una letra
    public IEnumerator InstantiateObject(string letter, Vector3 position, Quaternion quaternion, float time)
    {
        yield return new WaitForSeconds(time);
        switch (letter)
        {
            case "S":
                Runner.Spawn(assambleAreas[0], position, quaternion);
                break;
            case "E":
                Runner.Spawn(assambleAreas[1], position, quaternion);
                break;
            case "P":
                Runner.Spawn(assambleAreas[2], position, quaternion);
                break;
            case "C":
                Runner.Spawn(assambleAreas[3], position, quaternion);
                break;
            default:
                Debug.LogWarning("Letra no v�lida para instanciar.");
                break;
        }
        
    }

    // Eliminar mapas antiguos de la escena
    public void DeleteOldMap()
    {
        GameObject[] mapObjects = GameObject.FindGameObjectsWithTag("Map");

        foreach (GameObject obj in mapObjects)
        {
            NetworkObject netObj = obj.GetComponent<NetworkObject>();
            if (netObj != null && Runner.IsRunning)
            {
                Runner.Despawn(netObj);
            }
            else
            {
                Debug.Log("El elemento no tiene NetworkObject o la red no est� corriendo.");
            }
        }
    }
}
