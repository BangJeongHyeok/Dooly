using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MicholManager : MonoBehaviour
{
    [SerializeField] private GameObject _micholButton;
    [SerializeField] private Animator _micholAnim;

    bool MicholOn = false;

    void Start()
    {
        StartCoroutine(Michol_GetOut());
    }

    void Update()
    {
        
    }

    IEnumerator Michol_GetOut()
    {
        yield return new WaitForSeconds(Random.Range(3f, 10f));
        MicholOn = true;
        _micholAnim.SetBool("MicholOn", MicholOn);
        StartCoroutine(Michol_GetOut());

    }

    public void Michol_Getin()
    {
        MicholOn = false;
        _micholAnim.SetBool("MicholOn", MicholOn);
    }
}
