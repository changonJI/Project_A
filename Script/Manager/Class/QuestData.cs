using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestData
{
    public int index;

    public int npcId;
    public int questID;
    public string questName;
    public int rewardExp;
    public string questTalk;
    public string targetName;
    public int targetScore;
    public int targetScoremin = 0;

    public QuestData()
    {
    }

    public QuestData(int _npcId, int _questID, string _name,string _talk)
    {
        npcId = _npcId;
        questID = _questID;
        questName = _name;
        questTalk = _talk;
    }

    public QuestData(int _npcId, int _questID, string _name,int _exp ,string _talk)
    {
        npcId = _npcId;
        questID = _questID;
        questName = _name;
        rewardExp = _exp;
        questTalk = _talk;
    }

    public QuestData(int _npcId,int _questID, string _name, int _exp, string _talk, string _targetName)
    {
        npcId = _npcId;
        questID = _questID;
        questName = _name;
        rewardExp = _exp;
        questTalk = _talk;
        targetName = _targetName;
    }

    public QuestData(int _npcId, int _questID, string _name, int _exp, string _talk, string _targetName, int _targetScore)
    {
        npcId = _npcId;
        questID = _questID;
        questName = _name;
        rewardExp = _exp;
        questTalk = _talk;
        targetName = _targetName;
        targetScore = _targetScore;
    }
}
