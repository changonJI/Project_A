using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleTon<T> where T : class, new()    // ����� ���� ������ Ÿ�� SingleTon<������ Ŭ���� Ÿ��>,  T�� ���� = where T : class, new()  
{

    private static T Inst = null;                   // class�� ��ü inst�� ����

    static public T Instant{
        get { 
            if (Inst == null)
            Inst = new T();                         // ���� inst�� null��,  inst�� new T();�� �ش� Ŭ������ static inst�� �Ҵ��Ͽ�
                                                    // ���� Ŭ������ �����Ѵ�. 
            return Inst;
        }

    }
}
