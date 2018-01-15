using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_right_hooman : MonoBehaviour {

	// Use this for initialization
	private bool collide_with_doggo = false;

	void Start () {
	}

	// Update is called once per frame
	void Update () {
		if( ! collide_with_doggo )
			transform.Translate (new Vector3 (.05f, 0, 0));
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "doggo")
			collide_with_doggo = true;
	}
}
