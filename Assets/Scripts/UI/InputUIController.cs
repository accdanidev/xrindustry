using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion.XR.Shared.Locomotion;
using JetBrains.Annotations;
using UnityEngine.UI;
using Unity.VisualScripting;

public class InputUIController : MonoBehaviour
{
    [SerializeField] RayBeamer rayBeamer;
  

    // Start is called before the first frame update
    void Start()
    {
        rayBeamer.onHitEnter.AddListener(OnBeamHitEnter);
    }

    // Update is called once per frame
    void Update()
    {

    }

    protected virtual void OnBeamHitEnter(Collider hitCollition, Vector3 position)
    {
        if (hitCollition.transform.CompareTag("Button"))
        {
            hitCollition.GetComponent<Button>().onClick.Invoke(); 
        }
    }


}
