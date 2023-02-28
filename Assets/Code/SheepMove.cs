using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SheepMove : MonoBehaviour{
    [SerializeField]
    Transform target;
    NavMeshAgent sheep;
    // Start is called before the first frame update
    void Start() {
        sheep = this.GetComponent<NavMeshAgent>();
        if(sheep == null){
            Debug.LogError("Error 404, please attach "+ gameObject.name);
        }
        else {
            SetDestination();
        }
    }
    private void SetDestination(){
        if(target != null){
            Vector3 vector = target.transform.position;
            sheep.SetDestination(vector);
        }
    }
  
}
