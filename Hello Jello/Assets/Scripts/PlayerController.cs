using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Vector3 moveDirection;   // To store controller input
    [SerializeField] int playerSpeed = 15;   // How fast will player move

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // We get platform-independet user input
        moveDirection.x = Input.GetAxis("Horizontal");
        moveDirection.y = Input.GetAxis("Vertical");

        // Then we update the player's position
        transform.position += moveDirection * Time.deltaTime * playerSpeed; //Updates position, Time.deltaTime is time between frames

        
    }
}
