using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class MouseCamera : MonoBehaviour
{

    public float speedH = 2.0f;
    public float speedV = 2.0f;

    private float yaw = 0.0f;
    private float pitch = 0.0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        yaw += speedH * Input.GetAxis("Mouse X");
        transform.eulerAngles = new Vector3(0, yaw, 0.0f);


        if (Input.GetKey(KeyCode.M))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
