using System;
using System.Collections;
using System.Collections.Generic;
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

    void Start()
    {
        gunPivot = GameObject.Find("player/gunPivot");
        line=gunPivot.GetComponent<LineRenderer>();
        rb = GetComponent<Rigidbody2D>();
        rb.position = new Vector3(-6f, GameManager.Instance.rowPositions[currentRow-1], 0);
        animator = GetComponent<Animator>();
        vault = GameObject.Find("VaultDoor").GetComponent<VaultDoor>();

    }

    // Update is called once per frame
    void Update()
    {
        if(animator.GetCurrentAnimatorClipInfo(0)[0].clip.name=="gabeDead") return;
        stickVal = Input.GetAxisRaw("Vertical")>0.8f?1:Input.GetAxisRaw("Vertical")<-0.8f?-1:0;
        print(stickVal);

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
        line.SetPosition(1,hit.point);

        if((Input.GetButtonDown("shoot") || ((int)Input.GetAxisRaw("Trigger"))!=0 || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.LeftShift)) && ammo){
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

}
