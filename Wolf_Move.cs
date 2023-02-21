using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolf_Move : MonoBehaviour
{
    Rigidbody myWolfCharacter;
    public float moveSpeed = 100f;
    public Vector3 moveDirection;
    public Vector2 rotate;
    // Start is called before the first frame update
    void Start()
    {
        myWolfCharacter = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }
    void FixedUpdate(){
        
    }

    void Movement(){
        
        float a = Input.GetAxis("Vertical");
        float b = Input.GetAxis("Horizontal");
        moveDirection = new Vector3(b,0,a);
        moveDirection = transform.TransformDirection(moveDirection);

        moveDirection= moveDirection.normalized*moveSpeed*Time.deltaTime;
        if(Input.GetKey(KeyCode.W))
            b=1;
            myWolfCharacter.MovePosition(transform.position+moveDirection*moveSpeed*Time.deltaTime);
        if(Input.GetKey(KeyCode.S))
            b=-1;
            myWolfCharacter.MovePosition(transform.position+moveDirection*moveSpeed*Time.deltaTime);
        if(Input.GetKey(KeyCode.A))
            a=-1;
            myWolfCharacter.MovePosition(transform.position+moveDirection*moveSpeed*Time.deltaTime);
        if(Input.GetKey(KeyCode.D))
            myWolfCharacter.MovePosition(transform.position+moveDirection*moveSpeed*Time.deltaTime);
            a=1;
          
        rotate.x += Input.GetAxis("Mouse X");
        rotate.y += Input.GetAxis("Mouse Y");
        transform.localRotation=Quaternion.Euler(-rotate.y,rotate.x,0);
    }
    
}