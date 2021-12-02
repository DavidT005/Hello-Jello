using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject playerObject;
    public string gameState = "Playing";
    public GameObject restartButton;
    bool restartButtonInstantiated = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        checkGameState();
    }

    void checkGameState()
    {
        if (playerObject.GetComponent<SpriteRenderer>().sprite == null && restartButtonInstantiated == false){
            //Instantiate(restartButton, transform.position, transform.rotation);
            //restartButtonInstantiated = true;

        }
        
    }




}
