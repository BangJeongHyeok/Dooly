using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayNANOO;

public class PlayNanooManager : MonoBehaviour
{
    private Plugin plugin;

    private string _nickName = string.Empty;
    private int _score;
    private ArrayList list = new ArrayList();

    public void Init()
    {
        plugin = Plugin.GetInstance();
        SetUserInfo();
    }

    public void SetUserInfo()
    {
        plugin.SetUUID(SystemInfo.deviceUniqueIdentifier);
        plugin.SetNickname(_nickName);
        plugin.SetLanguage("Configure.PN_LANG_KO");
    }

    public void SetName(string name)
    {
        _nickName = name;
        plugin.SetNickname(_nickName);
    }

    public void SetScore(int score)
    {
        _score = score;
    }

    public void WriteRanking()
    {
        // 랭킹코드, 점수, 데이터
        plugin.RankingRecord("dooly-RANK-BC09F27A-99057B5A", _score, _nickName, (state, message, rawData, dictionary) =>
        {
            if (state.Equals(Configure.PN_API_STATE_SUCCESS))
            {
                Debug.Log("Success");
            }
            else
            {
                Debug.Log("Fail");
            }
        });
    }

    public void RequestRanking(Action<ArrayList> action)
    {
        // 랭킹코드, 몇개 까지 보이는지 (50개가 최대)
        plugin.Ranking("dooly-RANK-BC09F27A-99057B5A", 50, (state, message, rawData, dictionary) =>
        {
            if (state.Equals(Configure.PN_API_STATE_SUCCESS))
            {
                list = (ArrayList)dictionary["list"];
                action.Invoke(list);
            }
            else
            {
                Debug.Log("Fail");
            }
        });
    }
}
