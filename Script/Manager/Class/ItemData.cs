using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemData : SingleTon<ItemData>
{
    // Index : ������ �з�(���(���� �̸����� �з��ϱ�) 0 , �Ҹ�ǰ, ��Ÿ)
    // ������ �̸�, ����
    // ���� : power ���� / �� : Hp ���� / �Ҹ�ǰ : Hp ȸ�� / ��Ÿ : ����Ʈ�� ������ 

    public Image itemImage;
    public int index = 0;
    public string itemName;
    public string itemRsName;
    public string itemInfo;
    public float itemPrice;
    public float itemPower = 0f;
    public float itemHp = 0f;


    public ItemData()
    {

    }

    public ItemData(int _index, string _Name,string _rsName, string _info,float _Price, float _power, float _hp)
    {
        index = _index;
        itemName = _Name;
        itemRsName = _rsName;
        itemInfo = _info;
        itemPrice = _Price;
        itemPower = _power;
        itemHp = _hp;
    }
}
