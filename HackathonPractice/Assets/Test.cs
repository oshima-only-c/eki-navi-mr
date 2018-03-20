using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

    public GameObject target;
    public List<GameObject> targetList;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.LookAt(target.transform);
        this.transform.Translate(transform.forward);
        if (IsArea())
        {
            Debug.Log("Goal");
        }
    }

    
    //範囲に入ったかどうか確認する関数
    private bool IsArea()
    {
        float area = 3.0f;       // 範囲の半径、適当に決めたから要調整
        bool retvalue = true;   //戻り値、boolはtrueかfalseの二択しか入らん変数の型

        //自分がターゲットの範囲（x）に入ってなかったらretvalueをfalseにする
        if (!(target.transform.position.x - area <= this.transform.position.x && this.transform.position.x <= target.transform.position.x)) retvalue = false;

        //自分がターゲットの範囲（y）に入ってなかったらretvalueをfalseにする
        if (!(target.transform.position.y - area <= this.transform.position.y && this.transform.position.y <= target.transform.position.y)) retvalue = false;

        //boolで真偽を返す
        //範囲内ならtrue, 範囲外ならfalse
        return retvalue;
    }

}
