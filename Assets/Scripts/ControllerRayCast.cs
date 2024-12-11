using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion.XR.Shared.Locomotion;

public class ControllerRaycast : MonoBehaviour
{
    [SerializeField] Vector3 firstRayHit, secondRayHit, initialScale;
    [SerializeField] Vector3 lastPosition;
    [SerializeField] float currentDistance, initialDistance;
    [SerializeField] GameObject selectedObject;
    [SerializeField] bool hitted = false;

    RayBeamer ray;

    [SerializeField] Camera mainCamera; // Cámara que emitirá el rayo

    void Start()
    {

    }

    void Update()
    {
        if (hitted && selectedObject != null)
        {
            print(ray.lastHit);
        }
        else
        {

        }

    }


    public void Hitted(RayBeamer rayB)
    {
        ray = rayB;
        hitted = true;
    }

    public void HitOut()
    {

    }
}
