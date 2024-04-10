using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class QuestManager : MonoBehaviour
{

    public static QuestManager inst = null;

    Multimap<int, QuestData> QuestDic = new Multimap<int, QuestData>();

    public void QuestList()
    {

        //����Ʈ Ű��, ����Ʈ ����
        // NPC�� ������ ID���� ���� �´�.
        QuestDic.AddData(0, new QuestData(0,0,"", null));

        // 1 ����
        QuestDic.AddData(1, new QuestData(1,0,"base","���� ��ǰ�� ���ٳ�")); // �⺻ ����
        QuestDic.AddData(1, new QuestData(1,1,"����",50 , "���� �ű� ! ��� �������� �ͺ��Գ�"));
        QuestDic.AddData(1, new QuestData(1,2,"������ ��Ź 1", 100,
            "�䳢��⸦ ��ǰ�ؾ��ϴµ� �� �����ְԳ�. ���ʽ��� ���� �䳢��� 5���� ���ش� �ָ� �ȴٳ�.", "Rabbit", 5));

        QuestDic.AddData(1, new QuestData(1,3,"������ ��Ź 2",120,
            "������ ! �������� �ڳ� ��ɲ��̾����� ! ���ʿ� ȣ���̰� �������ٰ� �ϴµ� ȣ���̵� �� ����ְڳ�?", "Tiger",2));

        QuestDic.AddData(1, new QuestData(1,4,"������ ��Ź 3", 200,
            "���� �س��� �˾ҳ� ! ȣ���̰� �������ɺ��� ���ʽ��� �������� �ִ°� ����. ���� ���� �����ִ� ū ���� ��ó�� �������ְԳ�","Golem", 1));
        QuestDic.AddData(1, new QuestData(1,5, "������ ��Ź ��", 200,
            "���� ���� �׷� ���� �߻��ϴٴ�.. ū���̱���..",null,0));

        // ���� ��
        // 2. ��������
        QuestDic.AddData(2, new QuestData(2,0,"base",  "���忡 �������� ����ϰ� �Ծ�� �Ѵٳ�" ));
        QuestDic.AddData(2, new QuestData(2,1,"�������� ���ȸ�_1", "�� ������� �� ��⸦ ���߳���������� ���ʽ��� �����ϴ� ���̾�."));
        QuestDic.AddData(2, new QuestData(2,2,"�������� ���ȸ�_2",
            "���� ���ʽ��� ȣ���̵��� ��ǰŷ��� ����� ������ ����� ���ٳ�..Ȥ�� �ڳ� ȣ���̵��� ����ټ� �ְڳ�?"));
        QuestDic.AddData(2, new QuestData(2,3,"�������� ���ȸ�_��",
         "��... �̻��� ���� �����ֳ�.. �̰� �������� �ο��ٴ� �Ҹ��ε�..�ڳ׶����� �ƴѰŰ��� ���ʽ��� �������� ���� ����̾� ���� �屺���� �ѹ� �����ڳ�?" ));


        // 3. �屺
        QuestDic.AddData(3, new QuestData(3,0,"base", "�� ! �� !"));
        QuestDic.AddData(3, new QuestData(3,1,"�屺 ����_1","...�׷� ���� �־��� ������..����."));
        QuestDic.AddData(3, new QuestData(3,2,"�屺 ����_2","���� ���� �������ټ� �ְڳ�? �Ʒõ� ���縦 �������ְڳ�"));
        QuestDic.AddData(3, new QuestData(3,3,"�屺 ����_��",
          "�� ���ʿ� �׷��� �����ϴٴ�.. �׷��� ȣ���̵��� �׷��� �����ſ��� �� ���� �׳� �Ѿ ���� �ƴѰŰ��� ���ϲ� �� ����� �������ְ�"));
    }

    public List<QuestData> getQuest(int _ID)
    {
        return QuestDic.GetData(_ID);
    }


    private void Awake()
    {
        if (inst == null)
            inst = this;

        QuestList();
    }
    
}
