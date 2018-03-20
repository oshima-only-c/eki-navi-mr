using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetMarker : MonoBehaviour {
    public List<GameObject> MarkerList;
    private bool doOnce = true;
    MoveTo move1;

    // Use this for initialization
    void Start ()
    {
        move1 = GetComponent<MoveTo>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (move1.IsGoal())
        {
            if (doOnce)
            {
                doOnce = false;
                Debug.Log("Goal");
                MarkerList.Add(move1.Goal);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.name);
        if (other.gameObject.tag == "Marker")
        {
            //マーカーリストに追加
            if (other.gameObject != null)
                MarkerList.Add(other.gameObject);
        }
    }

    public List<GameObject> GetTargetList()
    {
        return MarkerList;
    }
    
}
