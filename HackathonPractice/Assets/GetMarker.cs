using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetMarker : MonoBehaviour {
    public List<GameObject> MarkerList;
    private bool doOnce = true;
    MoveTo move1;
    NaviCharacter Navi;

    // Use this for initialization
    void Start ()
    {
        Navi = GameObject.Find("Navi").GetComponent<NaviCharacter>();
        move1 = GetComponent<MoveTo>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        Navi.SetTargetList(MarkerList);
        if (move1.IsGoal())
        {
            if (doOnce)
            {
                doOnce = false;
                Debug.Log("Goal");
                MarkerList.Add(move1.Goal);
                //Navi.SetTargetList(MarkerList);
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Marker")
        {
            if (MarkerList.Count <= 1 || (MarkerList[MarkerList.Count - 1] != other.gameObject && MarkerList[MarkerList.Count - 2] != other.gameObject))
            {
                //マーカーリストに追加
                if (other.gameObject != null)
                {
                    MarkerList.Add(other.gameObject);
#pragma warning disable CS0618 // 型またはメンバーが古い形式です
                    move1.agent.velocity = Vector3.zero;
                    move1.agent.Stop();
                    if (!move1.IsGoal())
                    {
                        move1.agent.Resume();
                    }
#pragma warning restore CS0618 // 型またはメンバーが古い形式です
                }
            }
        }
    }
    
}
