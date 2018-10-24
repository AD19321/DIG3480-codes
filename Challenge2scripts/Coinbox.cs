using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coinbox : MonoBehaviour
{
    
    public AudioSource coinPick;

    // Use this for initialization
    void Start()
    {

    }
    void Awake()
    {
        coinPick = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (gameObject.CompareTag("box"))
        {

            coinPick.Play();
        }

    }
}
