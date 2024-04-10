using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NameSet : MonoBehaviour
{

    Text NPCname;
    public Transform namepos;

    public void setName(string _name, string _color, string _tag)
    {
        Text rsnametxt = HudManager.Inst.NPC_Name_Origin;

        NPCname = Instantiate<Text>(rsnametxt);

        NPCname.text = _name + "\n" + "<color=" + _color + ">" + _tag + "</color>"; 

        NPCname.gameObject.transform.SetParent(HudManager.Inst.NPC_name_Parent);

        namepos = GameHelper.Instant.GetChildGameObject(transform, "Name");
     
        NPCname.gameObject.SetActive(true);
    }

    void Update()
    {
        NPCname.transform.position =
            Camera.main.WorldToScreenPoint(namepos.position);
    }
}
