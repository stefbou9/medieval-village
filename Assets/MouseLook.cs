using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 400f;

    
    public Transform playerBody;

    float xRotation = 0f; //move around the x-axis

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // hide and lock ton cursor sto kentro tis othonis
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime; //theloume to time.deltatime wste na ananewnetai to sensitivity toy kathe frame 
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY; //every frame we're going to decrease our xRotation based on mouseY. We decreasing mouseY instead of increasing because when i increased it the rotation was flipped

        //clamping rotation
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // this way we make sure that we can never over-rotate and look behind the player // clamp between -90 and 90
        
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
       //x,y,z arguments (xRotation for x, 0f for y and z)
          //quaternion is responsible for rotation in unity
        //o logos po to kanoume auto kai den xrisimopoioume apla to playerBody.Rotate einai giati xrisimopoioume Clamping (diladi o paiktis na exei elegxo mono 180 moirwn kai oxi parapanw)
        playerBody.Rotate(Vector3.up * mouseX);
        
    }
}
