using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Adding this allows us to access members of the UI namespace including Text.
using UnityEngine.UI;

public class AKD_Cannon_Controller : MonoBehaviour {
    public GameObject Base; // to rotate current object around the base
    public float speed;
    private int count;

    private Rigidbody rbd;
    private float timer;
    private int wholetime;

    public Text CollectText;
    public Text endText;

    public CannonShooterController cannon;
	void Start () {
        //Get and store a reference to the Rigidbody2D component so that we can access it.
        rbd = GetComponent<Rigidbody>();

        //Initialize count to zero.
        count = 0;

        //Initialze winText to a blank string since we haven't won yet at beginning.
        endText.text = "";

        CollectText.text = "";
        //Call our SetCountText function which will update the text with the current value for count.
        SetCountText();

    }

    // Update is called once per frame
    void FixedUpdate () {
        OrbitAround();

        if (Input.GetKeyDown(KeyCode.J))
        {
            cannon.isFiring = true;
        }
        else
        {
            cannon.isFiring = false;
        }
        timer = timer + Time.deltaTime;
        if (timer >= 10)
        {
            endText.text = "You Lose! :(";
            StartCoroutine(ByeAfterDelay(2));

        }

    }
    
    void OrbitAround()
    {
        if (Input.GetKey(KeyCode.UpArrow))
            {
            transform.RotateAround(base.transform.position, Vector3.forward, speed * Time.deltaTime);
        }
        else if(Input.GetKey(KeyCode.DownArrow))
            transform.RotateAround(base.transform.position, Vector3.back, speed * Time.deltaTime);
    }
    void OnTriggerEnter(Collider other)
    {
        //Check the provided Collider parameter other to see if it is tagged "POP", if it is...
        if (other.gameObject.CompareTag("POP"))
        {
            other.gameObject.SetActive(false);

            //Add one to the current value of our count variable.
            count = count + 1;

            // add a point to the game
            GameLoader.AddScore(1);

            //Update the currently displayed count by calling the SetCountText function.
            SetCountText();
        }
    }

    void SetCountText()
    {
        
        if (count >= 10)
        {
            //... then set the text property of our winText object to "You win!"
            endText.text = "You win!";
            StartCoroutine(ByeAfterDelay(2));

        }
    }
    IEnumerator ByeAfterDelay(float time)
    {
        yield return new WaitForSeconds(time);

        // Code to execute after the delay
        GameLoader.gameOn = false;
    }
}
