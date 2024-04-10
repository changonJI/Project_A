using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Multimap<TKey,TValue>
{

    // 반환값 임시 변수
    Dictionary<TKey, List<TValue>> datalist = new Dictionary<TKey, List<TValue>>();


    // Dictionary<key, list<value> 의 리스트 부분의 값 추가하기
    public void AddData(TKey key, TValue value) // 불러온 데이터의 인덱스 값과 MobInfo값 추가함수
    {
        List<TValue> list;; // datalist의 value값의 데이터 타입을 맞추기위해 List<TValue> list를 생성함

        if (datalist.TryGetValue(key, out list)) // datalist[i]의 키값이 있다면
        {
            datalist[key].Add(value);           // datalist[key]에 MonsterInfo 저장 (ex. monster(1)에 Rabbit monsterInfo값 저장)
        }
        else
        {   list = new List<TValue>();           // 키값이 없다면, 리스트를 새로 만들어 List<TValue>값을 추가한다.
            list.Add(value);                    
            datalist.Add(key, list);            // 새로운 키값과, 키값의 데이터를 datalist에 추가한다.

        }
    }

    public List<TValue> GetData(TKey key)
    {
        List<TValue> list = new List<TValue>();
        if(datalist.TryGetValue(key, out list))
        {
            return list;
        }
        else
        {
            return null;
        }
    }
    
}
