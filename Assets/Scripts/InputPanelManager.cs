using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.PolySpatial.InputDevices;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;
using TouchPhase = UnityEngine.InputSystem.TouchPhase;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.UI;

public class InputPanelManager : MonoBehaviour
{
    [SerializeField] Vector3 firstTouch, secondTouch, initScale, startPositionScale;
    [SerializeField] Vector3 lastPosition;
    [SerializeField] float currentDistance, previousDistance;
    [SerializeField] GameObject selectedObject, aux;
    private void OnEnable()
    {
        EnhancedTouchSupport.Enable();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        //drag object selected in the AVP
        if (Touch.activeTouches.Count > 0)
        {
            foreach (var touch in Touch.activeTouches)
            {
                SpatialPointerState touchData = EnhancedSpatialPointerSupport.GetPointerState(touch);
                if (touchData.targetObject != null && touchData.Kind != SpatialPointerKind.Touch)
                {
                    print(touchData.targetObject.name);
                    if (touchData.targetObject.CompareTag("Grabber"))
                    {
                        Debug.Log("Grabber");

                        if (touch.phase == TouchPhase.Began)
                        {
                            selectedObject = touchData.targetObject.transform.parent.gameObject; //window stacker
                            lastPosition = touchData.interactionPosition;
                            //window controls>grabber window
                            aux = GameObject.Find("/" + selectedObject.transform.parent.name + "/Window Stacker/Window Controls/Grabber Window/Grabber").gameObject;
                            ChangeDragColor(aux.GetComponent<Image>(), true);
                        }
                        else if (touch.phase == TouchPhase.Moved || selectedObject != null)
                        {
                            Vector3 deltaPosition = touchData.interactionPosition - lastPosition;
                            selectedObject.transform.position += deltaPosition;
                            lastPosition = touchData.interactionPosition;
                        }
                        if (touch.phase == TouchPhase.Ended)
                        {
                            ChangeDragColor(aux.GetComponent<Image>(), false);
                        }

                    }
                    //if (touchData.targetObject.CompareTag("AnchorScale")) {
                    //    Debug.Log("Scale");
                    //    if (touch.phase == TouchPhase.Began)
                    //    {
                    //        // Guardar la escala inicial y la posición inicial del toque
                    //        selectedObject = touchData.targetObject.transform.parent.parent.parent.gameObject;
                    //        //print(selectedObject.name);
                    //        initScale = selectedObject.transform.localScale;
                    //        startPositionScale = touchData.interactionPosition;
                    //        //print(touchData.targetObject.transform.parent.GetChild(0).GetChild(0).name);
                    //        ChangeDragColor(touchData.targetObject.transform.parent.GetChild(0).GetChild(0).gameObject.GetComponent<Image>(), true);

                    //    }
                    //    else if (touch.phase == TouchPhase.Moved && selectedObject != null)
                    //    {
                    //        // Calcular la distancia desde la posición inicial del toque
                    //        Vector3 distance = touchData.interactionPosition - startPositionScale;

                    //        // Calcular la magnitud del movimiento en el espacio local del objeto
                    //        Vector3 localMovement = selectedObject.transform.InverseTransformDirection(distance);

                    //        // Invertir el movimiento para obtener el comportamiento opuesto
                    //        localMovement *= -1f;

                    //        // Calcular el factor de escala basado en el cambio de tamaño deseado
                    //        float scaleFactor = localMovement.y * 0.5f; // Ajusta este valor según la sensibilidad

                    //        // Aplicar la escala al objeto seleccionado
                    //        Vector3 newScale = initScale + Vector3.one * scaleFactor;

                    //        // Asegurar que la escala no sea menor que un cierto límite (opcional)
                    //        float minScale = 0f; // Cambia este valor según sea necesario
                    //        newScale = Vector3.Max(newScale, Vector3.one * minScale);
                    //        print(newScale);

                    //        selectedObject.transform.localScale = newScale;
                    //    }
                    //    else if (touch.phase == TouchPhase.Ended)
                    //    {
                    //        ChangeDragColor(touchData.targetObject.transform.parent.GetChild(0).GetChild(0).gameObject.GetComponent<Image>(), false);
                    //    }

                    //}



                    //else if (touchData.targetObject.CompareTag("AnchorScale"))
                    //{
                    //    Debug.Log("Scale");
                    //    if (touch.phase == TouchPhase.Began)
                    //    {
                    //        print("enter");
                    //        selectedObject = touchData.targetObject.transform.parent.parent.parent.gameObject; ;
                    //        initScale = selectedObject.transform.localScale;
                    //        startPositionScale = touchData.interactionPosition;
                    //    }
                    //    else if (touch.phase == TouchPhase.Moved && selectedObject != null)
                    //    {
                    //        Vector3 distance = touchData.interactionPosition - startPositionScale;
                    //        float scaleFactor = distance.magnitude * 1f;
                    //        selectedObject.transform.localScale = initScale + Vector3.one * scaleFactor;

                    //    }
                    //}
                }
            }
        }



        //Scale The object Selected in AVP

        /* if (Touch.activeTouches.Count > 1)
         {
             var touch1 = Touch.activeTouches[0];
             var touch2 = Touch.activeTouches[1];
             SpatialPointerState touchData1 = EnhancedSpatialPointerSupport.GetPointerState(touch1);
             SpatialPointerState touchData2 = EnhancedSpatialPointerSupport.GetPointerState(touch2);
             if (touchData1.targetObject != null && touchData1.Kind != SpatialPointerKind.Touch && touchData2.Kind != SpatialPointerKind.Touch)
             {
                 if (touchData1.targetObject.CompareTag("3D") || touchData2.targetObject.CompareTag("3D"))
                 {
                     if (touch1.phase == TouchPhase.Began && touch2.phase == TouchPhase.Began)
                     {
                         if (touchData1.targetObject != null)
                         {
                             selectedObject = touchData1.targetObject;
                         }
                         else if (touchData2.targetObject != null)
                         {
                             selectedObject = touchData2.targetObject;
                         }
                         firstTouch = touchData1.interactionPosition;
                         secondTouch = touchData2.interactionPosition;
                         previousDistance = currentDistance;
                     }
                     if ((touch1.phase == TouchPhase.Moved && touch2.phase == TouchPhase.Moved) && selectedObject != null)
                     {
                         currentDistance = secondTouch.magnitude - firstTouch.magnitude;
                         Vector3 scaleValue = selectedObject.transform.localScale * (currentDistance - previousDistance);
                         selectedObject.transform.localScale = scaleValue;
                         previousDistance = currentDistance;
                     }
                 }
             }
         }*/

        //when don't have any interaction we reset all the variables
        if (Touch.activeTouches.Count == 0)
        {
            selectedObject = null;
            firstTouch = Vector3.zero;
            secondTouch = Vector3.zero;
            lastPosition = Vector3.zero;
            currentDistance = 0;
            previousDistance = 0;
        }

    }

    void ChangeDragColor(Image imageDrag, bool _state)
    {
        if (_state)
        {
            imageDrag.color = new Color(0.8235294117647059f, 0.8235294117647059f, 0.8235294117647059f);
        }
        else
        {
            imageDrag.color = Color.white;
        }
    }

}