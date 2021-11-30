using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HailScript : MonoBehaviour
{

    public float fallSpeed = 0.5f;
    public float hailGroudcheckLenght = 0.5f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //transform.position -= new Vector3(0,fallSpeed * Time.deltaTime, 0); 
        Fall();
    }


    void Fall()
    {
        if (CheckObjectBelow() == null || CheckObjectBelow() == "Player" || CheckObjectBelow() == "Hail Manager")
        {
            transform.position -= new Vector3(0,fallSpeed * Time.deltaTime, 0); 
        }
    }


    string CheckObjectBelow()
    {
        RaycastHit2D hit = Physics2D.BoxCast(transform.position, new Vector2(1,1), 0, Vector2.down, hailGroudcheckLenght);
        if(hit.collider != null)
        {
            return hit.collider.gameObject.name;
        }
        else
        {
            return null;
        }

    }


}
