using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleTon<T> where T : class, new()    // 사용자 정의 데이터 타입 SingleTon<가져올 클래스 타입>,  T의 범위 = where T : class, new()  
{

    private static T Inst = null;                   // class의 객체 inst를 선언

    static public T Instant{
        get { 
            if (Inst == null)
            Inst = new T();                         // 현재 inst는 null값,  inst에 new T();로 해당 클래스를 static inst에 할당하여
                                                    // 정적 클래스로 변경한다. 
            return Inst;
        }

    }
}
