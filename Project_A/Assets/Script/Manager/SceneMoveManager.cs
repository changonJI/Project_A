using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMoveManager : MonoBehaviour
{

    /*******************************변수********************************/
    static public SceneMoveManager inst = null;
    
    /******************************************************************/

    /*******************************함수********************************/

    public void sceneMove(string sceneName)
    {
        

        switch (sceneName) 
        {

            case "Village":

                SceneManager.LoadScene(sceneName);
                HudManager.Inst.endSceneImage.gameObject.SetActive(true);
                GameManager.Inst.PLAYER.transform.position = new Vector3(25.2f, 0, 2.42f);
                GameManager.Inst.PLAYER.PLAYERSCENE = sceneName;
                HudManager.Inst.saveData();
                break;

            case "SouthForest":

                SceneManager.LoadScene(sceneName);
                HudManager.Inst.endSceneImage.gameObject.SetActive(true);
                GameManager.Inst.PLAYER.transform.position = new Vector3(-8.69f, 0, 32.98f);
                GameManager.Inst.PLAYER.PLAYERSCENE = sceneName;
                HudManager.Inst.saveData();
                break;

            case "SouthForest_Dungeon":

                SceneManager.LoadScene(sceneName);
                HudManager.Inst.endSceneImage.gameObject.SetActive(true);
                GameManager.Inst.PLAYER.transform.position = new Vector3(-2.26f, 0.32f, -12.11f);
                GameManager.Inst.PLAYER.PLAYERSCENE = sceneName;
                HudManager.Inst.saveData();
                break;

            case "SouthForest_Dungeon_Door":

                SceneManager.LoadScene("SouthForest");
                HudManager.Inst.endSceneImage.gameObject.SetActive(true);
                GameManager.Inst.PLAYER.transform.position = new Vector3(5.11f, 0f, -26.77f);
                GameManager.Inst.PLAYER.PLAYERSCENE = "SouthForest";
                HudManager.Inst.saveData();
                break;


        }




    }


    /******************************************************************/

    private void Awake()
    {
        if (inst == null)
            inst = this;
    }

}
    

