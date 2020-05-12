using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public float speed = 120.0f;
    public float mouseX;
    public float mouseY;
    public float clampAngle = 80.0f;
    public float inputSensitivity = 150.0f;
    public float finalInputX;
    public float finalInputZ;
    public float smoothX;
    public float smoothY;
    private float rotY = 0.0f;
    private float rotX = 0.0f;


    // Start is called before the first frame update
    void Start()
    {
        Vector3 rot = transform.localRotation.eulerAngles; //gets the current euler angles
        rotY = rot.y;
        rotX = rot.x;
        Cursor.lockState = CursorLockMode.Locked; //locks cursor in the middle of the screen
        Cursor.visible = false; //removes cursor from the screen

    }

    // Update is called once per frame
    void Update()
    {
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");

        rotY += mouseX * inputSensitivity * Time.deltaTime;
        rotX -= mouseY * inputSensitivity * Time.deltaTime; //inverted so you look up when movin mouse up

        rotX = Mathf.Clamp(rotX, -clampAngle, clampAngle); //prevents it from infinitely moving

        Quaternion localRotation = Quaternion.Euler(rotX, rotY, 0.0f);
        transform.rotation = localRotation;

    }
}
