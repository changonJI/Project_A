using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loading_Text : MonoBehaviour
{

    void Start()
    {
        StartCoroutine(textLoad());
    }

    IEnumerator textLoad()
    {
        string text = "...";
        char[] textchar = text.ToCharArray();

        for(int i =0; i < textchar.Length; i++)
        {
            HudManager.Inst.Loading_Text.text +=  textchar[i].ToString();
            yield return new WaitForSeconds(0.3f);

            if (i.Equals(textchar.Length - 1))
            {
                HudManager.Inst.Loading_Text.text = string.Empty;

                yield return new WaitForSeconds(0.3f);

                StartCoroutine(textLoad());
            }
        }  
    }
}
