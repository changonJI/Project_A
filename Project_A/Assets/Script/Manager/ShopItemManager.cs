using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopItemManager : MonoBehaviour
{
    public Image ItemImage;
    public Text ItemName;
    public Text ItemInfo;
    public Text ItemPrice_text;
    public Button ShopBuyButton;

    public void BuyAction()
    {
        ItemData buyItem = new ItemData();

        if (GameManager.Inst.PLAYER.PLAYERINVEN.Count < 12 &&
            GameManager.Inst.PLAYER.PLAYERMONEY > int.Parse(ItemPrice_text.text))
        {
            GameManager.Inst.PLAYER.PLAYERMONEY -= int.Parse(ItemPrice_text.text);
            

            // 아이템 검사
            foreach (ItemData one in ItemManager.inst.RETURNITEMDATA)
            {
                if(one.itemInfo.Equals(ItemName.text))
                {
                    buyItem = one;
                }
            }
      
            GameManager.Inst.PLAYER.PLAYERINVEN.Add(buyItem);


            if (GameManager.Inst.PLAYER.PLAYERINVEN.Count > 0)
            {
                for (int i = 0; i < GameManager.Inst.PLAYER.PLAYERINVEN.Count; i++)
                {
                    string[] itemRsName = GameManager.Inst.PLAYER.PLAYERINVEN[i].itemRsName.Split('_');
                    HudManager.Inst.UI_Inven_Slot[i].sprite =
                        Resources.Load<Sprite>("Use/ItemImage/" + itemRsName[1]);
                    HudManager.Inst.UI_Inven_Slot[i].gameObject.SetActive(true);

                }
            }
        }
        else
        {
            Debug.Log("돈이 부족합니다."); // UI 띄우기
        }
    }
    
}
