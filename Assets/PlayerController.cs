using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int currentRow = 3;
    Rigidbody2D rb;
    public bool ammo = true;
    Animator animator;

    Vector3 mousePos,direction; 
    float rotZ;
    GameObject gunPivot;
    LineRenderer line;
    void Start()
    {
        gunPivot = GameObject.Find("player/gunPivot");
        line=gunPivot.GetComponent<LineRenderer>();
        rb = GetComponent<Rigidbody2D>();
        rb.position = new Vector3(-6f, GameManager.Instance.rowPositions[currentRow-1], 0);
        animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown("w") && currentRow!=GameManager.Instance.currentVault) 
            currentRow-=1;
        else if(Input.GetKeyDown("s") && currentRow!=6)
            currentRow+=1;
        
        rb.position = new Vector3(rb.position.x,GameManager.Instance.rowPositions[currentRow-1], 0);

        mousePos=Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction=gunPivot.transform.position-mousePos;
        RaycastHit2D hit = Physics2D.Raycast(gunPivot.transform.position, -direction);
        if(hit.collider != null){
            line.SetPosition(0, gunPivot.transform.position);
            line.SetPosition(1,hit.point);
        }

        if(Input.GetKeyDown("space") && ammo){
            animator.SetTrigger("shoot");
            if(hit.collider.gameObject.layer==7) Destroy(hit.collider.gameObject);
        }




        
        
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.layer==7){
            Destroy(other.gameObject);
        }
    }
}
