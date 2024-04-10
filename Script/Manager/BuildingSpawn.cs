using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BuildingSpawn : MonoBehaviour
{
    
    void Start()
    {
        foreach(BuildingInfo one in GameManager.Inst.BUILDINGINFO)
        {
            if (SceneManager.GetActiveScene().name.Equals(one.sceneName))
            {
                if (one.tagName.Equals("Building"))
                {
                    GameObject rsobj = Resources.Load<GameObject>("Use/Building/" + one.rsName);
                    GameObject obj = Instantiate<GameObject>(rsobj);
                    obj.name = one.rsName;
                    obj.transform.position = new Vector3(one.posx, one.posy, one.posz);
                    obj.transform.eulerAngles = new Vector3(one.rotx, one.roty, one.rotz);
                    obj.transform.localScale = new Vector3(one.scalex, one.scaley, one.scalez);
                    obj.isStatic = true;
                    obj.transform.SetParent(GameObject.Find("Building").transform);
                }
                if (one.tagName.Equals("BackGround"))
                {
                    GameObject rsobj = Resources.Load<GameObject>("Use/BackGround/" + one.rsName);
                    GameObject obj = Instantiate<GameObject>(rsobj);
                    obj.name = one.rsName;
                    obj.transform.position = new Vector3(one.posx, one.posy, one.posz);
                    obj.transform.eulerAngles = new Vector3(one.rotx, one.roty, one.rotz);
                    obj.transform.localScale = new Vector3(one.scalex, one.scaley, one.scalez);
                    obj.isStatic = true;
                    obj.transform.SetParent(GameObject.Find("BackGround").transform);

                }

            }
        }
    }
}
