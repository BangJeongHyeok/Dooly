using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RankingUnit : MonoBehaviour
{
    [SerializeField] private Text _rank;
    [SerializeField] private Text _name;
    [SerializeField] private Text _score;

    public void SetRankInfo(int rank, string name, int score)
    {
        _rank.text = rank.ToString();
        _name.text = name;
        _score.text = score.ToString();
    } 
}
