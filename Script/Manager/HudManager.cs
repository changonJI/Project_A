using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class HudManager : MonoBehaviour
{
    static public HudManager Inst = null;

    //Ȱ��ȭ�� UI ����
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

    // �Ķ���� ����
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
    // QuestName, QuestScore ��ũ�Ѻ�� ��ġ��

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
            Debug.Log("���Ͱ� �����ϴ�");
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
            Debug.Log("���Ͱ� �����ϴ�");
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
                Debug.Log("�κ��丮 �������");

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
                Debug.Log("�������� ��� ����");
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

        Debug.Log("����Ǿ����ϴ�.");
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


    // NPC_��ȭ�ϱ�(����Ʈ)
    public void npcTalk()
    {
        NPC_Menu_Box.SetActive(false);

        NPC_Talk_Box.SetActive(true);

        SubCam_1.transform.position =
            GameManager.Inst.PLAYER.TARGET.transform.position + GameManager.Inst.PLAYER.TARGET.transform.forward + new Vector3(0f, 1.1f, 0f);
        
        SubCam_1.transform.LookAt(GameManager.Inst.PLAYER.TARGET.transform.position + new Vector3(0f, 1.1f, 0f));

        ActiveUI.Add(NPC_Menu_Box);
        ActiveUI.Add(NPC_Talk_Box);

        // �⺻ text ǥ��
        NPC_Talk_Box_Text.text =
            GameManager.Inst.PLAYER.GetTargetNPC(GameManager.Inst.PLAYER.TARGET).
            QUESTLIST[0].questTalk;

        // 1. NPC�� ����Ʈ�� �������ִ� ����Ʈ ���� ���� ���� NPC�� ����Ʈ ������ ũ�ٸ� ��ư Ȱ��ȭ
        if (GameManager.Inst.PLAYER.GetTargetNPC(GameManager.Inst.PLAYER.TARGET).
            QUESTLIST.Count > GameManager.Inst.PLAYER.GetTargetNPC(GameManager.Inst.PLAYER.TARGET).QUESTNUM)
        {
            NPC_Talk_Box_Quest_Button.gameObject.SetActive(true);

            // 1-1. �÷��̾ NPC�� ����Ʈ�� ������ �ִ��� �˻�
            if (GameManager.Inst.PLAYER.PLAYERQUEST.Count > 0)
            {
                foreach (QuestData one in GameManager.Inst.PLAYER.PLAYERQUEST)
                {
                    // 1-2-1. Ÿ��npc�� ID���� ����Ʈ�� ID���� ����, ������ �ִ� ����Ʈ�� ID����, NPC�� ����ƮNUM���� ���ٸ�, ����Ʈ ������ư�� ����.
                    if (one.npcId.Equals(GameManager.Inst.PLAYER.GetTargetNPC(GameManager.Inst.PLAYER.TARGET).ID) &&
                        one.questID.Equals(GameManager.Inst.PLAYER.GetTargetNPC(GameManager.Inst.PLAYER.TARGET).QUESTNUM))
                    {
                        NPC_Talk_Box_Quest_Button.gameObject.SetActive(false);

                        // 1-2-2. ����Ʈ�� ���� �Ϸ��ߴٸ� Ŭ���� ��ư Ȱ��ȭ
                        if (one.targetScoremin >= one.targetScore)
                        {
                            NPC_Talk_Box_Clear_Button.gameObject.SetActive(true);
                        }
                    }
                }
            }
        }
    }


    // ����Ʈ ��ư ������
    public void questListIcon()
    {

        NPC_Talk_Box_Quest_Button.gameObject.SetActive(false);

        
        // NPC�� QUESTNUM���� üũ��, ���� ������ �־�� �ϴ� ����Ʈ�� ������ ����
        NPC_Talk_Box_Text.text =
            GameManager.Inst.PLAYER.GetTargetNPC(GameManager.Inst.PLAYER.TARGET).
            QUESTLIST[GameManager.Inst.PLAYER.GetTargetNPC(GameManager.Inst.PLAYER.TARGET).QUESTNUM].questTalk;

        // ����Ʈ ���ǹ��� �ִٸ� �߰�.
        // ������ư Ȱ��ȭ
        NPC_Talk_Box_Agree_Button.gameObject.SetActive(true);

        Quest_Action_Icon = NPC_Talk_Box_Agree_Button.gameObject;
    }

    // ����Ʈ ������ư
    public void getQuest()
    {
        GameManager.Inst.PLAYER.PLAYERQUEST.Add         // �÷��̾��� ����Ʈ����Ʈ�� NPC ���� ����Ʈ�� �޾ƿ´�.
           (GameManager.Inst.PLAYER.GetTargetNPC(GameManager.Inst.PLAYER.TARGET).QUESTLIST  // ���� Ÿ���� �� NPC�� ����Ʈ����Ʈ
           [GameManager.Inst.PLAYER.GetTargetNPC(GameManager.Inst.PLAYER.TARGET).QUESTNUM]);  // ����Ʈ����Ʈ �� ���� NPC�� ����Ʈ ���¹�ȣ�� ����Ʈ�� �����´�.


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

    // npcNum�� ����, 
    public void questClear()
    {
        QuestData playerQuest = agreedQuest();
        Debug.Log(playerQuest.rewardExp);
        if (playerQuest.targetScoremin >= playerQuest.targetScore)
        {
            
            // ���� NPC�� ����Ʈ�� ����� �÷��̾ ���ϰ� NPC�� ����Ʈ �ѹ��� �ø���.
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
        //0. NPC ��ȭ off
        NPC_Menu_Box.gameObject.SetActive(false);
        //1. ���� UI, �κ� UI On
        scrollrect.gameObject.SetActive(true);
        OpenInven();

        //2. ������ ������ ���� �µ�
        npcItem = 
            ItemManager.inst.getItemInfo(GameManager.Inst.PLAYER.GetTargetNPC(GameManager.Inst.PLAYER.TARGET).TAGNAME);
        //3. ����Ʈ���� �����´�.
       
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


// ĳ���� ��Ȱ ��ư
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
