using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float speed = 10.0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        

		if (Input.GetKey("up"))
        {
            transform.position += transform.forward * speed * Time.deltaTime;
        }

        if (Input.GetKey("left"))
        {
            transform.Rotate(new Vector3(0, -1, 0));
        }
        else if (Input.GetKey("right"))
        {
            transform.Rotate(new Vector3(0, 1, 0));
        }

        if (Input.GetKey("down"))
        {
            speed = 10.0f * 2;
        }
        else
        {
            speed = 10.0f;
        }
	}
}
