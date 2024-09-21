using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabExperiment : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector3(GameManager.Instance.speed, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}


