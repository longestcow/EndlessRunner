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

    Vector3 mousePos,direction; 
    float rotZ;
    GameObject gunPivot;
    LineRenderer line;

    VaultDoor vault;
    public Image ammoIcon;

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

        if(Input.GetKeyDown("w") && currentRow-1!=GameManager.Instance.currentVault) 
            currentRow-=1;
        else if(Input.GetKeyDown("s") && currentRow!=6)
            currentRow+=1;
        
        rb.position = new Vector3(rb.position.x,GameManager.Instance.rowPositions[currentRow-1], 0);

        mousePos=Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction=gunPivot.transform.position-mousePos;
        RaycastHit2D hit = Physics2D.Raycast(gunPivot.transform.position, -direction, 200, ~(1 << 8));
        if(hit.collider != null){
            line.SetPosition(0, gunPivot.transform.position);
            line.SetPosition(1,hit.point);
        }

        if(Input.GetKeyDown("space") && ammo){
            toggleAmmo();
            animator.SetTrigger("shoot");
            if(hit.collider.gameObject.layer==7) {
                hit.collider.gameObject.GetComponent<LabExperiment>().convertAmmo();
                vault.resetVault();
            }
            else {
                StartCoroutine(spawnNewAmmo());
            }
        }
        
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
        }
    }

    void toggleAmmo() { //sfx
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
