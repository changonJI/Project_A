using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMonsterSpawn : MonoBehaviour
{
    // 몬스터이름, 소환 위치 외부에서 지정
    public Transform spawn;
    public string monsterName;

    // 몬스터 index 값
    //int monsterIndex = 0;

    // 몬스터 소환수 외부에서 지정
    public int maxMonsterCount;
    //int monsterCount = 0;

    // 몬스터 리스폰 시간
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
            // 리소스 불러와서 소환
            monsterObjectPooling = Instantiate<GameObject>(LoadManager.Instant.LoadMonsterNameCheck(_name));
            // 부모객체 지정
            monsterObjectPooling.transform.SetParent(_spawn);

            // 몬스터 이름, 위치, 회전값 적용
            monsterObjectPooling.name = _name;   // + "_" + (monsterIndex + 1).ToString();
            monsterObjectPooling.transform.localPosition = Vector3.zero;
            //monsterObjectPooling.transform.eulerAngles;

            // 스크립트 추가후 스크립트 형식으로 저장
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

        // 몬스터 수가 맥스값보다 크다면 0으로 초기화, 리스폰시간 0으로 초기화
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
