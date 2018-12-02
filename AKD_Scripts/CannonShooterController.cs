using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonShooterController : MonoBehaviour {
    public bool isFiring;

    public Cannon_ballController ball;
    public float cannonSpeed;

    public float timeBetweenShot;
    private float shotCounter;

    public Transform firePoint;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (isFiring)
        {
            shotCounter -= Time.deltaTime;
            if(shotCounter <= 0)
            {
                shotCounter = timeBetweenShot;
               Cannon_ballController newCannon =Instantiate(ball, firePoint.position, firePoint.rotation) as Cannon_ballController;
                newCannon.speed = cannonSpeed;
            }
            else
            {
                shotCounter = 0;
            }
        }
	}
}
