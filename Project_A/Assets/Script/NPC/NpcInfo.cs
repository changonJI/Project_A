using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcInfo
{
    public int ID;              // npc�� ID
    public string name;         // ǥ�õ� �̸�
    public string tagname;      // ǥ�õ� ����
    public string rsName;       // �ν��Ͻ�ȭ �� ���ҽ� �̸�
    public string sceneName;    // �� üũ

    public float posx;          // ��ġ ��
    public float posy;
    public float posz;

    public float rotx;
    public float roty;
    public float rotz;

    public float scalex;
    public float scaley;
    public float scalez;

    public int hasName;         // �̸� ǥ�� 1 = true, 0 = false
    public int questNum;      //  NPC�� ����Ʈ ���� ��Ȳ // ����Ʈ Ŭ����� NPC questNum ������Ű��


}
