using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using UnityEngine.SceneManagement;

public class CustomMenu
{
    //static List<string> Buildinglist = new List<string>();
    static string filename = string.Empty;



    [MenuItem("CustomMenu/SavePlayer")]
    static void SavePlayer()
    {
        Debug.Log("SavePlayer 누름");

        filename = EditorUtility.SaveFilePanel("Save", "", filename, "csv");
        Debug.Log(filename);


        if (filename == null &&
           filename == "")
        {
            Debug.Log("이름을 입력해주세요.");
            return;
        }

        GameObject obj = GameObject.FindGameObjectWithTag("Player");
        if(obj == null)
        {
            Debug.Log("Player가 없음");
            return;
        }

        string datas = string.Empty;

        using (StreamWriter sw = new StreamWriter(filename))
        {

            sw.WriteLine("name,level,hp,maxHp,power,exp,scene,posx,posy,posz,rotx,roty,rotz,scalex,scaley,scalez");
            
            datas = GameManager.Inst.PLAYER.name;
            datas += ",";
            datas += GameManager.Inst.PLAYER.PLAYERLEVEL;
            datas += ",";
            datas += GameManager.Inst.PLAYER.PLAYERHP;
            datas += ",";
            datas += GameManager.Inst.PLAYER.PLAYERMAXHP;
            datas += ",";
            datas += GameManager.Inst.PLAYER.PLAYERPOWER;
            datas += ",";
            datas += GameManager.Inst.PLAYER.PLAYEREXP;
            datas += ",";


            datas += GameManager.Inst.PLAYER.PLAYERSCENE;
            datas += ",";
            datas += GameManager.Inst.PLAYER.gameObject.transform.position.x;
            datas += ",";
            datas += GameManager.Inst.PLAYER.gameObject.transform.position.y;
            datas += ",";
            datas += GameManager.Inst.PLAYER.gameObject.transform.position.z;
            datas += ",";

            datas += GameManager.Inst.PLAYER.gameObject.transform.rotation.x;
            datas += ",";
            datas += GameManager.Inst.PLAYER.gameObject.transform.rotation.y;
            datas += ",";
            datas += GameManager.Inst.PLAYER.gameObject.transform.rotation.z;
            datas += ",";

            datas += GameManager.Inst.PLAYER.gameObject.transform.localScale.x;
            datas += ",";
            datas += GameManager.Inst.PLAYER.gameObject.transform.localScale.y;
            datas += ",";
            datas += GameManager.Inst.PLAYER.gameObject.transform.localScale.z;

            sw.WriteLine(datas);
            datas = string.Empty;

            sw.Close();
        }

        filename = string.Empty;
        
    }


    [MenuItem("CustomMenu/SaveNpc")]
    static void SaveNpc()
    {
        filename = EditorUtility.SaveFilePanel("Save", "", filename, "csv");

        if (filename.Equals("") &&
            filename == null)
        {
            Debug.Log("이름을 입력하세요");
        }

        GameObject [] objs = GameObject.FindGameObjectsWithTag("NPC");
        if(objs.Length <= 0)
        {
            Debug.Log("게임오브젝트 없음");
            return;
        }

        using(StreamWriter sw = new StreamWriter(filename))
        {

            string datas = string.Empty;

            sw.WriteLine("ID,name,rsname,scene,posx,posy,posz,rotx,roty,rotz,scalex,scaley,scalez");

            for(int i = 0; i < objs.Length; i++)
            {
                datas = (i + 1).ToString();
                datas += ",";

                datas += objs[i].name;
                datas += ",";
                datas += objs[i].name;
                datas += ",";

                datas += SceneManager.GetActiveScene().name;
                datas += ",";

                datas += objs[i].transform.position.x;
                datas += ",";
                datas += objs[i].transform.position.y;
                datas += ",";
                datas += objs[i].transform.position.z;
                datas += ",";

                datas += objs[i].transform.eulerAngles.x;
                datas += ",";
                datas += objs[i].transform.eulerAngles.y;
                datas += ",";
                datas += objs[i].transform.eulerAngles.z;
                datas += ",";

                datas += objs[i].transform.localScale.x;
                datas += ",";
                datas += objs[i].transform.localScale.y;
                datas += ",";
                datas += objs[i].transform.localScale.z;


                sw.WriteLine(datas);
                datas = string.Empty;
            }

            sw.Close();
        }

        filename = string.Empty;
    }

    /*********************************************************************************************************************/

    [MenuItem("CustomMenu/SaveBuilding")]
    static void SaveBuilding()
    {

        Debug.Log("SaveBuilding 누름");


        /*filename = EditorUtility.SaveFilePanel("Save", "", filename, "csv");
        if (filename.Equals(""))
        {
            Debug.Log("이름을 입력해주세요.");
            return;
        }*/


        GameObject[] objs = GameObject.FindGameObjectsWithTag("Building");
        if (objs.Length <= 0)
        {
            Debug.Log("Building Tag의 게임오브젝트가 없음");
            return;
        }

        GameObject[] bgobjs = GameObject.FindGameObjectsWithTag("BackGround");
        if (objs.Length <= 0)
        {
            Debug.Log("BackGround Tag의 게임오브젝트가 없음");
            return;
        }


        string datas = string.Empty;

        using (StreamWriter sw = new StreamWriter(Application.dataPath + "/" + "BuildingData.csv"))
        {
            sw.WriteLine("index,scenename,name,tag,posx,posy,posz,rotx,roty,rotz,scalex,scaley,scalez");

            for(int i=0; i<objs.Length; i++)
            {
                datas = (i + 1).ToString();
                datas += ",";

                datas += SceneManager.GetActiveScene().name;
                datas += ",";
                
                datas += "Building";
                datas += ",";

                datas += objs[i].name;
                datas += ",";

                datas += objs[i].transform.position.x;
                datas += ",";
                datas += objs[i].transform.position.y;
                datas += ",";
                datas += objs[i].transform.position.z;
                datas += ",";

                datas += objs[i].transform.eulerAngles.x;
                datas += ",";
                datas += objs[i].transform.eulerAngles.y;
                datas += ",";
                datas += objs[i].transform.eulerAngles.z;
                datas += ",";

                datas += objs[i].transform.localScale.x;
                datas += ",";
                datas += objs[i].transform.localScale.y;
                datas += ",";
                datas += objs[i].transform.localScale.z;
                

                sw.WriteLine(datas);
                datas = string.Empty;
            }

            for (int i = 0; i < bgobjs.Length; i++)
            {
                datas = (i + 1).ToString();
                datas += ",";

                datas += SceneManager.GetActiveScene().name;
                datas += ",";

                datas += "BackGround";
                datas += ",";

                datas += bgobjs[i].name;
                datas += ",";

                datas += bgobjs[i].transform.position.x;
                datas += ",";
                datas += bgobjs[i].transform.position.y;
                datas += ",";
                datas += bgobjs[i].transform.position.z;
                datas += ",";

                datas += bgobjs[i].transform.eulerAngles.x;
                datas += ",";
                datas += bgobjs[i].transform.eulerAngles.y;
                datas += ",";
                datas += bgobjs[i].transform.eulerAngles.z;
                datas += ",";

                datas += bgobjs[i].transform.localScale.x;
                datas += ",";
                datas += bgobjs[i].transform.localScale.y;
                datas += ",";
                datas += bgobjs[i].transform.localScale.z;
                



                sw.WriteLine(datas);
                datas = string.Empty;
            }

            sw.Close();
        }

        

        //filename = string.Empty;
    }
    
   

}
