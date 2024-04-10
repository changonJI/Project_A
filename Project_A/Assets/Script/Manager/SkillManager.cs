using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    static public SkillManager inst = null;

    Dictionary<string, SkillData> skillDic = new Dictionary<string, SkillData>();
    
    void skillList()
    {
        // player
        skillDic.Add("Skill_PowerAttack", new SkillData(3f, 30f));





        // BossMonster
        skillDic.Add("Golem_ThrowStone", new SkillData(0, 50f));
    }





    public SkillData getSkill(string skillname)
    {
        return skillDic[skillname];
    }


    private void Awake()
    {
        if (inst == null)
            inst = this;

        skillList();

        //Debug.Log(skillDic["Skill_PowerAttack"].skillPower);
    }

}
