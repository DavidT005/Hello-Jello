using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    Vector3 moveDirection;   // To store controller input
    [SerializeField] int playerSpeed = 15;   // How fast will player move
    public float jumpMagnitude = 10f;  //How much is player going to jump
    private Rigidbody2D rb;
    public float rayLenght= 1f;
    public List<AudioClip> playerSounds = new List<AudioClip>();
    public bool isDead = false;

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
        CheckTagBelow();
        CheckIfCrushed();


    }

    void Move()
    {
        // We get platform-independet user input
        moveDirection.x = Input.GetAxis("Horizontal");

        // Then we update the player's position
        transform.position += moveDirection * Time.deltaTime * playerSpeed; //Updates position, Time.deltaTime is time between frames
    
        if (transform.position.x >= 9 ){
            transform.position = new Vector2(-8.5f,transform.position.y);
        }
        if (transform.position.x <= -9 )
        {
            transform.position = new Vector2(8.5f,transform.position.y);
        }
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && CheckTagBelow() == "Jumpable" )
        {
            GetComponent<AudioSource>().PlayOneShot(playerSounds[1]);
            rb.velocity += new Vector2(rb.velocity.x, jumpMagnitude);
        }

        if (Input.GetKeyDown(KeyCode.R)){
            SceneManager.LoadScene("GameScene");
        }
    }

    string CheckTagBelow()
    {
        RaycastHit2D hit = Physics2D.BoxCast(transform.position, new Vector2(1,1), 0, Vector2.down, 0.8f);
        if(hit.collider != null)
        {
            return hit.collider.gameObject.tag;
        }
        else
        {
            return null;
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        collider.GetComponent<AudioSource>().PlayOneShot(playerSounds[0]);
        GetComponent<SpriteRenderer>().sprite = null;
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        isDead = true;
    }

    void CheckIfCrushed()
    {
        RaycastHit2D hit1 = Physics2D.BoxCast(transform.position, new Vector2(1,1), 0, Vector2.down, 0.1f);
        RaycastHit2D hit2 = Physics2D.BoxCast(transform.position, new Vector2(1,1), 0, Vector2.up, 0.1f);
        if(hit1.collider != null && hit2.collider != null)
        {
            GetComponent<AudioSource>().PlayOneShot(playerSounds[2]);
            GetComponent<SpriteRenderer>().sprite = null;
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            isDead = true;
            
        }
    }

}
