using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class HighscoreUpdaterScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] TMP_Text highscoreText;
    void Start()
    {
        print(PlayerPrefs.GetFloat("highscore", 0));
        highscoreText.text = "Highscore: " + PlayerPrefs.GetFloat("highscore", 0);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
