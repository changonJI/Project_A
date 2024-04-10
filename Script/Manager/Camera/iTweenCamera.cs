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
          "easeType", "easeInSine",       // 카메라의 움직임 설정 (easeType 프로퍼티 확인)
          "looktarget", target.position,  // 카메라가 바라보는 타겟
          "lookTime", 0.1f,                // 바라보는 시간(updet됨)
          "time", 6.4f,                    // 카메라의 총 이동 시간
          "oncomplete", "MoveComplete")         // 끝까지 이동후 함수 출력
          );
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
