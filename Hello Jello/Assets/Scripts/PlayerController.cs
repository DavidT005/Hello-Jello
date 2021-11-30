using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Vector3 moveDirection;   // To store controller input
    [SerializeField] int playerSpeed = 15;   // How fast will player move
    public float jumpMagnitude = 10f;  //How much is player going to jump
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = transform.GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
        CheckObjectBelow();


    }

    void Move()
    {
        // We get platform-independet user input
        moveDirection.x = Input.GetAxis("Horizontal");
        moveDirection.y = Input.GetAxis("Vertical");

        // Then we update the player's position
        transform.position += moveDirection * Time.deltaTime * playerSpeed; //Updates position, Time.deltaTime is time between frames
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity += new Vector2(rb.velocity.x, jumpMagnitude);
        }
    }

    GameObject CheckObjectBelow()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position,Vector2.down, 5);

        if(hit.collider != null)
        {
            print(hit.collider.gameObject.name);
            return hit.collider.gameObject;
        }
        else
        {
            return null;
        }
    }


}
