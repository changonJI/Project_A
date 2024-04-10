using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NPCSpawn : MonoBehaviour
{

    public static NPCSpawn inst = null;

    private void Awake()
    {
        if(inst == null)
        {
            inst = this;
        }
    }

    void Start()
    {
        foreach(NpcInfo one in GameManager.Inst.NPCINFO)
        {
            if (SceneManager.GetActiveScene().name.Equals(one.sceneName))
            {
                GameObject tmp = Resources.Load<GameObject>("Use/NPC/" + one.rsName);
                GameObject obj = Instantiate<GameObject>(tmp);

                obj.name = one.rsName;

                obj.transform.position = new Vector3(one.posx, one.posy, one.posz);
                obj.transform.eulerAngles = new Vector3(one.rotx, one.roty, one.rotz);
                obj.transform.localScale = new Vector3(one.scalex, one.scaley, one.scalez);
                obj.transform.SetParent(GameObject.Find("NPC").transform);

                NPC npcscript = obj.AddComponent<NPC>();
                GameManager.Inst.NPC.Add(npcscript);

            }

        }
     
    }

}
