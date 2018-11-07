using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}
public class PlayerController : MonoBehaviour {
    private Rigidbody rgb;
    public float speed;
    public float tilt;
    public Boundary boundary;

    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;

    private float nextFire;
    public AudioSource weaponSound;
    
    private void Start()
    {
        rgb = GetComponent<Rigidbody>();
        weaponSound = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            weaponSound.Play();
        }
    }
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rgb.velocity = movement*speed;

        rgb.position = new Vector3
            (
                Mathf.Clamp(rgb.position.x,boundary.xMin,boundary.xMax),
                0.0f,
                Mathf.Clamp(rgb.position.z,boundary.zMin,boundary.zMax)

            );
        rgb.rotation = Quaternion.Euler(0.0f, 0.0f, rgb.velocity.x*-tilt);
    }
}
