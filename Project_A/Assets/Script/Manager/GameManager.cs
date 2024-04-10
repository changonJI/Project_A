using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
    public static GameManager Inst = null;      //�̱��� ����

    /*******************************����*******************************/

    
    // �÷��̾� ����
    private Player player = null;               // player �� ����, �ܺ� ���� ����.

    public Player PLAYER                        // ������Ƽ�� �̿��Ͽ� player �� ����
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

    public List<QuestData> PALYERQUESTDATA                // ������Ƽ�� �̿��Ͽ� monster �� ��ȯ
    {
        get { return playerQuestData; }
        set { playerQuestData = value; }

    }

    // ���� ����

    private List<Monster> monster = new List<Monster>();        // monster�� list�� ����

    public List<Monster> MONSTER                // ������Ƽ�� �̿��Ͽ� monster �� ��ȯ
    {
        get { return monster; }
        set { monster = value; }

    }

    // ���� ���� ����
    private List<Monster> Bossmonster = new List<Monster>();        // bossmonster�� list�� ����

    public List<Monster> BOSSMONSTER                // ������Ƽ�� �̿��Ͽ� monster �� ��ȯ
    {
        get { return Bossmonster; }
        set { Bossmonster = value; }

    }

    // ���� ���� ��
    List<MonsterInfo> monsterInfo = new List<MonsterInfo>();
    public List<MonsterInfo> MONSTERINFO
    {
        get { return monsterInfo; }
        set { monsterInfo = value; }
    }

    // NPC ����

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

    // ���� ����
    List<BuildingInfo> BuildingInfo = new List<BuildingInfo>();
    public List<BuildingInfo> BUILDINGINFO
    {
        get { return BuildingInfo; }
        set { BuildingInfo = value; }
    }


    // spawn ��ġ
    // public Transform spawn = null;              


    /******************************************************************/

    /******************************�Լ�********************************/

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
