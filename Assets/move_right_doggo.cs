using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_right_doggo : MonoBehaviour {

    private bool collide_with_hooman = false;
    private float doggo_speed = 2.3f; 

    // Use this for initialization
    void Start () {
    }

    // Update is called once per frame
    void Update () {

        // Time.deltaTime = dt (in seconds - since last frame)
        // doggo_speed = 2.3f (meters/second - slightly slower than the hooman!)
        // dt * doggo_speed = distance doggo travelled since last frame
        
        if( ! collide_with_hooman )
            transform.Translate (new Vector3 (doggo_speed*Time.deltaTime, 0, 0));


    }

    void OnCollisionEnter2D(Collision2D coll) {
        if (coll.gameObject.tag == "hooman")
            collide_with_hooman = true;
    }
}
