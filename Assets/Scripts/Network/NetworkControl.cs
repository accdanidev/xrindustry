using Fusion;
using Fusion.Sockets;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class NetworkControl : MonoBehaviour
{ 

    [Networked] public int connectedPeople { get; set; } = 0;

    public void OnConnectPlayer()
    {

        if (connectedPeople == 0)
            FindObjectOfType<NetworkPlayerControl>().SetMasterPlayer(true);
        else
            FindObjectOfType<NetworkPlayerControl>().SetMasterPlayer(false);
        connectedPeople++;
    }

    public void OnDisconectPlayer()
    {
        connectedPeople--;
    }



}
