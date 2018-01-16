using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class background : MonoBehaviour {
    private float pane_length;
    private float scroll_speed = 10f;
    // Use this for initialization
    void Start () {
        pane_length = transform.GetChild(0).GetComponent<SpriteRenderer>().bounds.size.x;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            this.transform.Translate(new Vector3(scroll_speed * Time.deltaTime, 0, 0));
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            this.transform.Translate(new Vector3(-scroll_speed * Time.deltaTime, 0, 0));
        foreach (Transform child in transform)
        {
            if (child.transform.position.x >= pane_length*2)
                child.transform.position = child.transform.position - new Vector3(pane_length * 3,0);
            if (child.transform.position.x <= -pane_length * 2)
                child.transform.position = child.transform.position + new Vector3(pane_length * 3, 0);
        }
    }
}
