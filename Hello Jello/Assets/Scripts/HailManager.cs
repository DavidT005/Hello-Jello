using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HailManager : MonoBehaviour
{

    public GameObject hail; 
    public float hailWaitTime;  // The time between each hail
    public Vector2 dropPos = new Vector2(0,5);
    public float zenithSpeed = 0.5f;

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

    void SpawnHail()
    {
        GameObject newHail = Instantiate(hail, dropPos, transform.rotation);
        newHail.transform.parent = transform;
    }

    void UpdateDropPos()
    {
        dropPos = new Vector2(Random.Range(-10f,10f), dropPos.y + zenithSpeed*Time.deltaTime);
    }


}
