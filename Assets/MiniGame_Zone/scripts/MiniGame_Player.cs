using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGame_Player : MonoBehaviour
{
    
    Animator animator;
    Rigidbody2D _rigidbody;

    public float flapForce = 6f; //점프하는 힘
    public float forwardSpeed = 3f; //앞으로 나아가는 힘
    public bool isDead = false;
    private float deathCooldown = 0f; //바로 죽는게 아닌, 일정 시간 있다가 죽을 수 있도록

    private bool isFlap = false; //점프를 뛰었는지 아닌지 구분
    
    public bool godMode=false;
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();

        
        //예외처리
        if (animator == null)
        {
            Debug.LogError("No animator attached to MiniGame_Player");
        }

        if (_rigidbody == null)
        {
            Debug.LogError("No rigidbody attached to MiniGame_Player");
        }
    }


    void Update()
    {
        if (isDead)
        {
            
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                isFlap = true;
            }
        }
    }


    void FixedUpdate()
    {
        if (isDead) return;
        
        Vector3 velocity = _rigidbody.velocity; //velocity는 가속도. 리지드바디에서 갖고 있는 가속도 값을 담음
        velocity.x = forwardSpeed; //x축의 가속도를 똑같은 속도로 계속 넣어줌

        if (isFlap) //isFlap이 true일 경우
        {
            velocity.y += flapForce;
            isFlap = false;
        }
        
        _rigidbody.velocity = velocity;
    }
}
