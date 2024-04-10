using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHelper : SingleTon<GameHelper>
{
    /*******************************ÇÔ¼ö*******************************/

   
    public Vector3? GetYPos(Vector3 pos, int layerIndex)
     {

        Vector3 newPos = pos;
        newPos.y += 50f;

        RaycastHit hitInfo;
        
        int layerMask = 6 << layerIndex;
        layerMask = ~layerMask;

        if (Physics.Raycast(newPos, Vector3.down, out hitInfo, Mathf.Infinity, layerMask))
        {

            Debug.Log("hitinfo,point" + hitInfo.point);

            newPos.y = hitInfo.point.y;
            return newPos;
        }

        return null;
    }


    public Transform GetChildGameObject(Transform tr, string name)
    {
        if (tr.childCount != 0)
        {
            for (int i = 0; i < tr.childCount; i++)
            {
                Transform tmp = tr.GetChild(i);
                if (tmp.name == name)
                    return tmp;

                GetChildGameObject(tmp, name);
            }
        }

        return null;

    }

    public Transform GetChildGameObjectTag(Transform tr, string tagname)
    {

        if (tr.childCount != 0)
        {
            for (int i = 0; i < tr.childCount; i++)
            {
                Transform tmp = tr.GetChild(i);
                if (tmp.CompareTag(tagname))
                {
                    GetChildObjTag.Add(tmp);
                }
                GetChildGameObjectTag(tmp, tagname);
            }
        }
        return null;
    }

    public List<Transform> GetChildObjTag;


    /******************************************************************/
}
