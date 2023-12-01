using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public int lv;       // レベル
    public int exp;        // 経験値
    public int lvUpExp;        // 必要経験値

    void Update()
    {
        // 経験値が必要経験値を上回ったら
        if (exp >= lvUpExp)
        {
            // 必要経験値を小数点を扱えるようにして
            float _lvUpExp = (float)lvUpExp * 1.2f;
            // 必要経験値を1.2倍したものを整数型に直す(小数点切り捨て)
            lvUpExp = (int)_lvUpExp;
            // lvに1加算する
            lv++;
            // expを0にする
            exp = 0;
        }
    }
}
