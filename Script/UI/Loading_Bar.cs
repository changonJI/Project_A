using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Loading_Bar : MonoBehaviour
{
    Image LoadingBar;
    float sumTime = 0f;

    
    void Start()
    {
        LoadingBar = HudManager.Inst.Loading_Bar;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        sumTime += Time.deltaTime;
        LoadingBar.fillAmount = sumTime / 3f;
        if (sumTime >= 3f)
        {
            sumTime = 0f;   
            gameObject.SetActive(false);
        }
    }
}
