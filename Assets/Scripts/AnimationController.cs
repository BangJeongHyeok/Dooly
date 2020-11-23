using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public GameObject DounerPanel;
    public GameObject GildongPanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void StartDounerAnimation()
    {

    }

    IEnumerator PlayAnimation()
    {
        yield return new WaitForSeconds(2f);

    }
}
