using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIManager : MonoBehaviour
{

    public GameObject jello;
    public Text score;
    public Text hiScoreText;
    private int currentScore;
    private int hiScore;
    private int allTimeHiScore;


    // Start is called before the first frame update
    void Start()
    {
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
            PlayerPrefs.SetInt("ATHS", allTimeHiScore);
        } 
        score.text = "High Score: " + hiScore + "m\nScore: " + currentScore + "m";
        hiScoreText.text = "HI-SCORE\n" + allTimeHiScore + "m";

    }

}
