using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIManager : MonoBehaviour
{

    public GameObject jello;    // To store player object
    public Text score;          // To store the text that displays the current height of player and max height on this rounf
    public Text hiScoreText;    // To store the text that displays the all-time max height of player
    private int currentScore;   // current player's height
    private int hiScore;        // current player's max height
    private int allTimeHiScore; // An int to store the all-time maximum height


    // Start is called before the first frame update
    void Start()
    {
        // We load the value for the all-time high-score from save-file
        allTimeHiScore = PlayerPrefs.GetInt("ATHS");
    }

    // Update is called once per frame
    void Update()
    {
        UpdateScores();
    }


    void UpdateScores()
    {
        currentScore = (int)jello.transform.position.y + 1;
        if (currentScore > hiScore){
            hiScore = currentScore;
        } 
        if (hiScore > allTimeHiScore){
            allTimeHiScore = hiScore;

            // We save the value for the all-time hi-score
            PlayerPrefs.SetInt("ATHS", allTimeHiScore);
        }
        score.text = "High Score: " + hiScore + "m\nScore: " + currentScore + "m";
        hiScoreText.text = "HI-SCORE\n" + allTimeHiScore + "m";

    }

}
