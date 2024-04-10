using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMonsterSpawn : MonoBehaviour
{
    // �����̸�, ��ȯ ��ġ �ܺο��� ����
    public Transform spawn;
    public string monsterName;

    // ���� index ��
    //int monsterIndex = 0;

    // ���� ��ȯ�� �ܺο��� ����
    public int maxMonsterCount;
    //int monsterCount = 0;

    // ���� ������ �ð�
    public float monsterMaxRespawnTime;
    float monsterRespawnTime;


    public void CreateMonster(string _name, Transform _spawn)
    {
        GameObject getEnableMonster()
        {
            foreach (Monster one in GameManager.Inst.MONSTER)
            {
                if (one.name.Equals(_name) &&
                   one.gameObject.activeSelf.Equals(false))
                {
                    one.MONSTERHP = one.MONSTERMAXHP;
                    one.MONSTERATTACKPOINT = 0;
                    return one.gameObject;
                }
            }

            return null;
        }

        GameObject monsterObjectPooling = getEnableMonster();

        if (monsterObjectPooling == null)
        {
            // ���ҽ� �ҷ��ͼ� ��ȯ
            monsterObjectPooling = Instantiate<GameObject>(LoadManager.Instant.LoadMonsterNameCheck(_name));
            // �θ�ü ����
            monsterObjectPooling.transform.SetParent(_spawn);

            // ���� �̸�, ��ġ, ȸ���� ����
            monsterObjectPooling.name = _name;   // + "_" + (monsterIndex + 1).ToString();
            monsterObjectPooling.transform.localPosition = Vector3.zero;
            //monsterObjectPooling.transform.eulerAngles;

            // ��ũ��Ʈ �߰��� ��ũ��Ʈ �������� ����
            Monster mobscript = monsterObjectPooling.AddComponent<Monster>();
            GameManager.Inst.MONSTER.Add(mobscript);

            // ++monsterCount;
        }

        monsterObjectPooling.SetActive(true);
    }

    public int countMonster()
    {
        int count = 0;

        foreach (Monster one in GameManager.Inst.MONSTER)
        {
            if (one.name.Equals(monsterName) &&
               one.gameObject.activeSelf.Equals(true))
            {
                count++;
            }
        }

        return count;
    }

    void Update()
    {

        // ���� ���� �ƽ������� ũ�ٸ� 0���� �ʱ�ȭ, �������ð� 0���� �ʱ�ȭ
        if (countMonster() >= maxMonsterCount)
        {
            monsterRespawnTime = 0;
        }
        else
        {
            monsterRespawnTime += Time.deltaTime;

            if (monsterRespawnTime >= monsterMaxRespawnTime)
            {
                CreateMonster(monsterName, spawn);
                monsterRespawnTime -= monsterMaxRespawnTime;
            }
        }


    }
}
