using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bork_sometimes : MonoBehaviour {

    private AudioSource source;
    public AudioClip bork;
    
	// Use this for initialization
	void Start () {
         source = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	    if(Random.Range(1,100) == 50) {
            source.PlayOneShot(bork, 0.7F);
        }
	}
}
