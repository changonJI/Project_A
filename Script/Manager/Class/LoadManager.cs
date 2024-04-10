using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;



public class LoadManager : SingleTon<LoadManager>
{

    /*******************************변수*******************************/

    private GameObject rsPlayer;
    public GameObject rsPLAYER
    {
        get { return rsPlayer; }
    }


    private List<GameObject> rsMonster = new List<GameObject>();

    public List<GameObject> rsMONSTER
    {
        get { return rsMonster; }
    }

    /******************************************************************/




    /*******************************함수*******************************/

    


    public List<MonsterInfo> LoadMonsterData()
    {

        // 1. 파일 읽음
        using (StreamReader sr = new StreamReader(Application.dataPath + "/" + "MonsterData.csv"))
        {

            // 2. 첫줄 (상태값) 읽음
            sr.ReadLine();

            // 3. 읽어온 값 멀티맵
            //Multimap<Index, MonsterInfo> monsterdic = new Multimap<Index, MonsterInfo>();
            List<MonsterInfo> monsterinfo = new List<MonsterInfo>();


            string datas = string.Empty;

            while ((datas = sr.ReadLine()) != null)
            {

                string[] datalist = datas.Split(',');

                // 3-1. 몬스터 정보 저장
                MonsterInfo monsterdata = new MonsterInfo();

                // 1.name 2.level 3.autoAttack 4.maxhp 5.hp 6.power 7.exp
                monsterdata.name = datalist[1];
                monsterdata.level = int.Parse(datalist[2]);
                monsterdata.autoattack = int.Parse(datalist[3]);
                monsterdata.maxhp = int.Parse(datalist[4]);
                monsterdata.hp = int.Parse(datalist[5]);
                monsterdata.power = short.Parse(datalist[6]);
                monsterdata.exp = int.Parse(datalist[7]);


                monsterinfo.Add(monsterdata);
                
                datas = string.Empty;
            }

            //List<MonsterInfo> monsterlist = monsterdic.GetData(Index.Monster);

            return monsterinfo;

            sr.Close();
        }

        
    }
    public PlayerInfo LoadPlayerData()
    {

        using (StreamReader sr = new StreamReader(Application.dataPath + "/" + "PlayerData.csv"))
        {
            string data = string.Empty;
            sr.ReadLine();

            PlayerInfo playerInfo = new PlayerInfo();

            while ((data = sr.ReadLine()) != null)
            {

                //name,level,hp,maxHp,power,exp,scene,posx,posy,posz,rotx,roty,rotz,scalex,scaley,scalez

                string[] stringData = data.Split(',');

                playerInfo.name = stringData[0];

                playerInfo.level = byte.Parse(stringData[1]);
                playerInfo.hp = float.Parse(stringData[2]);
                playerInfo.maxHp = float.Parse(stringData[3]);
                playerInfo.power = float.Parse(stringData[4]);
                playerInfo.exp = float.Parse(stringData[5]);
                playerInfo.money = int.Parse(stringData[6]);

                playerInfo.scene = stringData[7];

                playerInfo.posx = float.Parse(stringData[8]);
                playerInfo.posy = float.Parse(stringData[9]);
                playerInfo.posz = float.Parse(stringData[10]);

                playerInfo.rotx = float.Parse(stringData[11]);
                playerInfo.roty = float.Parse(stringData[12]);
                playerInfo.rotz = float.Parse(stringData[13]);

                playerInfo.scalex = float.Parse(stringData[14]);
                playerInfo.scaley = float.Parse(stringData[15]);
                playerInfo.scalez = float.Parse(stringData[16]);

                playerInfo.equipHead = int.Parse(stringData[17]);
                playerInfo.equipBody = int.Parse(stringData[18]);
                playerInfo.equipFoot = int.Parse(stringData[19]);
                playerInfo.equipWeapon = int.Parse(stringData[20]);
                playerInfo.equipShield = int.Parse(stringData[21]);

                data = string.Empty;

                
            }

            return playerInfo;
            sr.Close();
        }

    }
    public List<ItemData> LoadPlayerInvenData()
    {

        using (StreamReader sr = new StreamReader(Application.dataPath + "/" + "PlayerInvenData.csv"))
        {
            string data = string.Empty;
            sr.ReadLine();

            List<ItemData> playerInvenDataList = new List<ItemData>();

            while ((data = sr.ReadLine()) != null)
            {

                ItemData playerInvenData = new ItemData();

                string[] stringData = data.Split(',');

                playerInvenData.index = int.Parse(stringData[0]);
                playerInvenData.itemName = stringData[1];
                playerInvenData.itemRsName = stringData[2];
                playerInvenData.itemInfo = stringData[3];
                playerInvenData.itemPrice = float.Parse(stringData[4]);
                playerInvenData.itemPower = float.Parse(stringData[5]);
                playerInvenData.itemHp = float.Parse(stringData[6]);


                playerInvenDataList.Add(playerInvenData);
                data = string.Empty;
            }

            return playerInvenDataList;
            sr.Close();
        }

    }

