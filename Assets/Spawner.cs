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
        enemyOdds=Mathf.Clamp(enemyOdds-0.025f, 20, 80);
        frequency=Mathf.Clamp(frequency+0.009f, 5, 40);
        GameManager.Instance.enemySpeed = Mathf.Clamp(GameManager.Instance.enemySpeed-0.003f, -10, -3);
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
                if(GameManager.Instance.newAmmo && id <= GameManager.Instance.currentVault-1){
                    temp.GetComponent<LabExperiment>().convertAmmo();
                    GameManager.Instance.newAmmo = false;
                }
            }
        }
    }

}
