using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour {
    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;
    public float delay;

    private AudioSource source;
	// Use this for initialization
	void Start () {
        source =GetComponent<AudioSource>();
        InvokeRepeating ("Fire", delay, fireRate);
	}
	
	
	void Fire () {
        Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        source.Play();
	}
}
