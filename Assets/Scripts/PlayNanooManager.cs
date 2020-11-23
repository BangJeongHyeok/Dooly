using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayNANOO;

public class PlayNanooManager : MonoBehaviour
{
    private Plugin plugin;

    private string _nickName = null;
    private int _score = 0;

    public void Init()
    {
        plugin = Plugin.GetInstance();
    }

    public void SetUserInfo()
    {
        plugin.SetUUID(SystemInfo.deviceUniqueIdentifier);
        plugin.SetNickname(_nickName);
        plugin.SetLanguage("Configure.PN_LANG_KO");
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

    public void ReadRanking()
    {
        // 랭킹코드, 몇개 까지 보이는지 (50개가 최대)
        plugin.Ranking("dooly-RANK-BC09F27A-99057B5A", 50, (state, message, rawData, dictionary) =>
        {
            if (state.Equals(Configure.PN_API_STATE_SUCCESS))
            {
                ArrayList list = (ArrayList)dictionary["list"];
                foreach (Dictionary<string, object> rank in list)
                {
                    Debug.Log(rank["score"]);
                    Debug.Log(rank["data"]);
                }
            }
            else
            {
                Debug.Log("Fail");
            }
        });
    }
}
