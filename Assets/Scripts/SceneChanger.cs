using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    private static SceneChanger instance = null;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public static SceneChanger Instance
    {
        get
        {
            if (instance == null)
                return null;
            return instance;
        }
    }

    public void ChangeScene(string SceneName)
    {
        SceneManager.LoadSceneAsync(SceneName);
    }
}
