using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iTweenCamera : MonoBehaviour
{
    public Transform target;

    // Start is called before the first frame update
    void Start()
    {
        iTween.MoveTo(this.gameObject, iTween.Hash(
          "path", iTweenPath.GetPath("CameraPath"),
          "easeType", "easeInSine",       // ī�޶��� ������ ���� (easeType ������Ƽ Ȯ��)
          "looktarget", target.position,  // ī�޶� �ٶ󺸴� Ÿ��
          "lookTime", 0.1f,                // �ٶ󺸴� �ð�(updet��)
          "time", 6.4f,                    // ī�޶��� �� �̵� �ð�
          "oncomplete", "MoveComplete")         // ������ �̵��� �Լ� ���
          );
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
