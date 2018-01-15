using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_right_hooman : MonoBehaviour {

    // Use this for initialization
    private bool collide_with_doggo = false;
    private bool collide_with_floor = true;
    public float hooman_speed = 2.5f;
    public float camera_shake_x = 3f;
    public float camera_shake_y = 3f;
    public Camera MainCamera;

    void Start () {
    }
    // Update is called once per frame
    void Update () {

        if (!collide_with_doggo){
            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)){
            // Time.deltaTime = dt (in seconds - since last frame)
            // hooman_speed = 2.5f (meters/second - a jog at about 5.5mph)
            // dt * hooman_speed = distance hooman traveled since the last frame
                // Move the hooman :)
                this.transform.Translate(new Vector3(hooman_speed*Time.deltaTime, 0, 0));

                // Let's make the camera shake a bit
                var cameraShakeX = Random.Range(-camera_shake_x, camera_shake_x) * Time.deltaTime;
                var cameraShakeY = Random.Range(-camera_shake_y, camera_shake_y) * Time.deltaTime;
                MainCamera.transform.Translate(new Vector3(cameraShakeX, cameraShakeY, 0));
            }
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            {
                // Time.deltaTime = dt (in seconds - since last frame)
                // hooman_speed = 2.5f (meters/second - a jog at about 5.5mph)
                // dt * hooman_speed = distance hooman traveled since the last frame
                // Move the hooman :)
                this.transform.Translate(new Vector3(-hooman_speed * Time.deltaTime, 0, 0));
            }
                if (this.GetComponent<Rigidbody2D>().gravityScale == 0f && (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)))
            {
                this.GetComponent<Rigidbody2D>().gravityScale = 1f;
                this.GetComponent<Rigidbody2D>().velocity = this.GetComponent<Rigidbody2D>().velocity + Vector2.up * 20;
            }
            if (this.GetComponent<Rigidbody2D>().velocity.y > 0f)
            {
                this.GetComponent<Rigidbody2D>().velocity = this.GetComponent<Rigidbody2D>().velocity + Vector2.down * .5f;
            }

        }
    }

    void OnCollisionEnter2D(Collision2D coll) {

        if (coll.gameObject.tag == "doggo") 
            collide_with_doggo = true;
        if (coll.gameObject.tag == "floor")
        {
            this.GetComponent<Rigidbody2D>().gravityScale = 0f;
        }
    }
}
