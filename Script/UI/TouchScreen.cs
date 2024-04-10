using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class TouchScreen : MonoBehaviour, IPointerDownHandler
{
    
public void OnPointerDown(PointerEventData p)
    {
        Debug.Log(p.position);
       
     
    }
}
