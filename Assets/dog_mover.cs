using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dog_mover : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	   //var dt = Time.deltaTime;
	   //var translation = new Vector3(0, 0 ,dt*1.5f);
	   //this.transform.Translate(translation);
	   
	   var st = (float)(System.Math.Sin(Time.fixedTime));
   	   var ct = (float)(System.Math.Cos(Time.fixedTime));
	   
	   this.transform.rotation = Quaternion.Euler(0, (st*180)+180, (ct*180)+180);
	   
       this.transform.position = new Vector3(st*10, ct*5, 0);
	   
	   
	}
}

