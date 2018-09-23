using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public float speed;
    public Text countText;
    public Text winText;
    public Text takeText;

    private Rigidbody rb;
    private int count;
    private int takeaway;

    
    


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        takeaway = 0;
        SetCountText();
        winText.text = "";
    }

    void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }

    //code for physics
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        ChangeColorObject();
        rb.AddForce(movement *speed);
    }
    
    //for picking up objects
    void OnTriggerEnter(Collider other)
    {
       if(other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }

        if (other.gameObject.CompareTag("Pick Up Red"))
        {
            other.gameObject.SetActive(false);
            takeaway++;
            SetCountText();
        }

    }
    //for the collision of the walls
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            takeaway++;
            SetCountText();
        }
    }
    
   void SetCountText()
    {
        countText.text = "Count:" + count.ToString();
        takeText.text = takeaway.ToString() + ":Take Away";

        //moving to a different platform
        if (count == 12)
        {
            Vector3 pos = transform.position;
            pos.x = 40;

            transform.position = pos;
            
        }
        //freezes the player and print the score.
        if (count == 24)
        {
            winText.text = "You Finished with a score of:" + (count - takeaway).ToString();

            rb.constraints = RigidbodyConstraints.FreezePosition;
        }

    }


    void ChangeColorObject()
    {
        Color newColor;
        MeshRenderer myRender;

        //get the rotation values 
        newColor = new Color(transform.rotation.x, transform.rotation.y, transform.rotation.z);

        myRender = GetComponent<MeshRenderer>();

        //allows the object to change color
        myRender.material.color = newColor;

    }

}
