using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class ResetAllPositions : MonoBehaviour
{

    [SerializeField] GameObject panel;
    [SerializeField] GameObject obj;
    [SerializeField] Transform transform3D;
    [SerializeField] Vector3 resetPositionV3;
    Vector3 position3D;

    // Start is called before the first frame update
    void Start()
    {
        if(obj != null)
            position3D = obj.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetPosition()
    {
        panel.transform.localPosition = resetPositionV3;
        panel.transform.rotation = Quaternion.Euler(0,0,0);
        //panel.transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    public void Reset3D()
    {
        obj.transform.localPosition = new Vector3 (0,0,0);
        obj.transform.rotation = Quaternion.Euler(0,0,0);   
        obj.transform.localScale = new Vector3(0.0016f, 0.0016f, 0.0016f);
        obj.transform.localPosition = position3D;
    }
}
