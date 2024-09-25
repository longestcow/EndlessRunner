using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject enemyPrefab, obstaclePrefab;
    float enemyOdds = 80, frequency = 5;
    public int id;
    // public GameObject ammoPrefab, obstaclePrefab;
    void Awake()
    {
        enemyOdds = 80;
        frequency = 5;
        StartCoroutine(spawnThing());
    }

    void FixedUpdate()
    {
        enemyOdds=Mathf.Clamp(enemyOdds-0.03f, 10, 90);
        frequency=Mathf.Clamp(frequency+0.009f, 5, 50);
        GameManager.Instance.enemySpeed = Mathf.Clamp(GameManager.Instance.enemySpeed-0.005f, -12, -3);
        print(frequency);
    }

    

    IEnumerator spawnThing(){
        while(true){
            yield return new WaitForSeconds(Random.Range(0.7f, 1f));
            if(Random.Range(0,100)<frequency){//frequency
                GameObject temp;
                if(Random.Range(0,100)<enemyOdds)//ratio
                    temp = Instantiate(enemyPrefab, transform, false);
                else
                    temp = Instantiate(obstaclePrefab, transform, false);
                if(GameManager.Instance.newAmmo && (id == 5 || id == 6)){
                    temp.GetComponent<LabExperiment>().convertAmmo();
                    GameManager.Instance.newAmmo = false;
                }
            }
        }
    }

}
