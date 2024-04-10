using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    Text NPCname;
    public Transform namepos;

    int id;
    string name;
    string tagName;
    int hasName;
    int questNum;

    List<QuestData> questList = new List<QuestData>();


    public int ID 
    {
        get { return id; }
        set { id = value; }
    }

    public string NAME
    {
        get { return name; }
        set { name = value; }
    }

    public string TAGNAME
    {
        get { return tagName; }
        set { tagName = value; }
    }


    public int QUESTNUM
    {
        get { return questNum; }
        set { questNum = value; }
    }

    public List<QuestData> QUESTLIST
    {
        get { return questList; }
        set { questList = value; }
    }

    private void Awake()
    {
        
        foreach(NpcInfo one in GameManager.Inst.NPCINFO)
        {
            if (one.rsName.Equals(gameObject.name))
            {
                id = one.ID;
                name = one.name;
                tagName = one.tagname;
                hasName = one.hasName;
                
            }
        }

        questList = QuestManager.inst.getQuest(id); // Äù½ºÆ® °¡Á®¿È

        foreach (NpcInfo one in GameManager.Inst.NPCQUESTDATA)
        {
            if (one.rsName.Equals(gameObject.name))
            {
                questNum = one.questNum;
            }
        }
    }

    private void Start()
    {
        //Debug.Log(gameObject.name + questNum.ToString());

        if (hasName > 0)
        {
            Text rsnametxt = HudManager.Inst.NPC_Name_Origin;

            NPCname = Instantiate<Text>(rsnametxt);

            NPCname.text = name + "\n" +
                "<color=#FEFF00>" + "<" + gameObject.tag + "> " + tagName + "</color>"; 

            NPCname.gameObject.transform.SetParent(HudManager.Inst.NPC_name_Parent);

            namepos = GameHelper.Instant.GetChildGameObject(transform, "Name");

            NPCname.gameObject.SetActive(true);

        }
                    
    }

    private void Update()
    {
        if(NPCname != null)
        NPCname.transform.position =
            Camera.main.WorldToScreenPoint(namepos.position);

    }

}
