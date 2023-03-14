using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SheepMove : MonoBehaviour{
    [SerializeField]
    //public GameObject myWolfCharacter;
    public Transform enemy;
    public NavMeshAgent sheep;
    public LayerMask ground, wolf;

    //Wandering
    public Vector3 movement;
    public bool setMovement;
    public float movementArea;

    //while scared
    public float timeResting;
    public bool currentlyLooking;

    //avoiding wolf
    public float runArea, FOV;
    public bool wolfInFOV, wolfInRunArea;


   //l "myWolfCharacter"

/*   // Start is called before the first frame update
    void Start() {
        sheep = this.GetComponent<NavMeshAgent>();
        if(sheep == null){
            Debug.LogError("Error 404, please attach "+ gameObject.name);
        }
        else {
            GoToNextPoint();
        }
    }
    private void GoToNextPoint(){
        if(target != null){
            Vector3 vector = target.transform.position;
            sheep.SetDestination(vector);
        }
    }
*/  private void Alive(){
        enemy = GameObject.Find("myWolfCharacter").transform;
        sheep = GetComponent<NavMeshAgent>();
        float startZ = Random.Range(-13,61);
        Vector3 startPointRandom = new Vector3 (0,0,startZ);
        sheep.SetDestination(startPointRandom);
    }
    private void Update(){
        //update sight range 
        wolfInFOV = Physics.CheckSphere(transform.position, FOV, wolf);
        wolfInRunArea = Physics.CheckSphere(transform.position, runArea, wolf);

        if(!wolfInFOV && !wolfInRunArea) Wandering();
        if(wolfInFOV && wolfInRunArea) Running();
        if(wolfInFOV && !wolfInRunArea) Looking();
    }
    private void Wandering(){
        if(!setMovement) NextWanderingPoint();

        if(setMovement){
            sheep.SetDestination(movement);
        }

        Vector3 wanderToPoint = transform.position - movement;

        if(wanderToPoint.magnitude <1f){
            setMovement =false;
        }
    }
    private void NextWanderingPoint(){
        float randZ = Random.Range(-movementArea, movementArea);
        float randX = Random.Range(-movementArea, movementArea);

        movement = new Vector3(transform.position.x + randX, transform.position.y, transform.position.z + randZ);

        if (Physics.Raycast(movement, -transform.up, 2f, ground)){
            setMovement = true;
        }
    } 
    private void Running(){
        if (runArea < FOV){
            Vector3 directionOfWolf = transform.position - enemy.transform.position;
            Vector3 newMovement = transform.position + directionOfWolf;

            sheep.SetDestination(newMovement);
        }
    
    }
    private void Looking(){
        sheep.SetDestination(transform.position);
        transform.LookAt(enemy);

        if(!currentlyLooking){
            currentlyLooking = true;
            Invoke(nameof(ResetLook), timeResting);
        }
    }
    private void ResetLook(){
        currentlyLooking = false;
    }
}