using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap : MonoBehaviour
{
    Vector3 campos = new Vector3(0, 49, 0);


    private void Start()
    {
        transform.position = campos;
    }



    private void LateUpdate()
    {
        transform.position = GameManager.Inst.PLAYER.transform.position + campos;
    }
}
