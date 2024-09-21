using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject enemyPrefab;
    int curTime = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         if(curTime<GameManager.Instance.timer){
            Instantiate(enemyPrefab, new Vector3(1, 0, 0), Quaternion.identity);
            curTime+=1;
        }
    }
}
