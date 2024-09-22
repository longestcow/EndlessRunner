using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public float enemySpeed;
    public int currentVault = 1;
    public float startTime = 0;
    public bool newAmmo = false;
    public float[] rowPositions = {4.27f, 2.6f, 0.935f, -0.735f, -2.6f, -4.27f};
    public GameObject world, spawners, ammoIcon, gun;
    public RawImage bg;
    public Texture black;

    public HUDScript hud;
    public PlayerController player;
    
    public GameObject[] platforms;
    void Awake() {
        Instance = this;
        GameStart();
    }

    void GameStart(){
        startTime=Time.time;
    }

    public void dead(){
        hud.gameEnd=true;
        player.animator.SetTrigger("die");
        spawners.SetActive(false);
        ammoIcon.SetActive(false);
        gun.SetActive(false);
        bg.texture=black;
        foreach(Transform child in world.transform){
            if(child.GetComponentInChildren<SpriteRenderer>()!=null)child.GetComponentInChildren<SpriteRenderer>().enabled=false;
        }
        StartCoroutine(vaultFall());
    }
    
    IEnumerator vaultFall(){
        yield return new WaitForSeconds(2);//change time based on how long anim takes
        for(int i = 0; i<platforms.Length; i++){
            platforms[i].SetActive(false);
        }
    }





    


}
