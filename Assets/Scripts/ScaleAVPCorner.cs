using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.PolySpatial.InputDevices;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;
using TouchPhase = UnityEngine.InputSystem.TouchPhase;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.UI;

public class ScaleAVPCorner : MonoBehaviour
{

    [SerializeField] GameObject selectedObject;
    [SerializeField] Vector3 firstTouch, secondTouch, initScale, startPositionScale;
    [SerializeField] Vector3 lastPosition;
    [SerializeField] float currentDistance, previousDistance, minScaleFactor, minScaleFactorPanel;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Touch.activeTouches.Count > 0)
        {
            foreach (var touch in Touch.activeTouches)
            {
                SpatialPointerState touchData = EnhancedSpatialPointerSupport.GetPointerState(touch);
                if (touchData.targetObject != null && touchData.Kind != SpatialPointerKind.Touch)
                {

                    if (touchData.targetObject.CompareTag("AnchorScale3D"))
                    {
                        if (touch.phase == TouchPhase.Began)
                        {
                            selectedObject = touchData.targetObject.transform.parent.parent.gameObject;
                            startPositionScale = touchData.interactionPosition;
                            initScale = selectedObject.transform.localScale;
                            
                        }
                        else if (touch.phase == TouchPhase.Moved && selectedObject != null)
                        {
                            Vector3 controllerDelta = touchData.interactionPosition - startPositionScale;
                            float scaleFactor = 1.0f + controllerDelta.magnitude * Mathf.Sign(Vector3.Dot(controllerDelta, touchData.targetObject.transform.position - selectedObject.transform.position));
   
                            if (scaleFactor >= minScaleFactor)
                                selectedObject.transform.localScale = initScale * scaleFactor;
                        }
                        else if (touch.phase == TouchPhase.Ended)
                        {
                            selectedObject = null;
                        }
                    }
                    else if (touchData.targetObject.CompareTag("AnchorScale"))
                    {
                        if (touch.phase == TouchPhase.Began)
                        {
                            selectedObject = touchData.targetObject.transform.parent.parent.parent.parent.parent.gameObject;
                            startPositionScale = touchData.interactionPosition;
                            initScale = selectedObject.transform.localScale;

                        }
                        else if (touch.phase == TouchPhase.Moved && selectedObject != null)
                        {
                            Vector3 controllerDelta = touchData.interactionPosition - startPositionScale;
                            float scaleFactor = 1.0f + controllerDelta.magnitude * Mathf.Sign(Vector3.Dot(controllerDelta, touchData.targetObject.transform.position - selectedObject.transform.position));
                            print(scaleFactor);
                            if(scaleFactor >= minScaleFactorPanel)
                                selectedObject.transform.localScale = initScale * scaleFactor;
                        }
                        else if (touch.phase == TouchPhase.Ended)
                        {
                            selectedObject = null;
                            initScale = Vector3.zero;
                            startPositionScale = Vector3.zero;
                        }
                    }
                }
                
            }
            
        }

    }

}
