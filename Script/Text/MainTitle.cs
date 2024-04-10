using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class MainTitle : MonoBehaviour
{
    public Text titleText;
    public Text subtitleText;
    Color color = Color.clear;


    void Fadein()
    {
        color = titleText.color;
        color.a += Time.deltaTime * 0.1f;
        titleText.color = color;

        if(titleText.color.a >= 1f)
        {
            CancelInvoke("Fadein");
            subtitleText.gameObject.SetActive(true);
        }
    }

    IEnumerator Start()
    {
        yield return null;

        InvokeRepeating("Fadein", 0, 0.01f); // 0초에 0.01초 간격으로 함수 호출
    }


}
