using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    private Text ScoreText_text;
    private Animator ScoreText_Animation;
    
    // Start is called before the first frame update
    void Start()
    {
        ScoreText_text = GetComponent<Text>();
        ScoreText_Animation = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetScore(int Score)//추가되는 값이 아니라 걍 Score변수 넣으면 그 값을 똑같이 적용시켜주는거임
    {
        ScoreText_text.text = Score.ToString();
        ScoreText_Animation.Rebind();
    }
}
