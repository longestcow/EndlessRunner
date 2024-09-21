using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject floorPrefab;
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector3(GameManager.Instance.speed, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.layer==6){
            Instantiate(floorPrefab, transform.parent, false).transform.localPosition+=new Vector3(1,0,0);
        }
    }
}
