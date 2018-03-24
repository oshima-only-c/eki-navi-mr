using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class NaviCharacter : MonoBehaviour {

    private List<GameObject> target = null; //ルート用マーカー
    public float speed = 0.3f;             //スピード
    private bool doOnce = true;
    private int index = 0;                  //現在のターゲット
    private bool once = false;
    private MoveTo move1;
    private bool goal = false;
    private NavMeshAgent agent;
    private GameObject Player;
    private Mathf Math;


    // Use this for initialization
    void Start()
    {

        
        move1 = GameObject.Find("Sphere").GetComponent<MoveTo>();
        agent = GetComponent<NavMeshAgent>();
        Player = GameObject.Find("HoloLensCamera");
        Invoke("SetGoal", 5.0f);
    }

    // Update is called once per frame
    void Update()
    {

        //ルートが確定したら
        if ((agent.velocity.y > 0 ? agent.velocity.y : agent.velocity.y * -1) > 0.1f) agent.speed = 1.2f;
        else agent.speed = 1.6f;
        if (goal)
        {

            //targetをセットする時間待ち
            if (!once)
            {
                Invoke("Delayonce", 0.1f);
            }
            else
            {
                if (target.Count >= 1 && NearPlayer())
                {

                    //ターゲットの方に向かう
                    agent.SetDestination(target[index].transform.position);


                    //ターゲットに到達したらリターゲット
                    if (IsArea() && index + 1 < target.Count)
                    {
                        if (doOnce)
                        {
                            //Debug.Log("Area");
                            if(index + 1 == target.Count)
                            {
                                agent.velocity = Vector3.zero;
#pragma warning disable CS0618 // 型またはメンバーが古い形式です
                                agent.Stop();
#pragma warning restore CS0618 // 型またはメンバーが古い形式です
                            }
                            else 
                                index++;
                            doOnce = false;
                            //Look();
                        }
                    }
                    else doOnce = true;
                }
                else
                {
                    agent.velocity = Vector3.zero;
#pragma warning disable CS0618 // 型またはメンバーが古い形式です
                    agent.Stop();
                    agent.Resume();
#pragma warning restore CS0618 // 型またはメンバーが古い形式です
                    //Invoke("ChangePlayer", 3.0f);
                }

            }
        }
    }

    private void Delayonce()
    {
        once = true;
    }

    private void SetGoal()
    {
        goal = true;
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

    //範囲内にプレイヤーがいるか
    private bool NearPlayer()
    {
        double area = 5.0f;

        //各ベクターの距離を取得
        float xVec, yVec, zVec;
        xVec = Mathf.Abs(Player.transform.position.x - this.transform.position.x);
        yVec = Mathf.Abs(Player.transform.position.y - this.transform.position.y);
        zVec = Mathf.Abs(Player.transform.position.z - this.transform.position.z);

        //直線距離を取得
        float Vec;
        Vec = Mathf.Sqrt(Mathf.Pow(xVec, 2) + Mathf.Pow(yVec, 2));
        Vec = Mathf.Sqrt(Mathf.Pow(Vec, 2) + Mathf.Pow(zVec, 2));

        return (Vec < area) ? true : false;
        //return true;
   
    }

    //ルートをセット
    public void SetTargetList(List<GameObject> targetlist)
    {
        target = targetlist;
    }
    

}
