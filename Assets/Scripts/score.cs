using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class score : MonoBehaviour
{
    public static float pScore;
    public float currentScore;
    
    //public float getScore(){
     //   return pScore;
    //}
    public void setScore(float newPlayerScore){
        //pScore+=newPlayerScore;
        currentScore=pScore;
    }

//print(score.pScore);
}
