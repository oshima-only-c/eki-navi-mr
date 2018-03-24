using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetTransform : MonoBehaviour {

    private Vector3 objRefGrabPoint = new Vector3(0.1f, 0.0f, 0.0f);
    private Vector3 draggingPosition = new Vector3(0.1f, 0.0f, 0.0f);
    private Transform cameraTransform;

    public Transform HostTransform;
	void Start () {
        HostTransform= this.transform;

        cameraTransform = transform;
	}

    private void Update()
    {
        //HostTransform.position = Vector3.Lerp(HostTransform.position, draggingPosition + cameraTransform.TransformDirection(objRefGrabPoint), 0.2f);

        //Debug.Log(myTransform.transform.position);
    }
 
}
