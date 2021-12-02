using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HailScript : MonoBehaviour
{

    public float fallSpeed = 0.5f;  //How fast the hail falls
    public float hailGroudcheckLenght = 0.5f;   //The distance the hail blocks use to check for ground

    // Update is called once per frame
    void Update()
    {
        Fall();
    }


    // A function to make the hail block fall
    void Fall()
    {
        // We move the hail down if it's touching anything but the ground
        if (CheckObjectBelow() == null || CheckObjectBelow() == "Player" || CheckObjectBelow() == "Hail Manager" || CheckObjectBelow() == "Lava")
        {
            transform.position -= new Vector3(0,fallSpeed * Time.deltaTime, 0); 
        }
    }

    // A function to check the name for object below
    string CheckObjectBelow()
    {
        // We cast a Box bellow the block so objects are detected trough all base of block
        RaycastHit2D hit = Physics2D.BoxCast(transform.position, new Vector2(2,1), 0, Vector2.down, hailGroudcheckLenght);
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
