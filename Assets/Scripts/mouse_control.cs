using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouse_control : MonoBehaviour
{
    public Transform myWolfCharacter;
    private float rotX,rotY,mouseMoveX;
    private float sensitivity = 100f;
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        sensitivity = 100f;
    }

    // Update is called once per frame
    void Update()
    {
       cameraControl();
        
    }
    void cameraControl(){
        
        rotX = Input.GetAxis("Mouse X")*sensitivity*Time.deltaTime;
        rotY = Input.GetAxis("Mouse Y")*sensitivity*Time.deltaTime;
        
        mouseMoveX -=rotY;
        mouseMoveX = Mathf.Clamp(mouseMoveX,10,15);

        //transform.LookAt(myWolfCharacter.transform.position);
        transform.localRotation = Quaternion.Euler(mouseMoveX,0f,0f);
        myWolfCharacter.Rotate(Vector3.up*rotX);     
                 
    }

}