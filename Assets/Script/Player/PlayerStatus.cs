using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public int lv;       // ���x��
    public int exp;        // �o���l
    public int lvUpExp;        // �K�v�o���l

    void Update()
    {
        // �o���l���K�v�o���l����������
        if (exp >= lvUpExp)
        {
            // �K�v�o���l�������_��������悤�ɂ���
            float _lvUpExp = (float)lvUpExp * 1.2f;
            // �K�v�o���l��1.2�{�������̂𐮐��^�ɒ���(�����_�؂�̂�)
            lvUpExp = (int)_lvUpExp;
            // lv��1���Z����
            lv++;
            // exp��0�ɂ���
            exp = 0;
        }
    }
}
