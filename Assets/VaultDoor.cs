using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;

public class VaultDoor : MonoBehaviour
{
    Rigidbody2D rb;
    PlayerController player;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector3(0, GameManager.Instance.vaultSpeed, 0);
        player = GameObject.Find("player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y <= (10 - (GameManager.Instance.currentVault*1.67))){
            GameManager.Instance.currentVault+=1;
            print("floor "+(GameManager.Instance.currentVault-1)+" closed");
            StartCoroutine(ToggleFalling());
            if(GameManager.Instance.currentVault==6){
                //GameOver
            }
        }
    }

    IEnumerator ToggleFalling()
    {
        rb.velocity = new Vector3(0, 0, 0);
        yield return new WaitForSeconds(GameManager.Instance.vaultTime);
        rb.velocity = new Vector3(0, GameManager.Instance.vaultSpeed, 0);
        if(player.currentRow==GameManager.Instance.currentVault){
            player.currentRow+=1;
        }
    }
}
