using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menucode : MonoBehaviour
{
    // Start is called before the first frame update
    public void startGame()
    {
        SceneManager.LoadScene(1); 
        SFXManager.Instance.playSFX(SFXManager.Instance.startButton, transform.position, 1);
            
    }
}

