using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastMovement : MonoBehaviour
{
    [SerializeField] Transform origin, target;
    [SerializeField] GameObject selectedObj;
    [SerializeField] LineRenderer lineRenderer;
    public bool isHitted;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (isHitted && selectedObj != null)
        //{
            lineRenderer.SetPosition(0, origin.position);

            Ray raycast = new Ray(origin.position, origin.forward);
            RaycastHit hit;
            if (Physics.Raycast(raycast, out hit, 100))
            {
                lineRenderer.SetPosition(1, hit.point);
                selectedObj.transform.position = hit.point;
            }
        //}
    }

    public void ActiveRayCast()
    {
        isHitted = true;
    }

    public void DeactiveRayCast()
    {
        isHitted = false;
    }

}
