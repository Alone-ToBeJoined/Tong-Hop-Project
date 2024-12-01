using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private bool isRunning;

    [SerializeField] private Animator anim;
    [SerializeField] private DynamicJoystick dynamicJoystick;      
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float moveSpeed;
    [SerializeField] private Transform brickListParent;

    [SerializeField] private ColorType playerColor;

    [SerializeField] private float maxSlopeAngle;

    private float _horizontal;

    private float _vertical;

    private string currentAnimName;

    private RaycastHit _slopeHit;

    private bool isOnStair = false;
    private bool isMovingUp;
    private bool isMovingDown;

    public ColorType PlayerColor { get => playerColor; set => playerColor = value; }

    private void Awake()
    {
       
    }

    private bool IsOnStair()
    {
        return isOnStair;
    }
    //kiem tra khi o tren thang
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("StairLayer"))
        {
            isOnStair = true;
        }
    }

    //khi roi khoi cau thang
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("StairLayer"))
        {
            isOnStair = false;
        }
    }
    private void Update()
    {
        if (GetInput())
        {
            ChangeAnim(Constant.RunAnimName);
            if (OnSlope())
            {
                SlopeMove();
            }

            else
            {
                Move();
            }
            LookAtMoveDirection();
        }

        else
        {
            ChangeAnim(Constant.IdleAnimName);
            rb.velocity = Vector3.zero;
        }

        //Kiem tra nhan vat dang di len hay xuong thang
        if (isOnStair)
        {
            float vertical = dynamicJoystick.Vertical;

            if (vertical > 0)
            {
                isMovingUp = true;  
                isMovingDown = false;   
            }
            else if (vertical < 0)
            {
                isMovingUp = false; 
                isMovingDown= true; 
            }
            else
            {
                isMovingUp = false;
                isMovingDown = false;
            }

            if (isMovingUp)
            {
                Debug.Log("Nguoi choi dang di len");
            }
            else if (isMovingDown)
            {
                Debug.Log("Nguoi choi dang di xuong");
                //khi het gach
                
            }
        }
    }

    #region ChangeAnim

    public void ChangeAnim(string animName)
    {
        if (currentAnimName != animName)
        {
            anim.ResetTrigger(animName);
            currentAnimName = animName;
            anim.SetTrigger(animName);
        }
    }

    #endregion

    #region Movement

    public bool GetInput()
    {
        _vertical = dynamicJoystick.Vertical;
        _horizontal = dynamicJoystick.Horizontal;
        if (Mathf.Abs(_vertical) < 0.01f &&
            Mathf.Abs(_horizontal) < 0.01f)
        {
            return false;
        }
        return true;
    }

    public void Move()
    {
        if (rb != null);
        rb.velocity = new Vector3(_horizontal, 0, _vertical).normalized * moveSpeed;
    }

    public void LookAtMoveDirection()
    {
        transform.eulerAngles = new Vector3(0f, 90f + Mathf.Atan2(-_vertical, _horizontal) * 180 / Mathf.PI, 0f);
    }

    public bool OnSlope()
    {
        if (Physics.Raycast(transform.position, Vector3.down, out _slopeHit, 0.8f))
        {
            Debug.DrawRay(transform.position, Vector3.down * 0.8f, Color.red, 3f);
            float angle = Vector3.Angle(Vector3.up, _slopeHit.normal);
            return angle < maxSlopeAngle && angle != 0;
        }

        return false;
    }

    public void SlopeMove()
    {
        Vector3 moveDirection = new Vector3(_horizontal, _vertical, 0).normalized;
        rb.velocity = Vector3.ProjectOnPlane(moveDirection, _slopeHit.normal).normalized * moveSpeed;
    }

    #endregion
}

