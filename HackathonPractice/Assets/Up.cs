using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Up : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //上
        if (Input.GetKey("up"))     transform.position += transform.up * 0.01f;
        if (Input.GetKey("down"))   transform.position += transform.up * -0.01f;
        if (Input.GetKey("right"))  transform.position += transform.right * 0.01f;
        if (Input.GetKey("left"))   transform.position += transform.right * -0.01f;
	}

    
}
