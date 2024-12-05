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
    [SerializeField] GameObject UIInit, UIPersonal, cardUI;
    [Networked] public string textToShow { get; set; }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    

    // Instanciar un mapa específico
    public void InstantiateMap(int numberMap)
    {
        if (numberMap >= 0 && numberMap < maps.Length)
        {
            Runner.Spawn(maps[numberMap]);
        }
        else
        {
            Debug.LogError("Índice de mapa fuera de rango.");
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

    // Instanciar la tarjeta en una posición específica
    public void InstantiateCard(Vector3 position)
    {
        if (cardUI == null)
        {
            Runner.Spawn(card, position, Quaternion.identity); // Instanciar la carta en la red
            cardUI = GameObject.Find("InfoCard");
            if (cardUI != null)
            {
                cardUI.GetComponent<TextMeshProUGUI>().text = textToShow;
            }
            else
            {
                Debug.LogWarning("No se encontró el objeto 'InfoCard' en la escena.");
            }
        }
    }

    // Instanciar objetos dependiendo de una letra
    public void InstantiateObject(string letter, Vector3 position, Quaternion quaternion)
    {
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
                Debug.LogWarning("Letra no válida para instanciar.");
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
                Debug.Log("El elemento no tiene NetworkObject o la red no está corriendo.");
            }
        }
    }
}
