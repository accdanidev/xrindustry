using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion.XR.Shared.Locomotion;
#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

public class ControllerRaycast : MonoBehaviour
{
    //[SerializeField] Vector3 firstRayHit, secondRayHit, initialScale;
    //[SerializeField] Vector3 lastPosition;
    //[SerializeField] float currentDistance, initialDistance;
    [SerializeField] Transform rayOrigin;
    [SerializeField] GameObject selectedObject;
    [SerializeField] bool hitted = false, selected = false;
   //[SerializeField] LineRenderer lineRenderer;
    private Vector3 hitOffset;


    void Start()
    {

    }

    void Update()
    {
        if (selected)
        {

            // Renderizar el rayo desde el origen
            //lineRenderer.SetPosition(0, rayOrigin.position);

            RaycastHit hit;
            //lineRenderer.SetPosition(1, rayOrigin.transform.forward);
            if (Physics.Raycast(rayOrigin.position, rayOrigin.forward, out hit, 2000))
            {
                

                // Detectar el objeto impactado
                if (hit.collider.CompareTag("Grabber"))
                {
                    if (!hitted) // Solo selecciona si no hay un objeto ya seleccionado
                    {
                        selectedObject = hit.collider.gameObject;
                        hitted = true;

                        // Calcular el desplazamiento inicial entre el objeto y el punto de impacto
                        hitOffset = selectedObject.transform.position - hit.point;
                    }

                    // Mover el objeto al seguir impactándolo
                    if (selectedObject != null)
                    {
                        selectedObject.transform.position = hit.point + hitOffset;
                    }
                }
            }
            else
            {
                // Si no hay impacto, extender el rayo hacia adelante
                //lineRenderer.SetPosition(1, rayOrigin.position + rayOrigin.forward * 2000);

                // Soltar el objeto si no se está impactando
                if (hitted)
                {
                    hitted = false;
                    selectedObject = null;
                }
            }

        }
    }


    public void Hitted()
    {
        selected = true;
    }

    public void HitOut()
    {
        selected = false;
        hitted = false;
    }
}
