using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sheepHealth : MonoBehaviour
{
public int health;
score s;
public AudioSource baa;
Vector3 deathPos;
public bool sheepDead;
float scoreVal=1;
public TextMesh healthText;
private int counter;

void Start(){
    health =20;
    baa=GetComponent<AudioSource>();
    healthText=GetComponent<TextMesh>();
    sheepDead=false;
    healthText.text=string.Format("Health{0}", health);
}

int getHealth(){
    return health;
}
public void setHealth(int newHealth){
    int a;
    health-=newHealth;
    healthText.text=string.Format("Health{0}", health);
    if(health<=0){
        sheepDead=true; 
        this.transform.rotation=Quaternion.Euler(70,40,0);
        Vector3 deathPos=new Vector3(this.transform.position.x,0.3f,this.transform.position.z);
        this.transform.position=deathPos;       
        Destroy(gameObject,1);
        baa.Play();   
        
        healthText.text=string.Format("DEAD");
    }
    if (sheepDead==true){
        Wolf_Move.pScore+=1;
        sheepDead=false;
    }
    
}

public bool isSheepDead(){
    return sheepDead;

}
}
