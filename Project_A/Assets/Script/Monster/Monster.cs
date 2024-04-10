using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Monster : MonoBehaviour
{
    /********************************변수********************************/

    /** 상태 **/
    public static Monster inst = null;

    Image hpbar;
    GameObject hppos;

    Text hpCountText;

    string name;
    int level;
    int autoattack;
    float maxhp;
    float hp;
    short power;
    int exp;

    int attackPoint = 0;
    int page = 1;

    float moveSpeed;

    float dis = 0f;

    Vector3 vEnd = Vector3.zero;

    Transform target;

    GameObject spawnEffectobj;

    /** 상태 반환 **/
    public string MONSTERNAME
    {
        get { return name; }
        set { name = value; }
    }
    public int MONSTERLEVEL
    {
        get { return level; }
        set { level = value; }
    }

    public bool MONSTERAUTOATTACK
    {
        get
        {
            if (autoattack > 0)
            {
                return true;
            }
            return false;
        }

    }

    public float MONSTERMAXHP
    {
        get { return maxhp; }
        set { maxhp = value; }
    }

    public float MONSTERHP
    {
        get { return hp; }
        set { hp = value; }
    }

    public short MONSTERPOEWR
    {
        get { return power; }
        set { power = value; }
    }

    public int MONSTEREXP
    {
        get { return exp; }
        set { exp = value; }
    }

    public int MONSTERATTACKPOINT
    {
        get { return attackPoint; }
        set { attackPoint = value; }
    }

    public int MONSTERPAGE
    {
        get { return page; }
        set { page = value; }
    }
    public Vector3 VEND
    {
        get { return vEnd; }
        set { vEnd = value; }
    }

    /** 임의 상태표시 **/
    public bool MONSTERDEAD
    {
        get
        {
            if (hp <= 0)
                return true;

            return false;
        }
    }


    public float DISTANCE
    {
        get { return dis; }
    
    
    }

    public Transform TARGET
    {
        get { return target;}
        set { target = value; }
    }


    public Text HPCOUNTTEXT
    {
        get { return hpCountText; }
        set { hpCountText = value; }
    }

    public GameObject SPAWNEFFECT
    {
        get { return spawnEffectobj; }
        set { spawnEffectobj = value; }
    }

    /******************************************************************/


    /********************************함수******************************/

    public void TargetCheck(float _distance)
    {
        if (GameManager.Inst.PLAYER != null &&
          GameManager.Inst.PLAYER.PLAYERDEAD == false &&
          dis < _distance)
        {
            target = GameManager.Inst.PLAYER.transform;
        }
        else
        {
            target = null;
        }

    }

    public void MonsterAttack()
    {
        GameManager.Inst.PLAYER.PLAYERHP -= power;

        GameManager.Inst.PLAYER.HPCOUNTTEXT.gameObject.SetActive(true);
        GameManager.Inst.PLAYER.HPCOUNTTEXT.text = "-" + power;

        HudManager.Inst.Attack_Blood.transform.position = target.position;
        HudManager.Inst.Attack_Blood.Play();

        attackPoint++;

    }

    public void MonsterSkillAttack(float _skillpower)
    {
        GameManager.Inst.PLAYER.PLAYERHP -= _skillpower;

        GameManager.Inst.PLAYER.HPCOUNTTEXT.gameObject.SetActive(true);
        GameManager.Inst.PLAYER.HPCOUNTTEXT.text = "-" + _skillpower;

        HudManager.Inst.Attack_Blood.transform.position = target.position;
        HudManager.Inst.Attack_Blood.Play();

        attackPoint = 0;

    }


    public void MonsterMove()
    {   
            transform.position =
            Vector3.MoveTowards(transform.position, target.gameObject.transform.position, Time.deltaTime * 2.5f);
    }

    public void MonsterRotate()
    {
        Vector3 targety = target.gameObject.transform.position;
        targety.y = transform.position.y;
        Vector3 dir = targety - transform.position;
        Vector3 tmp = Vector3.RotateTowards(transform.forward, dir.normalized, Time.deltaTime * 10f, 0);
        transform.rotation = Quaternion.LookRotation(tmp);

    }


    public void CreateHpbar()
    {
        // Hp 위치를 잡을 빈 게임오브젝트 생성
        hppos = new GameObject();
        hppos.name = "hpBar";
        hppos.transform.SetParent(gameObject.transform);
        hppos.transform.localPosition = gameObject.transform.up;

        // HPbar 가져오기
        Image hpobj = HudManager.Inst.Chracter_Hp;
        hpbar = Instantiate<Image>(hpobj);
        hpbar.name = gameObject.name + "_Hpbar";
        hpbar.transform.SetParent(HudManager.Inst.Chracter_Hp_Parent);

        // HPCount UI 가져오기
        Text hpCountobj = HudManager.Inst.Chracter_Hp_Count_Text;
        hpCountText = Instantiate<Text>(hpCountobj);
        hpCountText.transform.position = Camera.main.WorldToScreenPoint(hppos.transform.position);
        hpCountText.transform.SetParent(HudManager.Inst.Chracter_Hp_Parent);

        // hpbar에 HP프리팹의 이미지 적용 후 빈 게임오브젝트의 위치 적용
        hpbar.transform.position = Camera.main.WorldToScreenPoint(hppos.transform.position);
        hpbar.gameObject.SetActive(true);

     
    }



    /******************************************************************/

    private void Awake()
    {

        if (inst == null)
            inst = this;

        foreach(MonsterInfo one in GameManager.Inst.MONSTERINFO)
        {
            if (one.name.Equals(gameObject.name))
            {
                name = one.name;
                level = one.level;
                autoattack = one.autoattack;
                maxhp = one.maxhp;
                hp = one.hp;
                power = one.power;
                exp = one.exp;

          
            }
        }
        
        
    }

    void Start()
    {

        
            
        CreateHpbar();

        // 부활할때 이펙트 추가

        GameObject spawnEffect = Resources.Load<GameObject>("Use/Effect/MobSpawn");
        spawnEffectobj = Instantiate<GameObject>(spawnEffect);
        spawnEffectobj.transform.SetParent(gameObject.transform);
        Vector3 spawnPos = gameObject.transform.position;
        spawnPos.y += 0.5f;
        spawnEffectobj.transform.position = spawnPos;
        
    }

    void Update()
    { 
   
        hpbar.transform.position = Camera.main.WorldToScreenPoint(hppos.transform.position);
        hpbar.fillAmount = hp / maxhp;

        hpCountText.transform.position = Camera.main.WorldToScreenPoint(hppos.transform.position);
        hpCountText.transform.position += new Vector3(0, 12, 0);


        dis = Vector3.Distance(GameManager.Inst.PLAYER.transform.position, transform.position);
    }


}
