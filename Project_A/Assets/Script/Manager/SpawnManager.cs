using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{



    /*******************************변수*******************************/

    public static SpawnManager inst = null;
    public Transform parent = null;
    
    //GameObject minimap;

    /******************************************************************/




    /*******************************함수*******************************/


    public IEnumerator CreatePlayer()
    {

        yield return null;

        if (LoadManager.Instant.rsPLAYER != null)
        {
            
            GameObject obj = Instantiate<GameObject>(LoadManager.Instant.rsPLAYER);
            

            Vector3? checkYPos = GameHelper.Instant.GetYPos(obj.transform.position, 6);
            if (checkYPos.HasValue)
            {
                obj.transform.position = checkYPos.Value;
            }
           
            obj.name = "Player";
            obj.transform.SetParent(parent);
               
            GameManager.Inst.PLAYER = obj.AddComponent<Player>();

            obj.transform.position = new Vector3(GameManager.Inst.PLAYERINFO.posx, GameManager.Inst.PLAYERINFO.posy, GameManager.Inst.PLAYERINFO.posz);


            CustomCamera cam = Camera.main.gameObject.AddComponent<CustomCamera>();
            GameObject minimap = Instantiate<GameObject>(Resources.Load<GameObject>("MinimapCamera"));
            minimap.name = "minimap";
            minimap.AddComponent<MiniMap>();
        }



    }

    /******************************************************************/


    private void Awake()
    {
        if (inst == null)
            inst = this;

        LoadManager.Instant.LoadPlayer();
    }


    void Start()
    {
        StartCoroutine(CreatePlayer());
    }

    

    
}
