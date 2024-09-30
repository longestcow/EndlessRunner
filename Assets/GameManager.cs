using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public float enemySpeed;
    public int currentVault = 1;
    public float startTime = 0;
    public bool newAmmo = false;
    public float[] rowPositions = {4.17f, 2.5f, 0.835f, -0.835f, -2.5f, -4.17f};
    public GameObject world, spawners, ammoIcon, gun;
    public RawImage bg;
    public Texture black;

    public HUDScript hud;
    public PlayerController player;
    
    public GameObject[] platforms;

    public Animator canvasAnim;
    bool waiting;
    void Awake() {
        Instance = this;
        GameStart();
    }

    void GameStart(){
        startTime=Time.time;
        SFXManager.Instance.gameTransition();
    }

    void Update(){
        if(!waiting)return;
        if (Input.GetButtonDown("shoot") || ((int)Input.GetAxisRaw("Trigger"))!=0 || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return) || (Input.touchCount>0 && Input.GetTouch(0).phase == TouchPhase.Began)){
            waiting = false;
            SceneManager.LoadScene(1);
        }
    }

    public void dead(){
        hud.GameEnd();
        SFXManager.Instance.playSFX(SFXManager.Instance.playerDie, transform.position, 1);
        storeHighScore();
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
        yield return new WaitForSeconds(2f);//change time based on how long anim takes
        for(int i = 0; i<platforms.Length; i++){
            platforms[i].SetActive(false);
        }
        yield return new WaitForSeconds(2f);
        canvasAnim.SetTrigger("gameEnd");
        yield return new WaitForSeconds(1.5f);
        waiting = true;
    }

    void storeHighScore(){
        if (hud.finalTime > PlayerPrefs.GetFloat("highscore", 0)){
            print("triggered");
            PlayerPrefs.SetFloat("highscore", hud.finalTime);
            PlayerPrefs.Save();
            print("Highscore saved: " + PlayerPrefs.GetFloat("highscore", 0));
        }
    }




    


}
