using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class HudManager : MonoBehaviour
{
    static public HudManager Inst = null;

    //활성화된 UI 저장
    List<GameObject> ActiveUI = new List<GameObject>();
    public List<GameObject> ACTIVEUI 
    {
        get { return ActiveUI; }    
        set { ActiveUI = value; }
    
    }

    GameObject Quest_Action_Icon = null;

    // Camera
    public Camera SubCam_1;

    //Hp, Name, NamePos
    public Image Player_Hp_bar;
    public Text Player_Hp_Text;
    public Image Chracter_Hp;
    public Transform Chracter_Hp_Parent;
  
    public Text Chracter_Hp_Count_Text;

    public Text NPC_Name_Origin;
    public Transform NPC_name_Parent;

    // exp
    public Image Player_Exp_bar;
    public Text Player_Level_Inform;
    public Text Player_Exp_Percent;

    // money
    public Text Player_Money_text;
    
    // Active
    public GameObject onautoatk;
    public GameObject offautoatk;

    public Button skillslot_Avoid;
    public Button skillslot_1; 
    public Button skillslot_2;

    // 파라미터 접근
    Transform skillEffect_Avoid;
    Transform skillEffect_1;
    Transform skillEffect_2;

    public Image skill_Cool_Avoid;
    public Image skill_Cool_1;
    public Image skill_Cool_2;

    //Inven
    public Transform UI_Inven;

    // Inven_stat
    public Text Inven_stat_power_text;
    public Text Inven_stat_hp_text;

    // Inven_item
    public Text Inven_Money_text;
    public Image[] UI_Inven_Slot;
    public Image[] UI_Inven_Equipment;

    // Configuration
    public Transform UI_Scroll_Menu;
    public GameObject Revive_Box_Menu;
    

    // Loading
    public Transform UICanvas;
    public Image endSceneImage;
    public Image Loading_Bar;
    public Text Loading_Text;

    // Quest
    public GameObject QuestBox;
    public Text QuestName;
    public Text QuestState;
    // QuestName, QuestScore 스크롤뷰로 합치기

    // NPC Menu_Box
    public GameObject NPC_Menu_Box;
    public Button NPC_Menu_Talk;

    // NPC Talk_Box
    public GameObject NPC_Talk_Box;
    public Text NPC_Talk_Box_Text;
    public Button NPC_Talk_Box_Next_Button;
    public Button NPC_Talk_Box_Clear_Button;
    public Button NPC_Talk_Box_Quest_Button;
    public Button NPC_Talk_Box_Agree_Button;

    // NPC Shop
    List<ItemData> npcItem;
    List<GameObject> itemSlot;
    //public GameObject itemSlot;
    public ScrollRect scrollrect;



    /* Effect */
    // ClickEffect
    public ParticleSystem ClickEffect;

    // BloodEffect
    public ParticleSystem Attack_Blood;

    // LevelEffect
    public ParticleSystem LevelUp_Effect;
    public Text LevelUp_Text_Effect;

    public Transform SKILLEFFECT_AVOID
    {
        get { return skillEffect_Avoid; }
        set { skillEffect_Avoid = value; }
    }

    public Transform SKILLEFFECT_1
    {
        get { return skillEffect_1; }
        set { skillEffect_1 = value; }
    }

    public Transform SKILLEFFECT_2
    {
        get { return skillEffect_2; }
        set { skillEffect_2 = value; }
    }

   



    public void onAttack()
    {
        if (GameManager.Inst.MONSTER.Count != 0)
        {
            GameManager.Inst.PLAYER.ONATTACK = true;
        }
        else
        {
            Debug.Log("몬스터가 없습니다");
        }
    }

    public void AutoAttack()
    {

        if (GameManager.Inst.PLAYER.AUTOATTACK == false &&
            GameManager.Inst.MONSTER.Count != 0)
        {
            GameManager.Inst.PLAYER.AUTOATTACK = true;

            if (onautoatk.activeSelf == true)
            {
                onautoatk.SetActive(false);
                offautoatk.SetActive(true);    
            }
            
        }
       else
        {
            Debug.Log("몬스터가 없습니다");
        }
        
    }

    public void StopAutoAttack()
    {
        if(GameManager.Inst.PLAYER.AUTOATTACK == true)
        {

            GameManager.Inst.PLAYER.AUTOATTACK = false;
            
            GameManager.Inst.PLAYER.TARGET = null;

            GameManager.Inst.PLAYER.VEND = GameManager.Inst.PLAYER.transform.position;


            if (offautoatk.activeSelf == true)
            {
                offautoatk.SetActive(false);
                onautoatk.SetActive(true);
            }
        }
    }

    public void playerAvoid()
    {
        skillslot_Avoid.interactable = false;
        GameManager.Inst.PLAYER.AVOID = true;
    }

    public void Skill_1()   
    {
        GameManager.Inst.PLAYER.NOWSKILLNUM = 5;      
    }

    public void Skill_2()
    {
        GameManager.Inst.PLAYER.NOWSKILLNUM = 6;    
        
    }


    public void OpenInven()
    {
        if (UI_Inven.gameObject.activeSelf.Equals(false))
        {

            Inven_stat_power_text.text = GameManager.Inst.PLAYER.PLAYERPOWER.ToString();
            Inven_stat_hp_text.text = GameManager.Inst.PLAYER.PLAYERMAXHP.ToString();
            UI_Inven.gameObject.SetActive(true);
            
            ActiveUI.Add(UI_Inven.gameObject);

            if (GameManager.Inst.PLAYER.PLAYERINVEN.Count > 0)
            {
                for (int i = 0; i < GameManager.Inst.PLAYER.PLAYERINVEN.Count; i++)
                {
                    string[] itemRsName = GameManager.Inst.PLAYER.PLAYERINVEN[i].itemRsName.Split('_');
                    UI_Inven_Slot[i].sprite =
                        Resources.Load<Sprite>("Use/ItemImage/" + itemRsName[1]);

                    UI_Inven_Slot[i].gameObject.SetActive(true);
                }
            }
            else
                Debug.Log("인벤토리 비어있음");

            if (GameManager.Inst.PLAYEREQUIPDATA.Count > 0)
            {
                for (int i = 0; i < GameManager.Inst.PLAYEREQUIPDATA.Count; i++)
                {
                    string[] rsName = GameManager.Inst.PLAYEREQUIPDATA[i].itemRsName.Split('_');
                    string[] itemID = GameManager.Inst.PLAYEREQUIPDATA[i].itemName.Split('_');

                    UI_Inven_Equipment[int.Parse(itemID[0])].sprite
                        = Resources.Load<Sprite>("Use/ItemImage/" + rsName[1]);
                }
            }
            else
                Debug.Log("착용중인 장비 없음");
        }
        
    }

    public void OpenConfiguration()
    {
        ActiveUI.Add(UI_Scroll_Menu.gameObject);
        UI_Scroll_Menu.gameObject.SetActive(true);

    }

    // save
    public void saveData()
    {
        SaveManager.Instant.SavePlayer();
        SaveManager.Instant.SavePlayerQuestData();
        SaveManager.Instant.SaveNpcQuestData();
        SaveManager.Instant.SavePlayerInven();

        if(GameManager.Inst.PLAYER.EQUIPITEM.Count > 0)
            SaveManager.Instant.SavePlayerEquipment();        

        Debug.Log("저장되었습니다.");
    }


    public void CloseBox()
    {
        if (ActiveUI != null)
        {
            GameManager.Inst.PLAYER.TARGET = null;
            for (int i = 0; i < ActiveUI.Count; i++)
            {
                ActiveUI[i].gameObject.SetActive(false);
            }
            ActiveUI.Clear();
        }

        if (Quest_Action_Icon != null)
        {
            Quest_Action_Icon.SetActive(false);

        }

        for(int i = 0; i < UI_Inven_Slot.Length; i++)
        {
            UI_Inven_Slot[i].gameObject.SetActive(false);
        }

    }


    // NPC_대화하기(퀘스트)
    public void npcTalk()
    {
        NPC_Menu_Box.SetActive(false);

        NPC_Talk_Box.SetActive(true);

        SubCam_1.transform.position =
            GameManager.Inst.PLAYER.TARGET.transform.position + GameManager.Inst.PLAYER.TARGET.transform.forward + new Vector3(0f, 1.1f, 0f);
        
        SubCam_1.transform.LookAt(GameManager.Inst.PLAYER.TARGET.transform.position + new Vector3(0f, 1.1f, 0f));

        ActiveUI.Add(NPC_Menu_Box);
        ActiveUI.Add(NPC_Talk_Box);

        // 기본 text 표시
        NPC_Talk_Box_Text.text =
            GameManager.Inst.PLAYER.GetTargetNPC(GameManager.Inst.PLAYER.TARGET).
            QUESTLIST[0].questTalk;

        // 1. NPC가 리스트로 가지고있는 퀘스트 길이 값이 현재 NPC의 퀘스트 값보다 크다면 버튼 활성화
        if (GameManager.Inst.PLAYER.GetTargetNPC(GameManager.Inst.PLAYER.TARGET).
            QUESTLIST.Count > GameManager.Inst.PLAYER.GetTargetNPC(GameManager.Inst.PLAYER.TARGET).QUESTNUM)
        {
            NPC_Talk_Box_Quest_Button.gameObject.SetActive(true);

            // 1-1. 플레이어가 NPC의 퀘스트를 가지고 있는지 검사
            if (GameManager.Inst.PLAYER.PLAYERQUEST.Count > 0)
            {
                foreach (QuestData one in GameManager.Inst.PLAYER.PLAYERQUEST)
                {
                    // 1-2-1. 타겟npc의 ID값과 퀘스트의 ID값이 같고, 가지고 있는 퀘스트의 ID값과, NPC의 퀘스트NUM값이 같다면, 퀘스트 수락버튼을 끈다.
                    if (one.npcId.Equals(GameManager.Inst.PLAYER.GetTargetNPC(GameManager.Inst.PLAYER.TARGET).ID) &&
                        one.questID.Equals(GameManager.Inst.PLAYER.GetTargetNPC(GameManager.Inst.PLAYER.TARGET).QUESTNUM))
                    {
                        NPC_Talk_Box_Quest_Button.gameObject.SetActive(false);

                        // 1-2-2. 퀘스트를 만약 완료했다면 클리어 버튼 활성화
                        if (one.targetScoremin >= one.targetScore)
                        {
                            NPC_Talk_Box_Clear_Button.gameObject.SetActive(true);
                        }
                    }
                }
            }
        }
    }


    // 퀘스트 버튼 누르기
    public void questListIcon()
    {

        NPC_Talk_Box_Quest_Button.gameObject.SetActive(false);

        
        // NPC의 QUESTNUM값을 체크후, 현재 가지고 있어야 하는 퀘스트의 내용을 공개
        NPC_Talk_Box_Text.text =
            GameManager.Inst.PLAYER.GetTargetNPC(GameManager.Inst.PLAYER.TARGET).
            QUESTLIST[GameManager.Inst.PLAYER.GetTargetNPC(GameManager.Inst.PLAYER.TARGET).QUESTNUM].questTalk;

        // 퀘스트 조건문이 있다면 추가.
        // 수락버튼 활성화
        NPC_Talk_Box_Agree_Button.gameObject.SetActive(true);

        Quest_Action_Icon = NPC_Talk_Box_Agree_Button.gameObject;
    }

    // 퀘스트 수락버튼
    public void getQuest()
    {
        GameManager.Inst.PLAYER.PLAYERQUEST.Add         // 플레이어의 퀘스트리스트에 NPC 현재 퀘스트를 받아온다.
           (GameManager.Inst.PLAYER.GetTargetNPC(GameManager.Inst.PLAYER.TARGET).QUESTLIST  // 현재 타겟이 된 NPC의 퀘스트리스트
           [GameManager.Inst.PLAYER.GetTargetNPC(GameManager.Inst.PLAYER.TARGET).QUESTNUM]);  // 퀘스트리스트 중 현재 NPC의 퀘스트 상태번호의 퀘스트를 가져온다.


        NPC_Talk_Box_Agree_Button.gameObject.SetActive(false);
        CloseBox();
    }

    public QuestData agreedQuest()
    {
        foreach (QuestData one in GameManager.Inst.PLAYER.PLAYERQUEST)
        {
            if (one.questName.Equals
                (GameManager.Inst.PLAYER.GetTargetNPC(GameManager.Inst.PLAYER.TARGET).QUESTLIST
                [GameManager.Inst.PLAYER.GetTargetNPC(GameManager.Inst.PLAYER.TARGET).QUESTNUM].questName))
            {

                Debug.Log(one.questName);
                return one;
            }
        }
        return null;
    }

    // npcNum값 증가, 
    public void questClear()
    {
        QuestData playerQuest = agreedQuest();
        Debug.Log(playerQuest.rewardExp);
        if (playerQuest.targetScoremin >= playerQuest.targetScore)
        {
            
            // 현재 NPC의 퀘스트의 결과를 플레이어에 더하고 NPC의 퀘스트 넘버를 올린다.
            GameManager.Inst.PLAYER.PLAYEREXP += playerQuest.rewardExp;

            GameManager.Inst.PLAYER.GetTargetNPC(GameManager.Inst.PLAYER.TARGET).QUESTNUM += 1;
            GameManager.Inst.PLAYER.PLAYERQUEST.Remove(playerQuest);
            NPC_Talk_Box_Clear_Button.gameObject.SetActive(false);

            CloseBox();
        }

    }

    // NPC Shop
    public void OpenShop()
    {
        //0. NPC 대화 off
        NPC_Menu_Box.gameObject.SetActive(false);
        //1. 상점 UI, 인벤 UI On
        scrollrect.gameObject.SetActive(true);
        OpenInven();

        //2. 아이템 정보를 가져 온뒤
        npcItem = 
            ItemManager.inst.getItemInfo(GameManager.Inst.PLAYER.GetTargetNPC(GameManager.Inst.PLAYER.TARGET).TAGNAME);
        //3. 리스트별로 가져온다.
       
        if (npcItem.Count > 0)
        {
            for (int i = 0; i < npcItem.Count; i++)
            {
                //GameObject shopItem = Instantiate<GameObject>(itemSlot);
                //shopItem.transform.SetParent(scrollrect.content);
                //ShopItemManager itemInfo = shopItem.GetComponent<ShopItemManager>();

                scrollrect.normalizedPosition = new Vector2(0, 1f);
                ShopItemManager itemInfo = scrollrect.content.GetChild(i).GetComponent<ShopItemManager>();
                
                string[] rsName = npcItem[i].itemRsName.Split('_');

                Sprite itemRsImage = Resources.Load<Sprite>("Use/ItemImage/" + rsName[1]);
                itemInfo.ItemImage.sprite = itemRsImage;

                itemInfo.ItemName.text = npcItem[i].itemInfo;
                //itemInfo.ItemInfo.text = npcItem[i].itemInfo;
                itemInfo.ItemPrice_text.text = npcItem[i].itemPrice.ToString();

                itemInfo.gameObject.SetActive(true);
                //itemSlot.Add(itemInfo.gameObject);
            }
        }

        ACTIVEUI.Add(scrollrect.gameObject);
        ActiveUI.Add(UI_Inven.gameObject);
    }

    public void CloseShop()
    {
        ItemManager.inst.RETURNITEMDATA.Clear();
        ItemManager.inst.ITEMLIST.Clear();
        npcItem.Clear();
        

       // itemSlot.Clear();
        if (scrollrect.content.childCount > 0)
        {
            for (int i = 0; i < scrollrect.content.childCount; i++)
            {
                scrollrect.content.GetChild(i).gameObject.SetActive(false);
                
            }
        }
        scrollrect.gameObject.SetActive(false);
        UI_Inven.gameObject.SetActive(false);
        ActiveUI.Clear();

        for (int i = 0; i < UI_Inven_Slot.Length; i++)
        {
            UI_Inven_Slot[i].gameObject.SetActive(false);
        }
    }


// 캐릭터 부활 버튼
    public void reviveButton()
    {
        GameManager.Inst.PLAYER.PLAYERSCENE = "Village";
        SceneManager.LoadScene(GameManager.Inst.PLAYER.PLAYERSCENE);

        endSceneImage.gameObject.SetActive(true);

        GameManager.Inst.PLAYER.transform.position = new Vector3(24.84f, 0, 21.44f);
        GameManager.Inst.PLAYER.PLAYERHP = GameManager.Inst.PLAYER.PLAYERMAXHP;
        GameManager.Inst.PLAYER.PLAYEREXP -= GameManager.Inst.PLAYER.PLAYEREXP * 0.2f;
        saveData();
    }


    void Awake()
    {
        if (Inst == null)
            Inst = this;

    }

}
