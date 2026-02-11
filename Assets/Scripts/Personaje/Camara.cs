using System;
using UnityEngine;

public class Camara : MonoBehaviour
{
    private float mouseMovX;
    private float mouseMovY;
    public float mouseSenseX;
    public float mouseSenseY;

    private Transform padreObj;

    private float rotX = 0;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        padreObj = transform.parent;
    }
    private void Update()
    {
        mouseMovX = Input.GetAxis("Mouse X") * Time.deltaTime * mouseSenseX;
        mouseMovY = Input.GetAxis("Mouse Y") * Time.deltaTime * mouseSenseY;
        

        //Movimiento en Y
        rotX -= mouseMovY;
        rotX = Mathf.Clamp(rotX, -90, 90);
       
    }
    private void FixedUpdate()
    {
        //Movimiento en X
        padreObj.Rotate(Vector3.up * mouseMovX);

        //Movimiento en Y
        transform.localRotation = Quaternion.Euler(rotX, 0, 0);
    }
}
