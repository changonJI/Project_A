using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class QuestManager : MonoBehaviour
{

    public static QuestManager inst = null;

    Multimap<int, QuestData> QuestDic = new Multimap<int, QuestData>();

    public void QuestList()
    {

        //퀘스트 키값, 퀘스트 내용
        // NPC를 누를시 ID값을 가져 온다.
        QuestDic.AddData(0, new QuestData(0,0,"", null));

        // 1 상인
        QuestDic.AddData(1, new QuestData(1,0,"base","좋은 상품이 많다네")); // 기본 말투
        QuestDic.AddData(1, new QuestData(1,1,"시작",50 , "어이 거기 ! 잠깐 이쪽으로 와보게나"));
        QuestDic.AddData(1, new QuestData(1,2,"상인의 부탁 1", 100,
            "토끼고기를 납품해야하는데 좀 도와주게나. 남쪽숲에 가서 토끼고기 5개만 구해다 주면 된다네.", "Rabbit", 5));

        QuestDic.AddData(1, new QuestData(1,3,"상인의 부탁 2",120,
            "고맙구만 ! 이제보니 자네 사냥꾼이었구만 ! 남쪽에 호랑이가 많아졌다고 하는데 호랑이도 좀 잡아주겠나?", "Tiger",2));

        QuestDic.AddData(1, new QuestData(1,4,"상인의 부탁 3", 200,
            "역시 해낼줄 알았네 ! 호랑이가 많아진걸보니 남쪽숲에 무슨일이 있는거 같네. 남쪽 숲에 끝에있는 큰 바위 근처를 조사해주게나","Golem", 1));
        QuestDic.AddData(1, new QuestData(1,5, "상인의 부탁 완", 200,
            "남쪽 숲에 그런 일이 발생하다니.. 큰일이구만..",null,0));

        // 수정 전
        // 2. 대장장이
        QuestDic.AddData(2, new QuestData(2,0,"base",  "전장에 나갈때는 든든하게 입어야 한다네" ));
        QuestDic.AddData(2, new QuestData(2,1,"대장장이 모팔모_1", "그 양반한테 또 사기를 당했나보구만요새 남쪽숲이 흉흉하단 말이야."));
        QuestDic.AddData(2, new QuestData(2,2,"대장장이 모팔모_2",
            "요즘 남쪽숲에 호랑이들이 득실거려서 사냥이 전보다 어려워 졌다네..혹시 자네 호랑이들을 잡아줄수 있겠나?"));
        QuestDic.AddData(2, new QuestData(2,3,"대장장이 모팔모_완",
         "음... 이빨이 많이 상해있네.. 이건 누군가와 싸웠다는 소리인데..자네때문은 아닌거같고 남쪽숲에 무슨일이 생긴 모양이야 권율 장군한테 한번 가보겠나?" ));


        // 3. 장군
        QuestDic.AddData(3, new QuestData(3,0,"base", "충 ! 성 !"));
        QuestDic.AddData(3, new QuestData(3,1,"장군 권율_1","...그런 일이 있었단 말이지..고맙네."));
        QuestDic.AddData(3, new QuestData(3,2,"장군 권율_2","남쪽 숲을 조사해줄수 있겠나? 훈련된 병사를 지원해주겠네"));
        QuestDic.AddData(3, new QuestData(3,3,"장군 권율_완",
          "숲 안쪽에 그런게 존재하다니.. 그래서 호랑이들이 그렇게 많은거였어 이 일은 그냥 넘어갈 일이 아닌거같군 전하께 이 사실을 전달해주게"));
    }

    public List<QuestData> getQuest(int _ID)
    {
        return QuestDic.GetData(_ID);
    }


    private void Awake()
    {
        if (inst == null)
            inst = this;

        QuestList();
    }
    
}
