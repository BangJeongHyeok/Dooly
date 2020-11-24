using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GildongBodyPart : MonoBehaviour
{
    [SerializeField] private HingeJoint2D _hinge;
    [SerializeField] private Rigidbody2D _rigid;
    private Vector2 _initPos;

    private bool _posReset = false;
    private bool _rotReset = false;
    private void Awake()
    {
        _initPos = this.transform.localPosition;
    }

    public void ResetPart()
    {
        _posReset = false;
        _rotReset = false;

        StartCoroutine(Rewind());
    }

    private IEnumerator Rewind()
    {
        while (true)
        {
            float distance = Vector3.Distance(this.transform.localPosition, (Vector3)_initPos);

            if (distance > 0.1f)
            {
                this.transform.localPosition = Vector3.Lerp(this.transform.localPosition, _initPos, 8.0f * Time.deltaTime);
            }
            else
            {
                _posReset = true;
            }

            if (Mathf.Abs(this.transform.localRotation.eulerAngles.z) > 5f)
            {
                this.transform.localRotation = Quaternion.Lerp(this.transform.localRotation, Quaternion.identity , 7.0f * Time.deltaTime);
            }
            else
            {
                _rotReset = true;
            }

            if (_posReset && _rotReset)
            {
                break;
            }

            yield return null;
        }
    }

    public void SetHingeEnabled(bool enabled)
    {
        _hinge.enabled = enabled;
    }

    public void ReConnectPart()
    {
        _rigid.rotation = 0;
        _rigid.gravityScale = 1;
        SetHingeEnabled(true);
    }

    public void DisConnectPart()
    {
        SetHingeEnabled(false);

        _rigid.angularVelocity = 0;
        _rigid.velocity = Vector2.zero;
        _rigid.gravityScale = 0;
    }

    public bool CheckAllReset()
    {
        return (_posReset && _rotReset);
    }
}
