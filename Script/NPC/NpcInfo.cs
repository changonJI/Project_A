using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcInfo
{
    public int ID;              // npc별 ID
    public string name;         // 표시될 이름
    public string tagname;      // 표시될 직업
    public string rsName;       // 인스턴스화 할 리소스 이름
    public string sceneName;    // 신 체크

    public float posx;          // 위치 값
    public float posy;
    public float posz;

    public float rotx;
    public float roty;
    public float rotz;

    public float scalex;
    public float scaley;
    public float scalez;

    public int hasName;         // 이름 표시 1 = true, 0 = false
    public int questNum;      //  NPC별 퀘스트 현재 상황 // 퀘스트 클리어시 NPC questNum 증가시키기


}
