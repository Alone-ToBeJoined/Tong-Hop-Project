using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private DynamicJoystick _joystick;
    [SerializeField] Animator anim;
    [SerializeField] GameObject visualPlayer;

    [SerializeField] private float _moveSpeed;

    private float _horizontal;
    private float _vertical;
    private string currentAnimName;

    private void Update()
    {
            _rigidbody.velocity = new Vector3(_joystick.Horizontal * _moveSpeed, _rigidbody.velocity.y, _joystick.Vertical * _moveSpeed);

        if (GetInput())
        {
            transform.rotation = Quaternion.LookRotation(_rigidbody.velocity);

            ChangeAnim(Constant.RunAnimName);
        }
        else
        {
            ChangeAnim(Constant.IdleAnimName);
        }
    }

    private bool GetInput()
    {
        _vertical = _joystick.Vertical;
        _horizontal = _joystick.Horizontal;
        if (_joystick.Direction == Vector2.zero)
        {
            return false;
        }
        return true;
    }

    #region ChangeAnim

    public void ChangeAnim(string animName)
    {
        //Debug.Log("Change Anim: " + animName + " " + this.gameObject.name);
        if (currentAnimName != animName)
        {
            //Debug.Log("Change");
            anim.ResetTrigger(currentAnimName);
            currentAnimName = animName;
            anim.SetTrigger(animName);
            Debug.Log(currentAnimName);
        }
    }

    #endregion
}
