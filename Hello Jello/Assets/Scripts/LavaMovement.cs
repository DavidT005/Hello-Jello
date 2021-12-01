using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaMovement : MonoBehaviour
{

    public float riseSpeed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Rise();
    }

    void Rise()
    {
        transform.position += new Vector3(0,riseSpeed * Time.deltaTime, 0); 
    }


}
