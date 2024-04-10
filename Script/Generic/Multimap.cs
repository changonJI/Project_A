using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Multimap<TKey,TValue>
{

    // ��ȯ�� �ӽ� ����
    Dictionary<TKey, List<TValue>> datalist = new Dictionary<TKey, List<TValue>>();


    // Dictionary<key, list<value> �� ����Ʈ �κ��� �� �߰��ϱ�
    public void AddData(TKey key, TValue value) // �ҷ��� �������� �ε��� ���� MobInfo�� �߰��Լ�
    {
        List<TValue> list;; // datalist�� value���� ������ Ÿ���� ���߱����� List<TValue> list�� ������

        if (datalist.TryGetValue(key, out list)) // datalist[i]�� Ű���� �ִٸ�
        {
            datalist[key].Add(value);           // datalist[key]�� MonsterInfo ���� (ex. monster(1)�� Rabbit monsterInfo�� ����)
        }
        else
        {   list = new List<TValue>();           // Ű���� ���ٸ�, ����Ʈ�� ���� ����� List<TValue>���� �߰��Ѵ�.
            list.Add(value);                    
            datalist.Add(key, list);            // ���ο� Ű����, Ű���� �����͸� datalist�� �߰��Ѵ�.

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
