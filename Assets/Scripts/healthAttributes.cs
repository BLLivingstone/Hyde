using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthAttributes : MonoBehaviour
{   
    public int sheepHealth=3;
    public int damage=2;
    public Wolf_Move wolfmove;



public void sheepTakeDamage(int damage){
    sheepHealth -=damage;
}
public void giveDamage(GameObject target){
    var a = target.GetComponent<healthAttributes>();
    /*if (wolfmove.kickCheck==true){
        damage=2;
    }
    if (wolfmove.punchCheck==true){
        damage=1;
    }
    else{
        damage=0;
    }
    */

    if (a!=null){
        a.sheepTakeDamage(damage);
    }
}

}
