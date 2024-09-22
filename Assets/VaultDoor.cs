using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;

public class VaultDoor : MonoBehaviour
{
    Rigidbody2D rb;
    PlayerController player;
    float time, waitTime = 10;
    bool over = false;
    public GameObject finalPlatform;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("player").GetComponent<PlayerController>();
        time=Time.time+waitTime;
    }

    // Update is called once per frame
    void Update(){
        if(over)return;
        if(Time.time>time){
            if(GameManager.Instance.currentVault == 4){
                //gameOver
                //
            }
            GameManager.Instance.platforms[GameManager.Instance.currentVault-1].SetActive(false);
            GameManager.Instance.currentVault+=1;
            time=Time.time+waitTime;
            if(player.currentRow==GameManager.Instance.currentVault)
                player.currentRow+=1;
            
        }
    }

    public void resetVault(){
        // change position up to one level
        if(GameManager.Instance.currentVault==1)return;
        time=Time.time+waitTime;
        rb.position += new Vector2(0,1.8f);

        GameManager.Instance.currentVault-=1;
        GameManager.Instance.platforms[GameManager.Instance.currentVault-1].SetActive(true);


    }
    void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.layer==8){
            //sfx
            if(col.gameObject == finalPlatform){
                print("GAME OVER");
                // pull timer to middle, enter score etc
            }
        }
    }

}
