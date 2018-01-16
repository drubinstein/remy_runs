using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_right_hooman : MonoBehaviour {

    // Use this for initialization
    private bool collide_with_doggo = false;
    private bool collide_with_floor = true;
    private Vector3 sprite_size;
    public float hooman_speed = 5f;
    public float hooman_jump = 20f;
    public float camera_shake_x = 3f;
    public float camera_shake_y = 3f;
    public Camera MainCamera;

    void Start () {
        this.GetComponent<Rigidbody2D>().gravityScale = 1f;
        sprite_size= transform.localScale;
    }
    // Update is called once per frame
    void Update () {
        if (!collide_with_doggo)
        {
            var isMoving = move_hooman();
            if (isMoving)
                shake_camera();
        }
    }

    void OnCollisionEnter2D(Collision2D coll) {
        if (coll.gameObject.tag == "doggo") 
            collide_with_doggo = true;
        if (coll.gameObject.tag == "floor")
            collide_with_floor = true;
    }

    bool move_hooman()
    {
        var isRight = Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D);
        var isLeft = Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A);
        var isUp = (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W));
        var isDown = Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S);
        // Left/Right movements
        if (isRight)
            this.transform.Translate(new Vector3(hooman_speed * Time.deltaTime, 0, 0));
        if (isLeft)
            this.transform.Translate(new Vector3(-hooman_speed * Time.deltaTime, 0, 0));
        // Up movements
        if (collide_with_floor && isUp)
        {
            this.GetComponent<Rigidbody2D>().velocity = this.GetComponent<Rigidbody2D>().velocity + Vector2.up * hooman_jump;
            collide_with_floor = false;
        }
        if (this.GetComponent<Rigidbody2D>().velocity.y > 0f)
            this.GetComponent<Rigidbody2D>().velocity = this.GetComponent<Rigidbody2D>().velocity + Vector2.down * .5f;
        // Down movements
        if (isDown && transform.localScale.y > sprite_size.y * 3 / 4)
            transform.position = transform.position - new Vector3(0, sprite_size.y / 4, 0);
        var height = isDown ? sprite_size.y / 2 : sprite_size.y;
        transform.localScale = new Vector3(sprite_size.x, height, sprite_size.z);

        return isRight || isLeft;
    }
    void shake_camera()
    {
        var cameraShakeX = Random.Range(-camera_shake_x, camera_shake_x) * Time.deltaTime;
        var cameraShakeY = Random.Range(-camera_shake_y, camera_shake_y) * Time.deltaTime;
        MainCamera.transform.Translate(new Vector3(cameraShakeX, cameraShakeY, 0));
    }
}
