using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public int currentRow = 3;
    Rigidbody2D rb;
    public bool ammo = true;
    public Animator animator;

    Vector3 mousePos,direction = new Vector2(1,0); 
    float rotZ;
    GameObject gunPivot;
    LineRenderer line;

    VaultDoor vault;
    public Image ammoIcon;

    int pStickVal = 0, stickVal = 0;
    int slideThresh = 0;

    Touch[] touches = new Touch[2];
    float startPos = 0;

    void Start()
    {
        gunPivot = GameObject.Find("player/gunPivot");
        line=gunPivot.GetComponent<LineRenderer>();
        rb = GetComponent<Rigidbody2D>();
        rb.position = new Vector3(-6f, GameManager.Instance.rowPositions[currentRow-1], 0);
        animator = GetComponent<Animator>();
        vault = GameObject.Find("VaultDoor").GetComponent<VaultDoor>();
        touches[0]=emptyTouch(); touches[1]=emptyTouch();
    }

    // Update is called once per frame
    void Update()
    {
        if(touches[0].phase!=TouchPhase.Began) touches[0]=emptyTouch();
        touches[1]=emptyTouch();

        for(int i = 0; i<Input.touchCount; i++){
            Touch touch = Input.GetTouch(i);
            if(touches[0].phase==TouchPhase.Moved && touches[1].phase==TouchPhase.Began)
                break; 

            if(touch.phase==TouchPhase.Began){
                if(touches[0].phase==TouchPhase.Canceled && touch.position.x < Screen.width/2){
                    touches[0] = touch;
                    startPos = touches[0].position.y;
                }
                if(touches[1].phase==TouchPhase.Canceled && touch.position.x > Screen.width/2){
                    touches[1] = touch;
                    print("shoot");
                }
            }
            else if(touch.phase==TouchPhase.Moved){
                if(touches[0].phase == TouchPhase.Began){
                    touches[0] = touch;
                    float slideValue = startPos - touches[0].position.y;
                    print(startPos + " - " +  touches[0].position.y + " = " + slideValue);                
                }
                

            }

        }

        if(animator.GetCurrentAnimatorClipInfo(0)[0].clip.name=="gabeDead") return;
        
        stickVal = Input.GetAxisRaw("Vertical")>0.8f?1:Input.GetAxisRaw("Vertical")<-0.8f?-1:0;

        if(stickVal==0 && touches[0].phase==TouchPhase.Moved){
            float slideValue = startPos - touches[0].position.y;
            if(slideValue!=0){
                if(slideValue>slideThresh)stickVal=-1;
                else if(slideValue<(-slideThresh))stickVal=+1;
            }

        }
        
        if(stickVal!=pStickVal){
            if(stickVal==1 && currentRow-1!=GameManager.Instance.currentVault){
                currentRow-=1;
                SFXManager.Instance.playSFX(SFXManager.Instance.jump, transform.position, 1);
            }
            else if(stickVal==-1 && currentRow!=6){
                currentRow+=1;
                SFXManager.Instance.playSFX(SFXManager.Instance.fall, transform.position, 1);
            }
        }
        
        rb.position = new Vector3(rb.position.x,GameManager.Instance.rowPositions[currentRow-1], 0);

        RaycastHit2D hit = Physics2D.Raycast(gunPivot.transform.position, direction, 200, ~(1 << 8));
        line.SetPosition(0, gunPivot.transform.position);
        line.SetPosition(1, hit.point);

        if((Input.GetButtonDown("shoot") || ((int)Input.GetAxisRaw("Trigger"))!=0 || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return) || touches[1].phase==TouchPhase.Began) && ammo){
            toggleAmmo();
            animator.SetTrigger("shoot");
            SFXManager.Instance.playSFX(SFXManager.Instance.shoot, transform.position, 1);
            if(hit.collider.gameObject.layer==7) {
                hit.collider.gameObject.GetComponent<LabExperiment>().convertAmmo();
                SFXManager.Instance.playSFX(SFXManager.Instance.enemyDie, transform.position, 1);
                vault.resetVault();
            }
            else {
                StartCoroutine(spawnNewAmmo());
            }
        }

        pStickVal = stickVal;
        
    }

    IEnumerator spawnNewAmmo()
    {
        yield return new WaitForSeconds(10);
        GameManager.Instance.newAmmo=true;
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.layer==7 || other.gameObject.layer==10){
                GameManager.Instance.dead();
        }
        if(other.gameObject.layer==11){
            if(!ammo)toggleAmmo();
            Destroy(other.gameObject);
            SFXManager.Instance.playSFX(SFXManager.Instance.reload, transform.position, 1);
        }
    }

    void toggleAmmo() { 
        if(ammo){
            ammo = false;
            ammoIcon.color = new Color(0.8f,0.8f,0.8f,0.5f);
        }
        else {
            ammo = true;
            ammoIcon.color = new Color(1,1,1,1);
        }
    }

    Touch emptyTouch()
    {
        Touch emptyTouch = new Touch();
        emptyTouch.phase = TouchPhase.Canceled; 
        return emptyTouch;
    }

}
