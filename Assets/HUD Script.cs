using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUDScript : MonoBehaviour
{
    //Reference vaiable for the TMP text component
    [SerializeField] TMP_Text timerText;
    [SerializeField] TMP_Text ammoText;
    float currentTime;
    public int ammo;
    int minutes;
    int seconds;
    float ms;

    
    void Start()
    {
        ammo = 1;
    }

    
    void Update()
    {
        //Timer
        currentTime = Time.time - GameManager.Instance.startTime;
        minutes = Mathf.FloorToInt(currentTime / 60);
        seconds = Mathf.FloorToInt(currentTime % 60);
        ms = (currentTime % 1)*100;

        if (minutes > 0){
            timerText.text = string.Format("{0:00}:{1:00}.{2:00}",minutes, seconds, ms);
        }
        else{
            timerText.text = string.Format("{0:00}.{1:00}",seconds, ms);
        }


        ammoText.text = "Ammo: " + ammo.ToString() + "/1";

    }
}
