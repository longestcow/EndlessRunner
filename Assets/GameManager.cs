using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public float floorSpeed,enemySpeed;
    public int currentVault = 1;
    public int timer = 0;
    [HideInInspector]
    public float[] rowPositions = {4.17f, 2.5f, 0.835f, -0.835f, -2.5f, -4.17f};
    
    void Awake() {
        Instance = this;
        GameStart();
    }

    void GameStart(){
        StartCoroutine(Timer());
    }

    IEnumerator Timer(){
        yield return new WaitForSeconds(1);
        timer+=1;
        StartCoroutine(Timer());
    }


}
