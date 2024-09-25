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
        float savedHighscore = PlayerPrefs.GetFloat("highscore", 0);
        print("Loaded highscore: " + savedHighscore);
        highscoreText.text = "Highscore: " + savedHighscore + "s";
    }

    // Update is called once per frame
    void Update()
    {
    }
}
