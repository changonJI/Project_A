using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class JoyStickManager : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    static public JoyStickManager inst = null;

    public Image back;
    public Image stick;

    Vector3 centerpos = Vector3.zero;
    Vector3 dir = Vector3.zero;
    
    float radius = 0f;
    float quarter = 0f;
    float oneten = 0f;

    float moveSpeed = 0f;

    bool OnJoyStick = false;

    public float MOVESPEED
    {
        get { return moveSpeed; }
        set { moveSpeed = value; }
    }

    public Vector3 DIR
    {
        get { return dir.normalized; }
    }

    public bool ONJOYSTICK
    {
        get { return OnJoyStick; }
    }

    

    void Awake()
    {
        if (inst == null)
            inst = this;
    }

    void Start()
    {
        centerpos = stick.transform.position;
        radius = back.rectTransform.sizeDelta.x * 0.5f;

        quarter = back.rectTransform.sizeDelta.x * 0.25f;
        oneten = back.rectTransform.sizeDelta.x * 0.1f;
        
    }


    public void OnBeginDrag(PointerEventData ped)
    {
        stick.transform.position = centerpos;
        
    }

    public void OnDrag(PointerEventData ped)
    {

        OnJoyStick = true;
       
        Vector3 tmp = ped.position;
       
        float dis = Vector2.Distance(ped.position, centerpos);
        dir = tmp - centerpos;

        if (dis > radius)
        {

            stick.transform.position = centerpos + dir.normalized * radius;

        }
        else
        {
            stick.transform.position = tmp;
        }

        moveSpeed = dis > quarter ? 3f : 2f;
        
        if (dis < oneten)
        {
            dir = Vector3.zero;
            moveSpeed = 0f;
        }
        
        
    }

    public void OnEndDrag(PointerEventData ped)
    {
        
        stick.transform.position = centerpos;
        dir = Vector3.zero;


        if (GameManager.Inst.PLAYER != null)
        {
            GameManager.Inst.PLAYER.VEND = GameManager.Inst.PLAYER.transform.position;    
        }

        OnJoyStick = false;

    }

  

}
