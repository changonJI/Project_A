using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemData : SingleTon<ItemData>
{
    // Index : 아이템 분류(장비(장비는 이름으로 분류하기) 0 , 소모품, 기타)
    // 아이템 이름, 설명
    // 무기 : power 증가 / 방어구 : Hp 증가 / 소모품 : Hp 회복 / 기타 : 퀘스트용 아이템 

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
