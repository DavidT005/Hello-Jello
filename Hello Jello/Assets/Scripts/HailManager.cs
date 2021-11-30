using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HailManager : MonoBehaviour
{

    public GameObject hail; 
    public float hailWaitTime;  // The time between each hail

    // Start is called before the first frame update
    void Start()
    {
      InvokeRepeating("SpawnHail", 1f, hailWaitTime);   //Calls the SpawnHail method every 0.5s
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnHail()
    {
        float xHailPos = Random.Range(-10f,10f);
        GameObject newHail = Instantiate(hail, new Vector2(xHailPos,5), transform.rotation);
        newHail.transform.parent = transform;
        
    }


}
