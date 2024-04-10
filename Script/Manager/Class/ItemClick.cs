using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemClick : MonoBehaviour,IPointerDownHandler
{
    ItemData slotItem = new ItemData();

    public void OnPointerDown(PointerEventData _pointEventData)
    {
        
        // 누른 아이템의 정보 가져오기
        for(int i = 0; i < GameManager.Inst.PLAYER.PLAYERINVEN.Count; i++)
        {
            if ((i+1).ToString().Equals(transform.name))
            {
                slotItem = GameManager.Inst.PLAYER.PLAYERINVEN[i];
                break;
            }
        }

      
        // 아이템의 index(0 : 장비, 1 : 소모품, 2 : 기타) 에 따른 Active 설정
        switch (slotItem.index)
        {

            // 장비

            case 0 :
                // Index값 별 부위에 장착하기
                // 0 : 모자 , 1 : 옷 , 2 : 신발, 3 : 무기, 4 : 방패
                string[] equipNum = slotItem.itemName.Split('_');

                switch (int.Parse(equipNum[0])) 
                {
                    case 0 :
                        if (GameManager.Inst.PLAYER.EQUIPHEAD == 0)
                        {
                            GameManager.Inst.PLAYER.EQUIPHEAD = 1;
                            GameManager.Inst.PLAYER.EQUIPITEM.Add(slotItem);

                            GameManager.Inst.PLAYER.PLAYERMAXHP += slotItem.itemHp;


                            string[] rsName = slotItem.itemRsName.Split('_');
                            HudManager.Inst.UI_Inven_Equipment[0].sprite
                                = Resources.Load<Sprite>("Use/ItemImage/" + rsName[1]);

                            HudManager.Inst.Inven_stat_hp_text.text = 
                                GameManager.Inst.PLAYER.PLAYERMAXHP.ToString();
                        }
                        else
                            Debug.Log("장착중인 장비가 있습니다.");

                        break;

                    case 1:
                        if (GameManager.Inst.PLAYER.EQUIPBODY == 0)
                        {
                            GameManager.Inst.PLAYER.EQUIPBODY = 1;
                            GameManager.Inst.PLAYER.EQUIPITEM.Add(slotItem);

                            GameManager.Inst.PLAYER.PLAYERMAXHP += slotItem.itemHp;

                            string[] rsName = slotItem.itemRsName.Split('_');
                            HudManager.Inst.UI_Inven_Equipment[1].sprite
                                = Resources.Load<Sprite>("Use/ItemImage/" + rsName[1]);

                            HudManager.Inst.Inven_stat_hp_text.text =
                               GameManager.Inst.PLAYER.PLAYERMAXHP.ToString();
                        }
                        else
                            Debug.Log("장착중인 장비가 있습니다.");

                        break;

                    case 2:
                        if (GameManager.Inst.PLAYER.EQUIPFOOT == 0)
                        {
                            GameManager.Inst.PLAYER.EQUIPFOOT = 1;
                            GameManager.Inst.PLAYER.EQUIPITEM.Add(slotItem);

                            GameManager.Inst.PLAYER.PLAYERMAXHP += slotItem.itemHp;

                            string[] rsName = slotItem.itemRsName.Split('_');
                            HudManager.Inst.UI_Inven_Equipment[2].sprite
                                = Resources.Load<Sprite>("Use/ItemImage/" + rsName[1]);

                            HudManager.Inst.Inven_stat_hp_text.text =
                               GameManager.Inst.PLAYER.PLAYERMAXHP.ToString();
                        }
                        else
                            Debug.Log("장착중인 장비가 있습니다.");

                        break;

                    case 3:
                        if (GameManager.Inst.PLAYER.EQUIPWEAPON == 0 )
                        {
                            GameManager.Inst.PLAYER.EQUIPWEAPON = 1;
                            GameManager.Inst.PLAYER.EQUIPITEM.Add(slotItem);

                            GameManager.Inst.PLAYER.PLAYERPOWER += slotItem.itemPower;

                            string[] rsName = slotItem.itemRsName.Split('_');
                            HudManager.Inst.UI_Inven_Equipment[3].sprite
                                = Resources.Load<Sprite>("Use/ItemImage/" + rsName[1]);

                            HudManager.Inst.Inven_stat_power_text.text = 
                                GameManager.Inst.PLAYER.PLAYERPOWER.ToString();
                        }
                        else
                            Debug.Log("장착중인 장비가 있습니다.");

                        break;

                    case 4:
                        if (GameManager.Inst.PLAYER.EQUIPSHIELD == 0)
                        {
                            GameManager.Inst.PLAYER.EQUIPSHIELD = 1;
                            GameManager.Inst.PLAYER.EQUIPITEM.Add(slotItem);

                            GameManager.Inst.PLAYER.PLAYERMAXHP += slotItem.itemHp;

                            string[] rsName = slotItem.itemRsName.Split('_');
                            HudManager.Inst.UI_Inven_Equipment[4].sprite
                                = Resources.Load<Sprite>("Use/ItemImage/" + rsName[1]);

                            HudManager.Inst.Inven_stat_hp_text.text =
                               GameManager.Inst.PLAYER.PLAYERMAXHP.ToString();
                        }
                        else
                            Debug.Log("장착중인 장비가 있습니다.");

                        break;
                }
                break;


                // 소모품

            case 1: 
                
                GameManager.Inst.PLAYER.PLAYERHP += slotItem.itemHp;
                if(GameManager.Inst.PLAYER.PLAYERHP > GameManager.Inst.PLAYER.PLAYERMAXHP) 
                {
                    GameManager.Inst.PLAYER.PLAYERHP = GameManager.Inst.PLAYER.PLAYERMAXHP;
                }

                for (int i = 0; i < GameManager.Inst.PLAYER.PLAYERINVEN.Count; i++)
                {
                    if ((i + 1).ToString().Equals(transform.name))
                    {
                        GameManager.Inst.PLAYER.PLAYERINVEN.Remove(GameManager.Inst.PLAYER.PLAYERINVEN[i]);
                        HudManager.Inst.UI_Inven_Slot[i].gameObject.SetActive(false);
                        break;
                    }
                }
                break;

                // 기타
            case 2:
                Debug.Log("아이템 정보  = " + slotItem.itemInfo);
                break;

        }
        
    }

}
