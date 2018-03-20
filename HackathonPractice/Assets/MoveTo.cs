using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveTo : MonoBehaviour
{

    public GameObject Goal;
    private GameObject[] TargetList;
    private Transform target;

    NavMeshAgent agent;

    void Start()
    {
        //マップ上のゴールをすべて取得
        TargetList = GameObject.FindGameObjectsWithTag("Goal");

        //Debug.Log(TargetList.Length);
        int num = Random.Range(0, TargetList.Length);
        //Debug.Log(TargetList[num].name);

        //ターゲットを設定
        Goal = TargetList[num];
        target = TargetList[num].transform;
        agent = GetComponent<NavMeshAgent>();
        //Invoke("Stop", 2.0f);
    }

    void Update()
    {


        agent.SetDestination(target.position);
        if (IsGoal())
        {
            Invoke("DestroyThis", 0.5f);
        }
    }

    private void DestroyThis()
    {
        Destroy(this.gameObject);
    }

    public bool IsGoal()
    {
        bool ReturnValue = true;

        if (!(target.position.x - 3 < transform.position.x && transform.position.x < target.position.x + 3)) ReturnValue = false;
        if (!(target.position.y - 3 < transform.position.y && transform.position.y < target.position.y + 3)) ReturnValue = false;

        return ReturnValue;
    }

}
