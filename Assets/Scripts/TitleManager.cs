﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleManager : MonoBehaviour
{
    private bool TitleImage = true;
    public GameObject Panel_Title;
    public GameObject Panel_Story;
    private int Page = 0;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (TitleImage)
            {
                Panel_Title.SetActive(false);
                Panel_Story.SetActive(true);
                TitleImage = false;
            }
            else
            {
                Page++;

                if (Page == 9)
                    SceneChanger.Instance.ChangeScene("SampleScene");
                else
                {
                    if (Page == 3 || Page == 6 || Page == 7 || Page == 8)
                        for (int i = 0; i < Page; i++)
                            if (GetStoryChild(i).activeSelf)
                                GetStoryChild(i).SetActive(false);
                    GetStoryChild(Page).SetActive(true);
                }
            }
        }
    }

    GameObject GetStoryChild(int ChildCount)
    {
        return Panel_Story.transform.GetChild(ChildCount).gameObject;
    }
}