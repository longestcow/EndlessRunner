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
        StartCoroutine(spawnThing());
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
            yield return new WaitForSeconds(Random.Range(GameManager.Instance.spawnTimeRange[0], GameManager.Instance.spawnTimeRange[1]));
            if(Random.Range(0,100)<5){
                //flip a 50/50 coin for obstacle vs enemy
                spawnEnemy();
            }
        }
    }

}
