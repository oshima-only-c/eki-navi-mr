using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NaviCharacter : MonoBehaviour {

    private List<GameObject> target = null; //ルート用マーカー
    public float speed = 0.3f;             //スピード
    private bool doOnce = true;
    private GameObject Player;
    private int index = 0;                  //現在のターゲット
    private bool once = false;
    private MoveTo move1;
    private bool goal = false;
    private NavMeshAgent agent;
    

    // Use this for initialization
    void Start()
    {
        Player = GameObject.Find("Player");
        move1 = GameObject.Find("Sphere").GetComponent<MoveTo>();
        agent = GetComponent<NavMeshAgent>();
        

    }

    // Update is called once per frame
    void Update()
    {
        agent.speed = 2.5f + agent.velocity.y * 10 * 10.0f;
        //ルートが確定したら
        if (move1.IsGoal()) goal = true;
        if (goal)
        {

            //targetをセットする時間待ち
            if (!once)
            {
                Invoke("Delayonce", 0.1f);
            }
            else
            {

                //    //ターゲットの方を常に向く
                //    Look();

                //    //前に進む
                //    this.transform.position += transform.forward * speed;

                //    //ターゲットに到達したらリターゲット
                agent.SetDestination(target[index].transform.position);
                if (IsArea() && index + 1 < target.Count)
                {
                    if (doOnce)
                    {
                        //Debug.Log("Area");
                        index++;
                        doOnce = false;
                        //Look();
                    }
                }
                else doOnce = true;

            }
        }
    }

    private void Delayonce()
    {
        Look();
        once = true;
    }

    private void Look()
    {
        //this.transform.LookAt(target[index].transform);
    }

    //範囲に入ったかどうか確認する関数
    private bool IsArea()
    {
        double area = 1.0f;     // 範囲の半径
        bool xin = true;
        bool zin = true;

        //x方向の範囲内か確認
        if (target[index].transform.position.x - area <= this.transform.position.x && this.transform.position.x <= target[index].transform.position.x + area)
        {
            xin = true;
        }
        else xin = false;

        //z方向の範囲内か確認
        if (target[index].transform.position.z - area <= this.transform.position.z && this.transform.position.z <= target[index].transform.position.z + area)
        {
            zin = true;
        }
        else zin = false;

        //xz共に範囲内ならtrue
        if (xin && zin) return true;
        else            return false;
    }

    //ルートをセット
    public void SetTargetList(List<GameObject> targetlist)
    {
        target = targetlist;
    }

}
