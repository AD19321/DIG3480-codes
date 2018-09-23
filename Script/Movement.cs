using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    private float originalPosition;
    public float timing;
    public float min;
    public float max;

    public float movement; 

    void Start()
    {
        originalPosition = transform.position.y;

        timing = Random.Range(min,max);
    }

    //randomly moves the obsticals up and down
    void Update()
    {
        transform.position = new Vector3(transform.position.x,
        originalPosition - ((float)Mathf.Sin(Time.time*timing) * movement),
            transform.position.z);
    }

}
