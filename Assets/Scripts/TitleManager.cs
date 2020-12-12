using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

namespace Dooly
{
    public class TitleManager : MonoBehaviour
    {
        private bool TitleImage = true;
        public GameObject Panel_Title;
        public GameObject Panel_Story;
        private int Page = 0;
        private bool isSkip = false;

        [SerializeField] private GameObject Loading;
        [SerializeField] private GameObject MultiButton;
        [SerializeField] private GameObject SingleButton;
        [SerializeField] private GameObject NickNamePanel;
        [SerializeField] private Text nameText;

        void Start()
        {
            isSkip = PlayerPrefs.GetInt("isSkip", 0) == 1 ? true : false;
        }

        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (!TitleImage)
                {
                    Page++;

                    if (Page == 9)
                    {
                        Global.SceneChanger.ChangeScene("SampleScene");

                        if (!isSkip)
                            PlayerPrefs.SetInt("isSkip", 1);
                    }
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

        public void OnClickMulti()
        {
            MultiButton.SetActive(false);
            SingleButton.SetActive(false);
            NickNamePanel.SetActive(true);
        }

        public void OnClickConnect()
        {
            PhotonNetwork.NickName = nameText.text;
            Loading.SetActive(true);
            Global.PhotonManager.Connect();
        }

        public void OnClickSingle()
        {
            if (TitleImage)
            {
                if (isSkip)
                    Global.SceneChanger.ChangeScene("SampleScene");
                else
                {
                    Panel_Title.SetActive(false);
                    Panel_Story.SetActive(true);
                    TitleImage = false;
                    Page = -1;
                }
            }
           
        }
    }
}