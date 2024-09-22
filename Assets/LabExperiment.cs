using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabExperiment : MonoBehaviour
{
    public Sprite ammo;
    
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector3(GameManager.Instance.enemySpeed, 0, 0);
    }

    // Update is called once per frame
    public void convertAmmo(){
        if(GetComponent<Animator>() != null) GetComponent<Animator>().enabled = false;
        
        gameObject.layer = 11;
        GetComponent<SpriteRenderer>().sprite=ammo;
        GetComponent<Rigidbody2D>().velocity = new Vector3(GameManager.Instance.enemySpeed/1.2f, 0, 0);
        transform.localScale = new Vector3(0.08f,0.08f,1);
        transform.localEulerAngles = new Vector3(0,0,235);
    }
}


