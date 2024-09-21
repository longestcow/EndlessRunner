using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    int currentRow = 3;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.position = new Vector3(-6f, GameManager.Instance.rowPositions[currentRow-1], 0);
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("w") && currentRow!=1) 
            currentRow-=1;
        else if(Input.GetKeyDown("s") && currentRow!=6)
            currentRow+=1;
        
        rb.position = new Vector3(rb.position.x,GameManager.Instance.rowPositions[currentRow-1], 0);
        
        
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.layer==7){
            Destroy(other.gameObject);
        }
    }
}
