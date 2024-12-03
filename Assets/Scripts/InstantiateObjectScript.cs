using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using Fusion;

public class InstantiateObjectScript : NetworkBehaviour
{
    [SerializeField] NetworkPrefabRef[] maps;
    [SerializeField] NetworkPrefabRef[] assambleAreas;
    [SerializeField] NetworkPrefabRef card;
    [SerializeField] GameObject UIInit;
    [Networked] public string textToShow { get; set; }


    // Start is called before the first frame update
    void Start()
    {

    }



    // Update is called once per frame
    void Update()
    {

    }

    public void InstantiateMap(int numberMap)
    {
        Runner.Spawn(maps[numberMap]);
        //Instantiate(maps[numberMap]);
    }

    public void InstantiateUI(GameObject pleaceToInstantiate, bool isMaster)
    {
        if (isMaster)
        {
            GameObject obj = Instantiate(UIInit, pleaceToInstantiate.transform);
        }

    }

    public void InstantiateCard(Vector3 position)
    {
        //GameObject obj = Instantiate(card, position, Quaternion.identity);
        Runner.Spawn(card, position, Quaternion.identity);
        GameObject.Find("InfoCard").GetComponent<TextMeshProUGUI>().text = textToShow;
    }

    public void IsntantiateObject(string letter, Vector3 position, Quaternion quaternion)
    {
        print(letter);
        if (letter == "S")
        {
            //GameObject obj = Instantiate(assambleAreas[0], position, quaternion);
            Runner.Spawn(assambleAreas[0], position, quaternion);
        }
        else if (letter == "E")
        {
            //GameObject obj = Instantiate(assambleAreas[1], position, quaternion);
            Runner.Spawn(assambleAreas[1], position, quaternion);
        }
        else if (letter == "P")
        {
            //GameObject obj = Instantiate(assambleAreas[2], position, quaternion);
            Runner.Spawn(assambleAreas[2], position, quaternion);
        }
        else if (letter == "C")
        {
            //GameObject obj = Instantiate(assambleAreas[3], position, quaternion);
            Runner.Spawn(assambleAreas[3], position, quaternion);
        }
    }
}
