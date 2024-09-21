using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public float floorSpeed,enemySpeed,vaultSpeed,vaultTime;
    public int currentVault = 1;
    public float startTime = 0;
    [HideInInspector]
    public float[] rowPositions = {4.17f, 2.5f, 0.835f, -0.835f, -2.5f, -4.17f};
    public float[] spawnTimeRange = {0.7f, 1};
    void Awake() {
        Instance = this;
        GameStart();
    }

    void GameStart(){
        startTime=Time.time;
    }





    


}
