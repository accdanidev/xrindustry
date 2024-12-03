using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.Events;

public class PinScript : MonoBehaviour
{
    [SerializeField] Sprite pinOn, pinOff;
    [SerializeField] Image imageButton;
    [SerializeField] bool pinned = false, pinned3D = false, hideAnchorsBody = false;
    [SerializeField] GameObject grabberObj, obj3D, person3D, anchorsBody;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("Disable3D", 0.01f);
        
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Disable3D()
    {
        if (obj3D != null)
        {
            //obj3D.GetComponent<BoxCollider>().enabled = false;
            this.transform.parent.parent.gameObject.SetActive(false);
        }
    }

    public void ChangePinImage()
    {
        if (!pinned)
        {
            imageButton.sprite = pinOn;
            grabberObj.tag = "Pinned";
           // grabberObj.GetComponent<XRGrabInteractable>().enabled = false;
            pinned = true;
        }
        else
        {
            imageButton.sprite = pinOff;
            grabberObj.tag = "Grabber";
           // grabberObj.GetComponent<XRGrabInteractable>().enabled = true;
            pinned = false;
        }
    }

    public void Pin3D()
    {
        if (!pinned3D)
        {
            imageButton.sprite = pinOn;
            obj3D.tag = "Pinned";
            //obj3D.GetComponent<BoxCollider>().enabled = false;
            //obj3D.GetComponent<XRGrabInteractable>().enabled = false;
            pinned3D = true;
        }
        else
        {
            imageButton.sprite = pinOff;
            //obj3D.GetComponent<BoxCollider>().enabled = true;
           // obj3D.GetComponent<XRGrabInteractable>().enabled = true;
            obj3D.tag = "3D";
            pinned3D = false;
        }
    }

    public void HideAllPinedObject()
    {
        if (!hideAnchorsBody)
        {
            hideAnchorsBody = true;
        }
        else
        {
            hideAnchorsBody = false;
        }
        anchorsBody.SetActive(!hideAnchorsBody);
        //person3D.GetComponent<XRGrabInteractable>().enabled = !hideAnchorsBody;
    }

}
