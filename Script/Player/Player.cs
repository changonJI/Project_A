using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class Player : MonoBehaviour
{

    
    /*******************************����*******************************/

    /* HpBar */
    public Image hpbar;
    public Image informationhpbar;
    GameObject hppos;
    Text hpCountText;
    /*******************/

    //string job;
    string name;
    byte level;
    float hp;
    float maxHp;
    float power;
    float exp;
    int money;

    // equipItem
    List<ItemData> equipItem = new List<ItemData>();
    int equiphead;
    int equipbody;
    int equipfoot;
    int equipweapon;
    int equipshield;
    

    string scene;

    float moveSpeed = 2f;
    float rotateSpeed = 15f;
   
    Vector3 vEnd = Vector3.zero;

    // ���� ����
    Transform target = null;
    Monster nowTargetMonset;

    // ����Ʈ ����
    List<QuestData> playerQuest = new List<QuestData>();
    string questState;
    //List<QuestData> playerQuest;
    //int questScore = 0;

    // �κ��丮
    List<ItemData> playerInven = new List<ItemData>();
    int playerInvenCount = 12;

    // ����
    NavMeshAgent nav;
    bool onAttack = false;
    bool autoAttack = false;

    // ȸ�Ǳ�
    bool avoid = false;
    bool skill_Avoid_state = false;
    float skill_Avoid_cool = 0f;
    float skill_Avoid_cool_max = 0f;

    // ��ų����
    int nowskillnum = 0;

    bool skill_1_state = false;
    float skill_1_cool = 0f;
    float skill_1_cool_max = 0f;

    bool skill_2_state = false;
    float skill_2_cool = 0f;
    float skill_2_cool_max = 0f;

    
    /******************************************************************/

    /****************************������Ƽ******************************/

    public bool PLAYERDEAD
    {

        get 
        {
            if (hp <= 0)
            {
                return true;
            }
            
            return false;
        }
    }

    public string PLAYERNAME
    {
        get { return name; }
        set { name = value; }
    }
   
    public byte PLAYERLEVEL
    {
        get { return level; }
        set { level = value; }
    }

    public float PLAYERHP
    {
        get { return hp; }
        set { hp = value; }
    
    }

    public float PLAYERMAXHP
    {
        get { return maxHp; }
        set { maxHp = value; }

    }

    public float PLAYERPOWER
    {
        get { return power; }
        set { power = value; }

    }

    public float PLAYEREXP
    {
        get { return exp; }
        set { exp = value; }

    }
    public int PLAYERMONEY
    {
        get { return money; }
        set { money = value; }

    }

    public string PLAYERSCENE
    {
        get { return scene; }
        set { scene = value; }
    }

    public float MOVESPEED
    {
        get { return moveSpeed; }
    }

    public List<ItemData> EQUIPITEM
    {
        get { return equipItem; }
        set { equipItem = value; }
    }

    public int EQUIPHEAD
    {
        get { return equiphead; }
        set { equiphead = value; }
    }
   
    public int EQUIPBODY
    {
        get { return equipbody; }
        set { equipbody = value; }
    }

    public int EQUIPFOOT
    {
        get { return equipfoot; }
        set { equipfoot = value; }
    }
 
    public int EQUIPWEAPON
    {
        get { return equipweapon; }
        set { equipweapon = value; }
    }

    public int EQUIPSHIELD
    {
        get { return equipshield; }
        set { equipshield = value; }
    }




    public Vector3 VEND
    {
        get { return vEnd; }
        set { vEnd = value; }
    }

    

    public Transform TARGET
    {
        get { return target; }
        set { target = value; }
    
    }

    public List<ItemData> PLAYERINVEN
    {
        get { return playerInven; }
        set { playerInven = value; }
    }

    public int PLAYERINVENCOUNT
    {
        get { return playerInvenCount; }
        set { playerInvenCount = value; }
    }

    public bool ONATTACK
    {
        get { return onAttack; }
        set { onAttack = value; }
    }

    public bool AUTOATTACK
    {
        get { return autoAttack; }
        set { autoAttack = value; }
    }

    public int NOWSKILLNUM
    {
        get { return nowskillnum; }
        set { nowskillnum = value; }
    }

    public bool AVOID
    {
        get { return avoid; }
        set { avoid = value; }
    }

    public Text HPCOUNTTEXT
    {
        get { return hpCountText; }
        set { hpCountText = value; }
    }
    public List<QuestData> PLAYERQUEST                // ������Ƽ�� �̿��Ͽ� monster �� ��ȯ
    {
        get { return playerQuest; }
        set { playerQuest = value; }

    }

    /*public int QUESTSCORE
    {
        get { return questScore; }
        set { questScore = value; }
    }*/
    
    public Monster NOWTARGETMONSTER
    {
        get { return nowTargetMonset; }
        set { nowTargetMonset = value; }
    }

    /******************************************************************/

    /*******************************�Լ�*******************************/

    public void MovePlayer()
    {
              
       
        transform.position = 
            Vector3.MoveTowards(transform.position, vEnd, Time.deltaTime * moveSpeed);
        
    }

    public void JoyStickPos()
    {
        Vector3 JoyPos =
        new Vector3(JoyStickManager.inst.DIR.x + transform.position.x, 0, JoyStickManager.inst.DIR.y + transform.position.z);// * transform.position.x;

        vEnd = JoyPos;
        
    }

    public void RoTatePlayer()
    {
        Vector3 height = vEnd;
        height.y = transform.position.y;
        Vector3 dir = height - transform.position;
        Vector3 tmp = 
            Vector3.RotateTowards(transform.forward, dir.normalized, Time.deltaTime * rotateSpeed, 0);
        transform.rotation = Quaternion.LookRotation(tmp);
    }

    public Monster GetTargetMonster(Transform target)
    {

        if (target != null)
        {
            for (int i = 0; i < GameManager.Inst.MONSTER.Count; i++)
            {
                if (target.gameObject == GameManager.Inst.MONSTER[i].gameObject)    
                    return GameManager.Inst.MONSTER[i];
            }

            
            for (int i = 0; i < GameManager.Inst.BOSSMONSTER.Count; i++)
            {
                if (target.gameObject == GameManager.Inst.BOSSMONSTER[i].gameObject)                
                    return GameManager.Inst.BOSSMONSTER[i];
            }
            
        }
        return null;
    }
    public IEnumerator LevelUp()
    {
        HudManager.Inst.LevelUp_Text_Effect.gameObject.SetActive(true);
        HudManager.Inst.LevelUp_Text_Effect.transform.position = 
            Camera.main.WorldToScreenPoint(hppos.transform.position + hppos.transform.up);

        HudManager.Inst.LevelUp_Effect.transform.position
            = transform.position;
        
        HudManager.Inst.LevelUp_Effect.Play();

        level += 1;
        power += 5f;
        hp += 10f;
        maxHp += 10f;
        exp = 0f;

        yield return new WaitForSeconds(2f);

        HudManager.Inst.LevelUp_Text_Effect.gameObject.SetActive(false);
    }


    public NPC GetTargetNPC(Transform target)
    {
        if(target != null)
        {
            foreach(NPC one in GameManager.Inst.NPC)
            {
                if (target.gameObject.Equals(one.gameObject))
                {
                    return one;
                }
            }
        }
        return null;
    }


    public void Attack()
    {

        nowTargetMonset = GetTargetMonster(target);

        
        if (nowTargetMonset != null)
        {

            nowTargetMonset.HPCOUNTTEXT.gameObject.SetActive(true);
            nowTargetMonset.HPCOUNTTEXT.text = "-" + power;

            HudManager.Inst.Attack_Blood.transform.position = target.position;
            HudManager.Inst.Attack_Blood.Play();


            nowTargetMonset.MONSTERHP -= power;

        }

    }

    
    public void targetAttack()
    {
        if (GameManager.Inst.MONSTER.Count != 0)
        {
            List<Monster> mobdis = new List<Monster>();
            for (int i = 0; i < GameManager.Inst.MONSTER.Count; i++)
            {
                if (GameManager.Inst.MONSTER[i].MONSTERDEAD == false)
                {
                    mobdis.Add(GameManager.Inst.MONSTER[i]);
                }

            }

            mobdis.Sort((x, y) => x.DISTANCE.CompareTo(y.DISTANCE));

            target = mobdis[0].transform;

            nav.enabled = true;

            vEnd = GameManager.Inst.PLAYER.TARGET.position;

            nav.destination = vEnd;

            onAttack = false;
        }

    }
    public void AutoAttack()
    {

        if (GameManager.Inst.MONSTER.Count != 0)
        {
            List<Monster> mobdis = new List<Monster>();
            for(int i = 0; i < GameManager.Inst.MONSTER.Count; i++)
            {
                if(GameManager.Inst.MONSTER[i].MONSTERDEAD == false)
                {
                    mobdis.Add(GameManager.Inst.MONSTER[i]);
                }

            }

            mobdis.Sort((x, y) => x.DISTANCE.CompareTo(y.DISTANCE));

            target = mobdis[0].transform;
            
            nav.enabled = true;

            vEnd = GameManager.Inst.PLAYER.TARGET.position;

            nav.destination = vEnd;

                     
        }

    }

   

    public void offAutoAttack()
    {
        nav.enabled = false;

    }

    public void skillAvoidCoolOn(float _coolTime)
    {
        skill_Avoid_cool_max = _coolTime;
        skill_Avoid_state = true;
    }

    public void skillCoolOn(float _coolTime)
    {
        skill_1_cool_max = _coolTime;
        skill_1_state = true;
    }

    public void useActiveSkill(float _power)  
    {
        HudManager.Inst.SKILLEFFECT_1.gameObject.SetActive(true);
        HudManager.Inst.SKILLEFFECT_1.position = GameManager.Inst.PLAYER.TARGET.position;
        
        power += _power;          

        Attack();

        power -= _power; // �ʱ�ȭ

    }

    /*public bool IsPointerOverUIObject()
    {
        PointerEventData ClickPos =
            new PointerEventData(EventSystem.current);      //PointerEventData ����

        ClickPos.position =
            new Vector2(Input.mousePosition.x, Input.mousePosition.y);  // PointerEventData ��ġ�� ���콺 Ŭ���� x,y ��ġ

        List<RaycastResult> results = new List<RaycastResult>();        
        EventSystem.current.RaycastAll(ClickPos, results);

        return results.Count > 0;
    }
    */

    public void CreateHpbar()
    {

        informationhpbar = HudManager.Inst.Player_Hp_bar;

        // Hp ��ġ�� ���� �� ���ӿ�����Ʈ ����
        hppos = new GameObject();
        hppos.name = "hpBar";
        hppos.transform.SetParent(gameObject.transform);
        hppos.transform.localPosition = new Vector3(0, gameObject.transform.position.y + 2f, 0);

        // HP �������� �������� �ε�
        Image hpobj = HudManager.Inst.Chracter_Hp;
        hpbar = Instantiate<Image>(hpobj);
        hpbar.name = gameObject.name + "_Hpbar";
        hpbar.transform.SetParent(HudManager.Inst.Chracter_Hp_Parent);

        // HPCount UI ��������
        Text hpCountobj = HudManager.Inst.Chracter_Hp_Count_Text;
        hpCountText = Instantiate<Text>(hpCountobj);
        hpCountText.transform.position = Camera.main.WorldToScreenPoint(hppos.transform.position);
        hpCountText.transform.SetParent(HudManager.Inst.Chracter_Hp_Parent);

        // hpbar�� HP�������� �̹��� ���� �� �� ���ӿ�����Ʈ�� ��ġ ����
        hpbar.transform.position = Camera.main.WorldToScreenPoint(hppos.transform.position);
        hpbar.gameObject.SetActive(true);
   
    }

    public void CreateUI()
    {
        // hpbar ��ġ �̵�
        hpbar.transform.position = Camera.main.WorldToScreenPoint(hppos.transform.position);

        // hp ǥ��
        hpbar.fillAmount = hp / maxHp;
        informationhpbar.fillAmount = hp / maxHp;
        HudManager.Inst.Player_Hp_Text.text = hp + " / " + maxHp;

        // hp �ؽ�Ʈ ǥ��
        hpCountText.transform.position = Camera.main.WorldToScreenPoint(hppos.transform.position);
        hpCountText.transform.position += new Vector3(0, 12, 0);

        //level ǥ��
        HudManager.Inst.Player_Level_Inform.text = level.ToString();

        // exp
        HudManager.Inst.Player_Exp_bar.fillAmount = exp / 100;
        HudManager.Inst.Player_Exp_Percent.text = (exp / 1).ToString() + "%";
    }

    public void ClickEffectUI()
    {

        ParticleSystem ps =  HudManager.Inst.ClickEffect;
        ps.Play();

        ps.gameObject.SetActive(true);
        Vector3 ClickEffectpos = vEnd;
        ClickEffectpos.y += 0.5f;
        ps.transform.position = ClickEffectpos;

         
    }

    /******************************************************************/

    void Awake()
    {
        //player ����
        name = GameManager.Inst.PLAYERINFO.name;
        level = GameManager.Inst.PLAYERINFO.level;
        hp = GameManager.Inst.PLAYERINFO.hp;
        maxHp = GameManager.Inst.PLAYERINFO.maxHp;
        power = GameManager.Inst.PLAYERINFO.power;
        exp = GameManager.Inst.PLAYERINFO.exp;
        money = GameManager.Inst.PLAYERINFO.money;
        scene = GameManager.Inst.PLAYERINFO.scene;

        //player ����Ʈ����
        playerQuest = GameManager.Inst.PALYERQUESTDATA;

        //player �κ��丮����
        playerInven = GameManager.Inst.PLAYERINVENDATA;

        //player �������
        equipItem = GameManager.Inst.PLAYEREQUIPDATA;

        equiphead = GameManager.Inst.PLAYERINFO.equipHead;
        equipbody = GameManager.Inst.PLAYERINFO.equipBody;
        equipfoot = GameManager.Inst.PLAYERINFO.equipFoot;
        equipweapon = GameManager.Inst.PLAYERINFO.equipWeapon;
        equipshield = GameManager.Inst.PLAYERINFO.equipShield;


    }

    void Start()
    {
        // ��ġ�� �ʱ�ȭ
        vEnd = transform.position;

        // hpbar �ν��Ͻ�
        CreateHpbar();

        // navMesh ���
        nav = gameObject.GetComponent<NavMeshAgent>();
        
    }

    void Update()
    {
       
        // ü�°���
        CreateUI();

        // money
        HudManager.Inst.Player_Money_text.text = money.ToString();
        HudManager.Inst.Inven_Money_text.text = money.ToString();
        // ����Ʈ Ȯ��
        // ����Ʈ�� ������ �ޱ� ���ؼ��� UI�� �޾ƿͼ� �ν��Ͻ�ȭ �Ѵ�.
        if (playerQuest.Count > 0)
        {
            HudManager.Inst.QuestBox.SetActive(true);
            
            
            HudManager.Inst.QuestName.text =
                playerQuest[0].questName;

            if (playerQuest[0].targetName != null)
            {
                HudManager.Inst.QuestState.text =
                      playerQuest[0].targetName + ":"
                    + playerQuest[0].targetScoremin.ToString() + "/"
                    + playerQuest[0].targetScore.ToString();
            }
        }
        else
            HudManager.Inst.QuestBox.SetActive(false);

        // �÷��̾� ���� üũ
        RaycastHit hitinfo;
        if (Physics.Raycast(transform.position,transform.forward, out hitinfo, 1f))
        {

            //Debug.DrawLine(transform.position, hitinfo.transform.position,Color.red);

            if (hitinfo.collider.CompareTag("Building"))
            {
                transform.position -= transform.forward * 0.1f;
                vEnd = transform.position;
            }

            if (hitinfo.collider.CompareTag("Spawn"))
            {
                target = hitinfo.collider.transform;
                SceneMoveManager.inst.sceneMove(target.name);
            }

        }


        // Ű���� 
        if (JoyStickManager.inst.ONJOYSTICK)
        {
            JoyStickPos();
            moveSpeed = JoyStickManager.inst.MOVESPEED;
        }
        
        // ���콺 ��ŷ
        if (Input.GetMouseButtonDown(0))
        {   

            //if (!IsPointerOverUIObject())    
            if (!EventSystem.current.IsPointerOverGameObject())
            {

                if (autoAttack == true ||
                    onAttack == true)
                {
                    HudManager.Inst.onautoatk.SetActive(true);
                    HudManager.Inst.offautoatk.SetActive(false);
                    autoAttack = false;
                    nav.enabled = false;

                }

                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hitInfo;
                moveSpeed = 2f;

                int layerMask = 1 << 6;
                layerMask = ~layerMask;
                                
                if (Physics.Raycast(ray, out hitInfo, Mathf.Infinity, layerMask))
                {
                    //Debug.Log(hitInfo.collider.name);
                    if (hitInfo.collider.gameObject.CompareTag("Terrain"))
                    {
                        vEnd = hitInfo.point;
                        target = null;

                    }

                    if (hitInfo.collider.gameObject.CompareTag("Monster"))
                    {
                        vEnd = hitInfo.collider.transform.position;
                        target = hitInfo.collider.transform;
                        
                        Debug.Log(target.tag);
                    }

                    if (hitInfo.collider.gameObject.CompareTag("NPC"))
                    {
                        vEnd = hitInfo.collider.transform.position;
                        target = hitInfo.collider.transform;
                        //QuestManager.Instant.getQuest(target.transform);
                        
                        
                    }

                }

                ClickEffectUI();
            }


      
        }
      

            // ����

        if (autoAttack == true)
        {
            AutoAttack();
        }
        else if(autoAttack == false)
        {
            offAutoAttack();
        }
        
        // �Ϲ� ����
        if(onAttack == true)
        {
            targetAttack();
        }


        // ������
        
        if(exp >= 100f)
        {
            StartCoroutine(LevelUp());
            hp = maxHp;
            
        }

        // ��Ÿ��

        if (skill_Avoid_state == true)
        {
            skill_Avoid_cool += Time.deltaTime;
            HudManager.Inst.skill_Cool_Avoid.fillAmount = skill_Avoid_cool / skill_Avoid_cool_max;
            HudManager.Inst.skill_Cool_Avoid.raycastTarget = true;

            if (skill_Avoid_cool >= skill_Avoid_cool_max)
            {
                skill_Avoid_state = false;
                skill_Avoid_cool = 0f;
                HudManager.Inst.skill_Cool_Avoid.fillAmount = skill_Avoid_cool;
                HudManager.Inst.skill_Cool_Avoid.raycastTarget = false;
               
                HudManager.Inst.skillslot_Avoid.interactable = true;
            }
        }

        if (skill_1_state == true)
        {
            skill_1_cool += Time.deltaTime;
            HudManager.Inst.skill_Cool_1.fillAmount = skill_1_cool / skill_1_cool_max;
            HudManager.Inst.skill_Cool_1.raycastTarget = true;

            if (skill_1_cool >= skill_1_cool_max)
            {
                skill_1_state = false;
                skill_1_cool = 0f;
                HudManager.Inst.skill_Cool_1.fillAmount = skill_1_cool;
                HudManager.Inst.skill_Cool_1.raycastTarget = false;
               
                HudManager.Inst.skillslot_1.interactable = true;
            }
        }

    }

    
}
