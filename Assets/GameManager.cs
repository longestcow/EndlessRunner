using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public float floorSpeed,enemySpeed;
    [HideInInspector]
    public float[] rowPositions = {4.17f, 2.5f, 0.835f, -0.835f, -2.5f, -4.17f};
    
    void Awake() {
        Instance = this;
    }


}
