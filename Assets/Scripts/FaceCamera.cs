using UnityEngine;

public class FaceCameraYOnly : MonoBehaviour
{
    public Camera cameraToLookAt;

    void Update()
    {
        Vector3 directionToCamera = transform.position - cameraToLookAt.transform.position;

        directionToCamera.y = 0;

        Quaternion targetRotation = Quaternion.LookRotation(directionToCamera, Vector3.up);

        transform.rotation = targetRotation;
    }
}