    public List<ItemData> LoadPlayerEquipmentData()
    {

        using (StreamReader sr = new StreamReader(Application.dataPath + "/" + "PlayerEquipData.csv"))
        {
            string data = string.Empty;
            sr.ReadLine();

            List<ItemData> playerEquipDataList = new List<ItemData>();

            while ((data = sr.ReadLine()) != null)
            {

                ItemData playerEquipData = new ItemData();

                string[] stringData = data.Split(',');

                playerEquipData.index = int.Parse(stringData[0]);
                playerEquipData.itemName = stringData[1];
                playerEquipData.itemRsName = stringData[2];
                playerEquipData.itemInfo = stringData[3];
                playerEquipData.itemPrice = float.Parse(stringData[4]);
                playerEquipData.itemPower = float.Parse(stringData[5]);
                playerEquipData.itemHp = float.Parse(stringData[6]);


                playerEquipDataList.Add(playerEquipData);
                data = string.Empty;
            }

            return playerEquipDataList;
            sr.Close();
        }

    }
    public List<BuildingInfo> LoadBuildingData()
    {

        using (StreamReader sr = new StreamReader(Application.dataPath + "/" + "BuildingData.csv"))
        {

            sr.ReadLine();

            string data = string.Empty;

            List<BuildingInfo> buildinginfo = new List<BuildingInfo>();

            while ((data = sr.ReadLine()) != null)
            {
                //Debug.Log("데이터 로드 성공 = " + data);

                BuildingInfo buildingdata = new BuildingInfo();

                string[] datalist = data.Split(',');

                buildingdata.index = int.Parse(datalist[0]);

                buildingdata.sceneName = datalist[1];

                buildingdata.tagName = datalist[2];

                buildingdata.rsName = datalist[3];

                buildingdata.posx = float.Parse(datalist[4]);
                buildingdata.posy = float.Parse(datalist[5]);
                buildingdata.posz = float.Parse(datalist[6]);

                buildingdata.rotx = float.Parse(datalist[7]);
                buildingdata.roty = float.Parse(datalist[8]);
                buildingdata.rotz = float.Parse(datalist[9]);

                buildingdata.scalex = float.Parse(datalist[10]);
                buildingdata.scaley = float.Parse(datalist[11]);
                buildingdata.scalez = float.Parse(datalist[12]);

                buildinginfo.Add(buildingdata);
                data = string.Empty;
            }

            return buildinginfo;
            sr.Close();

        }
    }

    public List<NpcInfo> LoadNpcData()
    {

        using (StreamReader sr = new StreamReader(Application.dataPath + "/" + "NPCData.csv"))
        {

            sr.ReadLine();
            string data = string.Empty;

            List<NpcInfo> NpcInfodata = new List<NpcInfo>();

            while((data = sr.ReadLine()) != null)
            {

               // Debug.Log(data);

                NpcInfo npcdata = new NpcInfo();

                string [] datas = data.Split(',');

                npcdata.ID = int.Parse(datas[0]);
                npcdata.name = datas[1];
                npcdata.tagname = datas[2];
                npcdata.rsName = datas[3];
                npcdata.sceneName = datas[4];

                npcdata.posx = float.Parse(datas[5]);
                npcdata.posy = float.Parse(datas[6]);
                npcdata.posz = float.Parse(datas[7]);

                npcdata.rotx = float.Parse(datas[8]);
                npcdata.roty = float.Parse(datas[9]);
                npcdata.rotz = float.Parse(datas[10]);

                npcdata.scalex = float.Parse(datas[11]);
                npcdata.scaley = float.Parse(datas[12]);
                npcdata.scalez = float.Parse(datas[13]);

                npcdata.hasName = int.Parse(datas[14]);
                

                NpcInfodata.Add(npcdata);
                data = string.Empty;
            }

            sr.Close();

            return NpcInfodata;
        }

        

    }

    public List<NpcInfo> LoadNpcQuestData()
    {

        using (StreamReader sr = new StreamReader(Application.dataPath + "/" + "NPCQuestData.csv"))
        {

            sr.ReadLine();
            string data = string.Empty;

            List<NpcInfo> NpcQuestdata = new List<NpcInfo>();

            while ((data = sr.ReadLine()) != null)
            {

                // Debug.Log(data);

                NpcInfo npcquestdata = new NpcInfo();

                string[] datas = data.Split(',');

                npcquestdata.rsName = datas[1];
                npcquestdata.questNum = int.Parse(datas[2]);

                NpcQuestdata.Add(npcquestdata);
                data = string.Empty;
            }

            sr.Close();

            return NpcQuestdata;
        }



    }
    public List<QuestData> LoadPlayerQuestData()
    {
        using (StreamReader sr = new StreamReader(Application.dataPath + "/" + "PlayerQuestData.csv"))
        {

            sr.ReadLine();

            string data = string.Empty;
            QuestData questData = new QuestData();
            List<QuestData> returnquestData = new List<QuestData>();

            while ((data = sr.ReadLine()) != null)
            {
                string[] datas = data.Split(',');

                
                questData.index = int.Parse(datas[0]);
                questData.npcId = int.Parse(datas[1]);
                questData.questID = int.Parse(datas[2]);
                questData.rewardExp = int.Parse(datas[3]);
                questData.questName = datas[4];
                questData.questTalk = datas[5];
                questData.targetName = datas[6];
                questData.targetScore = int.Parse(datas[7]);
                questData.targetScoremin = int.Parse(datas[8]);

                returnquestData.Add(questData);    
                data = string.Empty;
            }

            return returnquestData;

            sr.Close();
        }

        
    }


    public void LoadPlayer()
    {
        GameObject obj = Resources.Load<GameObject>("player");

        if(obj != null)
            rsPlayer = obj;
    }


    public void LoadMonster()
    {
        GameObject[] objs= Resources.LoadAll<GameObject>("Use/Monster");

        if (objs != null)
        {
            for (int i = 0; i < objs.Length; i++)
            {
                rsMonster.Add(objs[i]);

            }
        }

    }

  

    public GameObject LoadMonsterNameCheck(string name)
    {

        foreach(GameObject one in rsMonster)
        {
            if(one.name == name)
            {
                return one;
            }
        }
        return null;
    }

    /******************************************************************/


}

