using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour {

    private Rigidbody2D rb2d;

    public float speed;
    public float jumpForce;
    private bool jump;

    public float moveHorizontal;


    private bool FaceRight;
    
    //ground check
    private bool isOnGround;
    public Transform groundcheck;
    public float checkRadius;
    public LayerMask allGround;

    private Animator animateCharacter;

    public AudioSource jumpsource;
   
  



    // Use this for initialization
    void Start () {

        FaceRight = true;
        rb2d = GetComponent<Rigidbody2D>();
        animateCharacter = GetComponent<Animator>();
        
        
        }

    void Awake()
    {

        jumpsource = GetComponent<AudioSource>();
       

    }
    private void Update()
    {
        if (Input.GetKey("escape"))
            Application.Quit();
    }


    // Update is called once per frame
    void FixedUpdate () {
        moveHorizontal = Input.GetAxis("Horizontal");

        // Vector2 movement = new Vector2(moveHorizontal, 0);

        // rb2d.AddForce(movement * speed);
        if(moveHorizontal!=0 && isOnGround)
        {
            animateCharacter.SetBool("isWalk", true);
            animateCharacter.SetBool("isIdle", false);
            animateCharacter.SetBool("isJumping", false);
        }
        else if(moveHorizontal == 0 && isOnGround)
        {
            animateCharacter.SetBool("isWalk", false);
            animateCharacter.SetBool("isIdle", true);
            animateCharacter.SetBool("isJumping", false);
        }
        else
        {
            animateCharacter.SetBool("isWalk", false);
            animateCharacter.SetBool("isIdle", false);
            animateCharacter.SetBool("isJumping", true);
        }
        

       
        
        rb2d.velocity = new Vector2(moveHorizontal * speed, rb2d.velocity.y);

        isOnGround = Physics2D.OverlapCircle(groundcheck.position, checkRadius, allGround);

        //Debug.Log(isOnGround);

        Movement(moveHorizontal);
    }

  

    //animates the character and seeing where it is faceing 
    void Movement(float moveHorizontal)
    {
        //this will animate the player.
        //animateCharacter.SetFloat("speed", Mathf.Abs(moveHorizontal






        if (moveHorizontal > 0 && !FaceRight)
        {
            // ... flip the player.
            Flip();
        }
        // Otherwise if the input is moving the player left and the player is facing right...
        else if (moveHorizontal < 0 && FaceRight)
        {
            // ... flip the player.
            Flip();
        }
    }

    //seeing if the player is on the ground
    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground"&& isOnGround)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
          
                 rb2d.velocity = Vector2.up * jumpForce;
                jumpsource.Play(); 
               
            }
        }

        if (collision.collider.tag == "Enemy" && isOnGround)
        {

           gameObject.SetActive(false);
        }

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.CompareTag ("Pickup"))
        {

            other.gameObject.SetActive(false);
        }
        /*if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("hi");
            other.gameObject.SetActive(false);
        }*/

    }
  

    //flips in the opposite direction
    void Flip()
    {
        FaceRight = !FaceRight;

        Vector3 Scale = transform.localScale;

        Scale.x *= -1;

        transform.localScale = Scale;
    }
}
