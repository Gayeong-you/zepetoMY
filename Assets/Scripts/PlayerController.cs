using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb; //rb는 Rigidbody2D를 담은 변수
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); //리지드바디 가져오기
        rb.position = new Vector2(0, 0);
    }

    void Update()
    {
        float moveX = 0f;
        float moveY = 0f;
        
        if (Input.GetKey(KeyCode.W)) moveY = 1f;
        if (Input.GetKey(KeyCode.A)) moveX = -1f;
        if (Input.GetKey(KeyCode.S)) moveY = -1f;
        if (Input.GetKey(KeyCode.D)) moveX = 1f;

        Vector2 movement = new Vector2(moveX, moveY).normalized; //x축 방향 이동 = moveX, y축 방향 이동 = moveY
                                                                 //노말 달아줘서 대각선 이동시 속도 2배 되는걸 방지
        rb.MovePosition(rb.position + movement * speed * Time.deltaTime); //현재 위치+ 이동 방향*속도*프레임 시간 = 새위치
    }

    void LateUpdate()
    {
        //캐릭터가 맵 밖으로 나가지 않게 제한
        
    }
}


