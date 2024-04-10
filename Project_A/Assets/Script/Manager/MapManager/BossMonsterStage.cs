using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossMonsterStage : MonoBehaviour
{
    public string bossName;
    public GameObject BossMonster_Hp_Bar;
    public Image BossMonster_Hp;
    public Text BossMonster_Hp_Text;

    Monster bossMonster;

    public Monster BossMonster(string _name)
    {
        if(GameManager.Inst.MONSTER != null)
        {
            foreach(Monster one in GameManager.Inst.MONSTER)
            {
                one.name = _name;

                BossMonster_Hp_Bar.SetActive(true);
                return one;
            }
        }

        return null;
    }

    void Update()
    {
        bossMonster = BossMonster(bossName);

        if (bossMonster != null)
        {
            BossMonster_Hp.fillAmount = bossMonster.MONSTERHP / bossMonster.MONSTERMAXHP;
            BossMonster_Hp_Text.text = bossMonster.MONSTERHP + "/" + bossMonster.MONSTERMAXHP;
        }

    }
}
