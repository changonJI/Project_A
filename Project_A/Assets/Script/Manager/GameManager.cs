using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
    public static GameManager Inst = null;      //싱글톤 선언

    /*******************************변수*******************************/

    
    // 플레이어 정보
    private Player player = null;               // player 값 저장, 외부 접근 금지.

    public Player PLAYER                        // 프로퍼티를 이용하여 player 값 리턴
    {
        get { return player; }
        set { player = value; }

    }

    PlayerInfo playerInfo = new PlayerInfo();

    public PlayerInfo PLAYERINFO
    {
        get { return playerInfo; }
        set { playerInfo = value; }
    }

    List<ItemData> PlayerInvenData = new List<ItemData>();

    public List<ItemData> PLAYERINVENDATA
    {
        get { return PlayerInvenData; }
        set { PlayerInvenData = value; }
    }

    List<ItemData> PlayerEquipData = new List<ItemData>();

    public List<ItemData> PLAYEREQUIPDATA
    {
        get { return PlayerEquipData; }
        set { PlayerEquipData = value; }
    }




    List<QuestData> playerQuestData = new List<QuestData>();

    public List<QuestData> PALYERQUESTDATA                // 프로퍼티를 이용하여 monster 값 반환
    {
        get { return playerQuestData; }
        set { playerQuestData = value; }

    }

    // 몬스터 정보

    private List<Monster> monster = new List<Monster>();        // monster를 list로 보관

    public List<Monster> MONSTER                // 프로퍼티를 이용하여 monster 값 반환
    {
        get { return monster; }
        set { monster = value; }

    }

    // 보스 몬스터 정보
    private List<Monster> Bossmonster = new List<Monster>();        // bossmonster를 list로 보관

    public List<Monster> BOSSMONSTER                // 프로퍼티를 이용하여 monster 값 반환
    {
        get { return Bossmonster; }
        set { Bossmonster = value; }

    }

    // 몬스터 상태 값
    List<MonsterInfo> monsterInfo = new List<MonsterInfo>();
    public List<MonsterInfo> MONSTERINFO
    {
        get { return monsterInfo; }
        set { monsterInfo = value; }
    }

    // NPC 정보

    List<NPC> npc = new List<NPC>();
    public List<NPC> NPC
    {
        get { return npc; }
        set { npc = value; }
    }

    List<NpcInfo> npcInfo = new List<NpcInfo>();
    public List<NpcInfo> NPCINFO
    {
        get { return npcInfo; }
        set { npcInfo = value; }
    }

    List<NpcInfo> npcQuestData = new List<NpcInfo>();
    public List<NpcInfo> NPCQUESTDATA
    {
        get { return npcQuestData; }
        set { npcQuestData = value; }
    }

    // 빌딩 정보
    List<BuildingInfo> BuildingInfo = new List<BuildingInfo>();
    public List<BuildingInfo> BUILDINGINFO
    {
        get { return BuildingInfo; }
        set { BuildingInfo = value; }
    }


    // spawn 위치
    // public Transform spawn = null;              


    /******************************************************************/

    /******************************함수********************************/

    /******************************************************************/

    public GameObject MonsterObjectPooling()
    {
        foreach(Monster one in monster)
        {
            if (one.gameObject.activeSelf.Equals(false))
            {
                return one.gameObject;
            }
        }

        return null;

    }

    void Awake()
    {
       if (Inst == null)
            Inst = this;

        BuildingInfo = LoadManager.Instant.LoadBuildingData();
        monsterInfo = LoadManager.Instant.LoadMonsterData();
        playerInfo = LoadManager.Instant.LoadPlayerData();
        playerQuestData = LoadManager.Instant.LoadPlayerQuestData();
        npcInfo = LoadManager.Instant.LoadNpcData();
        npcQuestData = LoadManager.Instant.LoadNpcQuestData();
        PlayerInvenData = LoadManager.Instant.LoadPlayerInvenData();
        PlayerEquipData = LoadManager.Instant.LoadPlayerEquipmentData();

        LoadManager.Instant.LoadMonster();
        
    }

}
