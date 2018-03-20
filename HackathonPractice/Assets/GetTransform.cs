using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetTransform : MonoBehaviour {

    public Transform myTransform;
	void Start () {
        myTransform = this.transform;
	}
	
    Transform sendTransform()
    {
        return myTransform;
    }
}
