using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSens = 100f;

    public Transform playerBody;

    float xRot = 0;

    //LateUpdate seems to fix some issues with mouse movement
    void LateUpdate()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSens * Time.deltaTime;
        float mouseY  = Input.GetAxis("Mouse Y") * mouseSens * Time.deltaTime;

        xRot += mouseY;
        xRot = Mathf.Clamp(xRot, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRot, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
