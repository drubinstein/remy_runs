using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_right_doggo : MonoBehaviour {

	// Use this for initialization
	private bool collide_with_hooman = false;

	void Start () {
	}

	// Update is called once per frame
	void Update () {
		if( ! collide_with_hooman )
			transform.Translate (new Vector3 (.15f, 0, 0));
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "hooman")
			collide_with_hooman = true;
	}
}
