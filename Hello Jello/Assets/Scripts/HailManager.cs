using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HailManager : MonoBehaviour
{

    public GameObject hail;     // To store the hail's prefab
    public float hailWaitTime;  // The time between each hail creation
    public Vector2 dropPos = new Vector2(0,5);  // The position where the hail is dropped off
    public float zenithSpeed = 0.5f;    // How fast dropPos goes up

    // Start is called before the first frame update
    void Start()
    {
      InvokeRepeating("SpawnHail", 1f, hailWaitTime);   //Calls the SpawnHail method every 0.5s
    }

    // Update is called once per frame
    void Update()
    {
        UpdateDropPos();
    }

    // The function that spawns all falling blocks
    void SpawnHail()
    {

        // We instantiate the prefab for the block we saved on the var "hail" on the position calculated in "dropPos()" and the manager's rotation
        GameObject newHail = Instantiate(hail, dropPos, transform.rotation);
        //We randomize the block's color
        newHail.GetComponent<SpriteRenderer>().color = Random.ColorHSV(0f, 1f);
        // We set the block as a child of the manager so Unity editor is more organized
        newHail.transform.parent = transform;
    }

    // Calculates the new position from which the blocks are going to be released
    void UpdateDropPos()
    {
        dropPos = new Vector2(Random.Range(-7.8f, 7.8f), dropPos.y + zenithSpeed*Time.deltaTime);
    }


}
