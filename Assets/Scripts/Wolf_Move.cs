using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Wolf_Move : MonoBehaviour
{
    Rigidbody myWolfCharacter;
    public float moveSpeed=1.5f;
    public float sprintSpeed=2f;
    private Vector3 currentSpeed;
    private Vector3 moveDirection;
    //private Vector2 rotate;
    public Animator animator;
    public AudioSource kickAudio;
    private float speedSmooth = 0.1f;
    private bool idle=true;
    private bool checkAttack=false;
    private int damage;
    private bool kickCheck;
    private bool punchCheck;
    public score ps;
    sheepHealth ifdead;
    public float timeLeft=30;
    public bool timerRunning=false;
    public TextMesh timeText;
    public TextMesh scoreText;
    public static float pScore;
    private float wScore=10;


    
    // Start is called before the first frame update
    void Start()
    {
        myWolfCharacter = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        animator=GetComponent<Animator>();
        kickAudio=GetComponent<AudioSource>();
        ps=GetComponent<score>();
        timeText=GetComponent<TextMesh>();
        timerRunning =true;
        moveSpeed=1.3f;
        pScore=0;
    }

    // Update is called once per frame
    void Update()
    {        
        Movement();
        doAttack();
        scoreUpdate();
        if (timerRunning){
            if (timeLeft>0){
                timeLeft-=Time.deltaTime;
                DisplayTime(timeLeft);
            }
            else{
                timeLeft=0;
                timerRunning=false;
            }
        
        }
        if(timeLeft==0 && timerRunning==false) FailLevel();  
        if (pScore==wScore) PassLevel();        
    }
    void FailLevel(){
        Application.Quit();
        print("fail level");
    }
    void PassLevel(){
        print("Pass LEvel");
        if (pScore==wScore){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        wScore++;
    }
    void Movement(){
        idle=true;
        animator.SetFloat("Attacking",-1.0f);
        Vector3 control = new Vector3 (Input.GetAxisRaw("Horizontal")*moveSpeed*speedSmooth,0f,Input.GetAxisRaw("Vertical")*moveSpeed*speedSmooth);
        transform.Translate(control);
        currentSpeed=myWolfCharacter.velocity;
        if(checkAttack==false){
            if (Input.GetKey(KeyCode.W) ){
                if (Input.GetKey(KeyCode.LeftShift)){
                    control=control*sprintSpeed;
                    animator.SetFloat("Speed",1.2f);
                }
                else {
                    animator.SetFloat("Speed",0.7f);
                }         
            idle=false;
            }
            if (Input.GetKey(KeyCode.S)){
                if (Input.GetKey(KeyCode.LeftShift)){
                    animator.SetFloat("Speed",-0.8f);
                    control=control*sprintSpeed;
                }
                else {
                    animator.SetFloat("Speed",-0.3f);
                }

            idle=false;
            }
            else if(idle==true) {
                animator.SetFloat("Speed",0f);
            }  
        }        
    }
    void doAttack(){
        if (Input.GetKey(KeyCode.F)){
            kickAudio.Play();
            checkAttack=true;            
            animator.SetFloat("Attacking",0.0f);
            damage=2;  
            kickCheck=true;  
            punchCheck=false;         

        }
        if(Input.GetKey(KeyCode.E)){
            kickAudio.Play();
            checkAttack=true;
            animator.SetFloat("Attacking",0.5f);
            damage=1;    
            punchCheck=true;
            kickCheck=false ;  
            
        }
    checkAttack=false;     
    }
    private void OnTriggerEnter(Collider other){
        if(other.gameObject.tag=="Sheep" && kickCheck==false){
            GameObject sheeps = other.gameObject;
            sheeps.GetComponent<sheepHealth>().setHealth(damage);
            kickCheck=true;
        }
        if(other.gameObject.tag=="Sheep" && punchCheck==false){
            other.gameObject.GetComponent<sheepHealth>().setHealth(damage);
            punchCheck=true;
        }

        
    }
    private void OnTriggerExit(Collider other){
        if (punchCheck==true){
            punchCheck=false;
        }
        if(kickCheck==true){
            kickCheck=false;
        }
    }
    void scoreUpdate(){
        
        //scoreText.text=string.Format("Score {0}",pScore);
        //print(pScore);

    }
    void DisplayTime(float timeDisplaying){
        //pScore+=pScore;
        timeDisplaying+=1;
        float minutes = Mathf.FloorToInt(timeDisplaying/60);
        float seconds = Mathf.FloorToInt(timeDisplaying%60);
        timeText.text = string.Format("Time Left {0:00}:{1:00} Score{2}", minutes, seconds,pScore);        
    }
}



 
    
