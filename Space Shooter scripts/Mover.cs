using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {
    private Rigidbody rgb;
    public float speed;

    void Start()
    {
        rgb = GetComponent<Rigidbody>();
        rgb.velocity = transform.forward *speed;
    }
}
