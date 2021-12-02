using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  // Allows us to load the game scene from main menu

public class MenuManager : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // This function is passed to a button on main menu so we load game on click
    public void StartGame(){
        SceneManager.LoadScene("GameScene");
    }
}
