using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicholButton : MonoBehaviour
{
    public GameObject IceSword;

    private void OnEnable()
    {
        StartCoroutine(HandOverSword());
    }

    public void Throw_Sword()
    {
        IceSword.transform.position = this.transform.position;
        IceSword.SetActive(true);
    }

    private IEnumerator HandOverSword()
    {
        yield return new WaitForSeconds(Random.Range(2f, 2f));

        if (!IceSword.activeSelf)
        {
            Throw_Sword();
        }

        StartCoroutine(HandOverSword());
    }

    public void GetOutMichol()
    {
        this.gameObject.SetActive(false);
    }
}
