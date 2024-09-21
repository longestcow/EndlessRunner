using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject enemyPrefab;
    // public GameObject ammoPrefab, obstaclePrefab;
    int curTime = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void spawnEnemy(){
        Instantiate(enemyPrefab, transform, false);
    }
    // public void spawnAmmo(){
    //     Instantiate(ammoPrefab, transform, false);
    // }
    // public void spawnObstacle(){
    //     Instantiate(obstaclePrefab, transform, false);
    // }

    IEnumerator spawnThing(){
        while(true){

        }
    }

}
