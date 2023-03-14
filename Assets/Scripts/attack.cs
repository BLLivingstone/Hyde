using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack : MonoBehaviour
{
    Rigidbody myWolfCharacter;
    private bool checkAttack=false;
    public Animator animator;
void start(){
    myWolfCharacter = GetComponent<Rigidbody>();
    Cursor.lockState = CursorLockMode.Locked;
    animator=GetComponent<Animator>();
}
void update(){
    doAttack();
}

    // Start is called before the first frame update
void doAttack(){
    if (Input.GetKey(KeyCode.F)){
        checkAttack=true;
        print("Attacking");
        animator.SetBool("Attack",true);
        animator.SetFloat("Attacking",0.0f);
    }
    if(Input.GetKey(KeyCode.E)){
        checkAttack=true;
        animator.SetBool("Attack",true);
        animator.SetFloat("Attacking",0.5f);
    }
    
}
}
