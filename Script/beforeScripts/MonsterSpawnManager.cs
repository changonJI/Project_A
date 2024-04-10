using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawnManager : MonoBehaviour
{

    /*******************************변수*********************************/
    public static MonsterSpawnManager inst = null;
    
    
    public Transform [] spawn;
    public string [] mobname;

    public Transform bossSpawn;
    public string fieldboss;

    public int mobcount;
    
    float monsterRespawn = 0f;
    float bossRespawn = 0f;
    Vector3 pos = Vector3.zero;

    Vector2 angle = Vector3.zero;


    /******************************************************************/


    /********************************함수********************************/

    /* monster */
    public void CreateMonster(string name, Transform spawn)
    {

        GameObject GetEnableMonster()
        {
            foreach (Monster one in GameManager.Inst.MONSTER)
            {
                if (one.gameObject.activeSelf == false)
                {
                    one.MONSTERHP = one.MONSTERMAXHP;
                    return one.gameObject;
                }

            }
            return null;
            
        }

        GameObject enableMonster = GetEnableMonster();

        if (enableMonster == null)
        {
            
            GameObject tmp = LoadManager.Instant.LoadMonsterNameCheck(name);
            enableMonster = Instantiate<GameObject>(tmp);
            enableMonster.transform.SetParent(spawn);

            //pos = enableMonster.transform.position;
            pos = new Vector3(Random.Range(-3,3), 0, Random.Range(-3, 3));

            angle = enableMonster.transform.eulerAngles;
            angle = new Vector2(0, Random.Range(0, 360));

            enableMonster.transform.localPosition = pos;
            enableMonster.transform.eulerAngles = angle;

            enableMonster.name = name;

            Monster monster = enableMonster.AddComponent<Monster>();

            GameManager.Inst.MONSTER.Add(monster);
            
        }

        enableMonster.SetActive(true);

        pos = new Vector3(Random.Range(-3, 3), 0, Random.Range(-3, 3));
        enableMonster.transform.localPosition = pos;
    }

    public int CountMonster()
    {
        int count = 0;
        foreach (Monster one in GameManager.Inst.MONSTER)
        {
            if (one.gameObject.activeSelf == true)
                count++;
        }
        
        return count;
    }



    /* Bossmonster */
    public void CreateBossMonster(string name, Transform spawn)
    {

        GameObject GetEnableMonster()
        {
            foreach (Monster one in GameManager.Inst.BOSSMONSTER)
            {
                if (one.gameObject.activeSelf == false)
                {
                    one.MONSTERHP = one.MONSTERMAXHP;
                    return one.gameObject;
                }

            }
            return null;

        }

        GameObject enableMonster = GetEnableMonster();

        if (enableMonster == null)
        {

            GameObject tmp = LoadManager.Instant.LoadMonsterNameCheck(name);
            enableMonster = Instantiate<GameObject>(tmp);
            enableMonster.transform.SetParent(spawn);

            angle = enableMonster.transform.eulerAngles;
            angle = spawn.eulerAngles;

            enableMonster.transform.localPosition = Vector3.zero;
            enableMonster.transform.eulerAngles = angle;

            enableMonster.name = name;

            Monster monster = enableMonster.AddComponent<Monster>();

            GameManager.Inst.BOSSMONSTER.Add(monster);

        }

        enableMonster.SetActive(true);
        enableMonster.transform.localPosition = Vector3.zero;
        enableMonster.transform.eulerAngles = angle;

    }


    public int CountBossMonster()
    {
        int count = 0;
        foreach(Monster one in GameManager.Inst.BOSSMONSTER)
        {
            if(one.gameObject.activeSelf == true)
            {
                count++;
            }
        }
        return count;
    }



    /******************************************************************/
    void Awake()
    {
        if (inst == null)
            inst = this;

        
        LoadManager.Instant.LoadMonster();
        
      
    }

    void Update()
    {

        if (fieldboss != string.Empty)
        {
            if (CountBossMonster() > 0)
                bossRespawn = 0f;
            else
            {
                bossRespawn += Time.deltaTime;
                if (bossRespawn >= 5f)
                {
                    CreateBossMonster(fieldboss, bossSpawn);
                    bossRespawn -= 5f;
                }
            }
        }
        
        
        // countMonster = 오브젝트의 setActive가 true인 객체수 반환
        if (CountMonster() >= mobcount)
            monsterRespawn = 0f;
        else
        {
            //CreateMonster(mobname[Random.Range(0,mobname.Length)],spawn[Random.Range(0, spawn.Length)]);

            monsterRespawn += Time.deltaTime;
            if (monsterRespawn >= 3f)
            {
                // 몬스터 랜덤 소환
                /*foreach(string _name in mobname)
                {
                    foreach (Transform _spawn in spawn) 
                    {
                        if (_name.Equals(_spawn.name))
                        {
                            CreateMonster(_name, _spawn);
                        }
                    }
                }
                */
                CreateMonster(mobname[Random.Range(0, mobname.Length)], spawn[Random.Range(0, spawn.Length)]);

                monsterRespawn -= 2f;
            }
        }


      
    }




}
        
