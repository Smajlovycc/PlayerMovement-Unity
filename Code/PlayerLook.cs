using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public float sensitivity;

    public Transform orientation;

    float xRot;
    float yRot;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void LateUpdate()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxisRaw("Mouse Y") * sensitivity * Time.deltaTime;

        yRot += mouseX;

        xRot -= mouseY;
        xRot = Mathf.Clamp(xRot, -90f, 90f);

        /* OLD
        transform.rotation = Quaternion.Slerp(Quaternion.Euler(xRot, yRot, 0));
        orientation.rotation = Quaternion.Euler(0, yRot, 0);*/

        // Calculate the interpolated rotation using Quaternion.Slerp
        Quaternion targetQuaternion = Quaternion.Euler(xRot, yRot, 0);
        Quaternion newRotation = Quaternion.Slerp(transform.rotation, targetQuaternion, Time.deltaTime * sensitivity);

        // Apply the new rotation to the player object
        transform.rotation = newRotation;

        // Also update the orientation (if needed)
        orientation.rotation = Quaternion.Euler(0, yRot, 0);
    }
}
