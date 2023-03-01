using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {
    // Start is called before the first frame update
    public void OnTimeUp(){
        gameObject.SetActive(true);
    }

    public void ReturnMainMenu(){
        SceneManager.LoadScene("Menu");
    }
}

/* public GameOverScreen gameOver;

    public GameOver(){
        gameOver.Setup)(noTime);
    }
*/
