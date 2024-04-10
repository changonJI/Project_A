using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public static ItemManager inst = null;

    // 0 = ���(0 �Ӹ�, 1 ��, 2 �Ź�, 3 ����, 4 ���� ), 1 = �Ҹ�ǰ, 2 = ��Ÿ
    Multimap<int, ItemData> itemDic = new Multimap<int, ItemData>();
    List<string> itemList = new List<string>();
    List<ItemData> returnItemData = new List<ItemData>();


    public List<string> ITEMLIST
    {
        get { return itemList; }
        set { itemList = value; }
    }
    public List<ItemData> RETURNITEMDATA
    {
        get { return returnItemData; }
        set { returnItemData = value; }
    }

    public void ItemList()
    {
        itemDic.AddData(0, new ItemData(0, "0_cap","equipment_cap", "�⺻���� ����",50f,0f,5f));
        itemDic.AddData(0, new ItemData(0, "1_clothes", "equipment_clothes", "�⺻���� ��",100f,0f,10f));
        itemDic.AddData(0, new ItemData(0, "2_shoe", "equipment_shoe", "�⺻���� �Ź�",50f, 0f, 5f));
        itemDic.AddData(0, new ItemData(0, "3_sword", "equipment_sword", "�⺻���� ��",100f ,10f, 10f));
        itemDic.AddData(0, new ItemData(0, "4_shield", "equipment_shield", "�⺻���� ����", 80f ,0f, 5f));

        itemDic.AddData(1, new ItemData(1, "hpPotion", "consumables_smallPotion", "���� ����",10f ,0f, 30f));

        itemDic.AddData(2, new ItemData(2, "rabbitMeat", "etc_rabbitMeat", "�䳢 ���(�� ���̴�.)", 5f, 0f, 0f));

    }

    /*public ItemData getItemInfo(int index, string _name)
    {
        List<ItemData> tmp = new List<ItemData>();
        tmp = itemDic.GetData(index);

        foreach(ItemData one in tmp)
        {
            if (one.itemName.Equals(_name))
            {
                return one;
            }
        }
        return null;
    }*/

    public List<ItemData> getItemInfo(string _name)
    {
        List<ItemData> EquipmentItemDataList = itemDic.GetData(0);
        List<ItemData> consumablesItemDataList = itemDic.GetData(1);
        List<ItemData> EtcItemDataList = itemDic.GetData(2);

        returnItemData = new List<ItemData>();

        switch (_name)
        {
            case "����":
                
                itemList.Add("hpPotion");

                foreach (string one in itemList)                    
                {
                    foreach (ItemData two in consumablesItemDataList)
                    {
                        if (one.Equals(two.itemName))
                        {
                            returnItemData.Add(two);
                        }
                    }
                }

                break;

            case "��������":

                itemList.Add("0_cap");
                itemList.Add("1_clothes");
                itemList.Add("2_shoe");
                itemList.Add("3_sword");
                itemList.Add("4_shiled");

                foreach (string one in itemList)
                {
                    foreach (ItemData two in EquipmentItemDataList)
                    {
                        if (one.Equals(two.itemName))
                        {
                            returnItemData.Add(two);
                        }
                    }
                }

                break;
        }

        return returnItemData;

    }

    private void Awake()
    {
        if (inst == null)
        {
            inst = this;
        }

        ItemList();
    }


}
