using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRendererScript : MonoBehaviour {
    public GameObject Sphere;
    public List<GameObject> Route;
    private LineRenderer LineY;
    private int x;

    void Start ()
    {
        Sphere = GameObject.Find("Sphere");
        Route = Sphere.GetComponent<GetMarker>().MarkerList;
        LineY = GameObject.Find("LineRendererObject").GetComponent<LineRenderer>();
        LineY.SetPosition(0, Sphere.transform.position);
    }

    // Update is called once per frame
    void Update () {
        x = Route.Count + 1;

#pragma warning disable CS0618 // 型またはメンバーが古い形式です
        LineY.SetVertexCount(count: Route.Count + 1);
        LineY.SetVertexCount(count: x);
#pragma warning restore CS0618 // 型またはメンバーが古い形式です

        for (int i = 0; i < Route.Count; i++)
        {
            LineY.SetPosition(i + 1, Route[i].transform.position + new Vector3(0f,0.3f,0f));
        }
	}
}
