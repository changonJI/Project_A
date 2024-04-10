using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class SaveManager : SingleTon<SaveManager>
{
    public void SavePlayer()
    {
        string datas = string.Empty;

        using (StreamWriter sw = new StreamWriter(Application.dataPath + "/" + "PlayerData.csv"))
        {

            sw.WriteLine("name,level,hp,maxHp,power,exp,money,scene,posx,posy,posz,rotx,roty,rotz,scalex,scaley,scalez,head,body,foot,weapon,shield");

            datas = GameManager.Inst.PLAYER.name;
            datas += ',';
            datas += GameManager.Inst.PLAYER.PLAYERLEVEL;
            datas += ',';
            datas += GameManager.Inst.PLAYER.PLAYERHP;
            datas += ',';
            datas += GameManager.Inst.PLAYER.PLAYERMAXHP;
            datas += ',';
            datas += GameManager.Inst.PLAYER.PLAYERPOWER;
            datas += ',';
            datas += GameManager.Inst.PLAYER.PLAYEREXP;
            datas += ',';
            datas += GameManager.Inst.PLAYER.PLAYERMONEY;
            datas += ',';

            datas += GameManager.Inst.PLAYER.PLAYERSCENE;
            datas += ',';
            datas += GameManager.Inst.PLAYER.gameObject.transform.position.x;
            datas += ',';
            datas += GameManager.Inst.PLAYER.gameObject.transform.position.y;
            datas += ',';
            datas += GameManager.Inst.PLAYER.gameObject.transform.position.z;
            datas += ',';

            datas += GameManager.Inst.PLAYER.gameObject.transform.rotation.x;
            datas += ',';
            datas += GameManager.Inst.PLAYER.gameObject.transform.rotation.y;
            datas += ',';
            datas += GameManager.Inst.PLAYER.gameObject.transform.rotation.z;
            datas += ',';

            datas += GameManager.Inst.PLAYER.gameObject.transform.localScale.x;
            datas += ',';
            datas += GameManager.Inst.PLAYER.gameObject.transform.localScale.y;
            datas += ',';
            datas += GameManager.Inst.PLAYER.gameObject.transform.localScale.z;

            datas += ',';
            datas += GameManager.Inst.PLAYER.EQUIPHEAD.ToString();
            datas += ',';
            datas += GameManager.Inst.PLAYER.EQUIPBODY.ToString();
            datas += ',';
            datas += GameManager.Inst.PLAYER.EQUIPFOOT.ToString();
            datas += ',';
            datas += GameManager.Inst.PLAYER.EQUIPWEAPON.ToString();
            datas += ',';
            datas += GameManager.Inst.PLAYER.EQUIPSHIELD.ToString();

            sw.WriteLine(datas);
            datas = string.Empty;

            sw.Close();
        }
    }
    public void SavePlayerEquipment()
    {

        string datas = string.Empty;

        using (StreamWriter sw = new StreamWriter(Application.dataPath + "/" + "PlayerEquipData.csv"))
        {
            sw.WriteLine("index,name,rsName,info,price,power,hp");

            for (int i = 0; i < GameManager.Inst.PLAYER.EQUIPITEM.Count; i++)
            {
                datas = GameManager.Inst.PLAYER.EQUIPITEM[i].index.ToString();
                datas += ',';
                datas += GameManager.Inst.PLAYER.EQUIPITEM[i].itemName;
                datas += ',';
                datas += GameManager.Inst.PLAYER.EQUIPITEM[i].itemRsName;
                datas += ',';
                datas += GameManager.Inst.PLAYER.EQUIPITEM[i].itemInfo;
                datas += ',';
                datas += GameManager.Inst.PLAYER.EQUIPITEM[i].itemPrice;
                datas += ',';
                datas += GameManager.Inst.PLAYER.EQUIPITEM[i].itemPower;
                datas += ',';
                datas += GameManager.Inst.PLAYER.EQUIPITEM[i].itemHp;


                sw.WriteLine(datas);
                datas = string.Empty;
            }

            sw.Close();
        }
    }

    public void SavePlayerInven()
    {

        string datas = string.Empty;

        using (StreamWriter sw = new StreamWriter(Application.dataPath + "/" + "PlayerInvenData.csv"))
        {
       
            sw.WriteLine("index,itemName,itemRsName,itemInfo,itemPrice,itemPower,itemHp");

            for (int i = 0; i < GameManager.Inst.PLAYER.PLAYERINVEN.Count; i++)
            {
                datas = GameManager.Inst.PLAYER.PLAYERINVEN[i].index.ToString();
                datas += ',';
                datas += GameManager.Inst.PLAYER.PLAYERINVEN[i].itemName;
                datas += ',';
                datas += GameManager.Inst.PLAYER.PLAYERINVEN[i].itemRsName;
                datas += ',';
                datas += GameManager.Inst.PLAYER.PLAYERINVEN[i].itemInfo;
                datas += ',';
                datas += GameManager.Inst.PLAYER.PLAYERINVEN[i].itemPrice;
                datas += ',';
                datas += GameManager.Inst.PLAYER.PLAYERINVEN[i].itemPower;
                datas += ',';
                datas += GameManager.Inst.PLAYER.PLAYERINVEN[i].itemHp;

                
                sw.WriteLine(datas);
                datas = string.Empty;
            }

            sw.Close();
        }
    }


    public void SaveNpcQuestData()
    {
        List<NPC> npclist = GameManager.Inst.NPC;
        if (npclist.Count <= 0)
        {
            Debug.Log("NPC ¾øÀ½");
            return;
        }

        using (StreamWriter sw = new StreamWriter(Application.dataPath + "/" + "NPCQuestData.csv",false,System.Text.Encoding.UTF8))
        {

            string datas = string.Empty;

            sw.WriteLine("index,rsname,questNum");

            for (int i = 0; i < npclist.Count; i++)
            {
                datas = (0 + i).ToString();
                datas += ',';      

                datas += npclist[i].gameObject.name;
                datas += ',';

                datas += npclist[i].QUESTNUM;


                sw.WriteLine(datas);
                datas = string.Empty;
            }

            sw.Close();
        }
    }


    public void SavePlayerQuestData()
    {
        
        List<QuestData> questData = GameManager.Inst.PLAYER.PLAYERQUEST;

        using (StreamWriter sw = new StreamWriter(Application.dataPath + "/" + "PlayerQuestData.csv"))
        {
            string data = string.Empty;
            sw.WriteLine("index,npcId,questID,rewardExp,questName,questTalk,targetName,targetScore,targetScoremin");

            for (int i = 0; i < questData.Count; i++)
            {
                data = (0 + i).ToString();
                data += ',';
                data += questData[i].npcId;
                data += ',';
                data += questData[i].questID;
                data += ',';
                data += questData[i].rewardExp;
                data += ',';
                data += questData[i].questName;
                data += ',';
                data += questData[i].questTalk;
                data += ',';
                data += questData[i].targetName;
                data += ',';
                data += questData[i].targetScore.ToString();
                data += ',';
                data += questData[i].targetScoremin.ToString();

                sw.WriteLine(data);
                data = string.Empty;
            }

            sw.Close();
        }

    }


}
