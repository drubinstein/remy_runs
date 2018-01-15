using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_right_hooman : MonoBehaviour {

    // Use this for initialization
    private bool collide_with_doggo = false;
    private float hooman_speed = 2.5f;
    public Camera MainCamera;

    void Start () {
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKey(KeyCode.RightArrow))
        {

            // Time.deltaTime = dt (in seconds - since last frame)
            // hooman_speed = 2.5f (meters/second - a jog at about 5.5mph)
            // dt * hooman_speed = distance hooman traveled since the last frame
            
            if (!collide_with_doggo) {

                // Move the hooman :)
                this.transform.Translate(new Vector3(hooman_speed*Time.deltaTime, 0, 0));

                // Let's make the camera shake a bit
                var cameraShakeX = Random.Range(-3.0f, 3.0f)*Time.deltaTime;
                var cameraShakeY = Random.Range(-3.0f, 3.0f)*Time.deltaTime;
                MainCamera.transform.Translate(new Vector3(cameraShakeX, cameraShakeY, 0));

            }


        }
    }

    void OnCollisionEnter2D(Collision2D coll) {
        if (coll.gameObject.tag == "doggo")
            collide_with_doggo = true;
    }
}
