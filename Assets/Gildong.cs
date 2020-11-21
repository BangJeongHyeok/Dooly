using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gildong : MonoBehaviour
{
    public Rigidbody2D Bodyrigid;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            HitBody(Random.Range(10,80));
        }
    }

    public void HitBody(float HitPower)
    {
        Bodyrigid.AddForce(Vector2.right * HitPower, ForceMode2D.Impulse);
    }
}
