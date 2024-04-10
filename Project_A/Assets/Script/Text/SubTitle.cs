using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class SubTitle : MonoBehaviour, IPointerDownHandler
{

    public void OnPointerDown(PointerEventData data)
    {

        PlayerInfo player = LoadManager.Instant.LoadPlayerData();
        
        if(player.name == null)
        {
            player.name = "player";
            player.level = 1;
            player.hp = 150f;
            player.maxHp = 150f;
            player.power = 50f;
            player.exp = 0f;
            player.money = 0;
            player.scene = "Vilalge";
            player.posx = 24.99f;
            player.posy = 0f;
            player.posz = 22f;
            player.rotx = 0f;
            player.roty = 0f;
            player.rotz = 0f;
            player.scalex = 1f;
            player.scaley = 1f;
            player.scalez = 1f;

            SaveManager.Instant.SavePlayer();
        }

        SceneManager.LoadScene(player.scene);
        HudManager.Inst.endSceneImage.gameObject.SetActive(true);
    }
    
}
