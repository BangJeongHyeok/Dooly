using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GildongAnimeEvent : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverPanel;

    public void EndAnime()
    {
        _gameOverPanel.SetActive(true);
    }
}
