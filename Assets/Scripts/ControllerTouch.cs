using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.PolySpatial.InputDevices;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;
using TouchPhase = UnityEngine.InputSystem.TouchPhase;
using UnityEngine.InputSystem.LowLevel;

public class ControllerTouch : MonoBehaviour
{
    [SerializeField] Vector3 firstTouch, secondTouch, initialScale;
    [SerializeField] Vector3 lastPosition;
    [SerializeField] float currentDistance, initialDistance;
    [SerializeField] GameObject selectedObject;
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
        //if (Touch.activeTouches.Count > 0)
        //{
        //    foreach (var touch in Touch.activeTouches)
        //    {
        //        SpatialPointerState touchData = EnhancedSpatialPointerSupport.GetPointerState(touch);
        //        if (touchData.targetObject != null && touchData.Kind != SpatialPointerKind.Touch)
        //        {
        //            if (touchData.targetObject.CompareTag("3D")) {
        //                if (touch.phase == TouchPhase.Began)
        //                {
        //                    selectedObject = touchData.targetObject;
        //                    lastPosition = touchData.interactionPosition;
        //                }
        //                else if (touch.phase == TouchPhase.Moved && selectedObject != null)
        //                {
        //                    Vector3 deltaPosition = touchData.interactionPosition - lastPosition;
        //                    selectedObject.transform.position += deltaPosition;
        //                    lastPosition = touchData.interactionPosition;
        //                }
        //            }
        //        }
        //    }
        //}
        //Scale The object Selected in AVP

        if (Touch.activeTouches.Count > 1)
        {
            var touch1 = Touch.activeTouches[0];
            var touch2 = Touch.activeTouches[1];
            SpatialPointerState touchData1 = EnhancedSpatialPointerSupport.GetPointerState(touch1);
            SpatialPointerState touchData2 = EnhancedSpatialPointerSupport.GetPointerState(touch2);
            if (touchData1.targetObject != null && touchData1.Kind != SpatialPointerKind.Touch && touchData2.Kind != SpatialPointerKind.Touch) 
            {
                if (touchData1.targetObject.CompareTag("3D") || touchData2.targetObject.CompareTag("3D")) 
                {
                    if (touch1.phase == TouchPhase.Began || touch2.phase == TouchPhase.Began)
                    {
                        if (touchData1.targetObject != null) 
                        { 
                            selectedObject = touchData1.targetObject;
                        }
                        else if(touchData2.targetObject != null)
                        {
                            selectedObject = touchData2.targetObject;
                        }
                        firstTouch = touchData1.interactionPosition;
                        secondTouch = touchData2.interactionPosition;
                        initialDistance = Vector3.Distance(firstTouch, secondTouch);
                        initialScale = selectedObject.transform.localScale;
                    }
                    if ((touch1.phase == TouchPhase.Moved || touch2.phase == TouchPhase.Moved) && selectedObject != null)
                    {
                        Vector3 currentTouch1 = touchData1.interactionPosition;
                        Vector3 currentTouch2 = touchData2.interactionPosition;
                        float currentDistance = Vector3.Distance(currentTouch1, currentTouch2);

                        float scaleDelta = currentDistance - initialDistance;
                        float scaleFactor = 1 + scaleDelta * 0.001f;
                        selectedObject.transform.localScale = initialScale * scaleFactor;
                    }
                }
            }
        }

        //when don't have any interaction we reset all the variables
        if (Touch.activeTouches.Count == 0) 
        {
            selectedObject = null;
            firstTouch = Vector3.zero;
            secondTouch = Vector3.zero;
            lastPosition = Vector3.zero;
            currentDistance = 0;
            initialDistance = 0;
        }

    }
}
