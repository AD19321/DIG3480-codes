using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_Controller : MonoBehaviour {

    private Animator anim;
    public float speed;
    private bool wallHit;
    private bool playerHit;

    public Transform wallHitBox;
    public Transform playerHitBox;
    public float wallHitWidth;
    public float wallHitHeight;
    public float playerHitWidth;
    public float playerHitHeight;

    public LayerMask isGround;
    public LayerMask isPlayer;

   


    // Use this for initialization
    void Start()
    {
   

    }

     void FixedUpdate()
    {
       transform.Translate(speed * Time.deltaTime, 0, 0);

        wallHit = Physics2D.OverlapBox(wallHitBox.position, new Vector2(wallHitWidth, wallHitHeight), 0, isGround);
        playerHit = Physics2D.OverlapBox(playerHitBox.position, new Vector2(playerHitWidth, playerHitHeight), 0, isPlayer);

        if (wallHit == true)
        {
            speed = speed * -1;
        }
        //Debug.Log(isGround);
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Player" && playerHit == true)
        {
            Debug.Log(playerHit);
            Destroy(gameObject);

        }
    }

    
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(wallHitBox.position, new Vector3(wallHitWidth, wallHitHeight, 1));
        Gizmos.color = Color.blue;
        Gizmos.DrawCube(playerHitBox.position, new Vector3(playerHitWidth, playerHitHeight, 1));

    }

}

        



