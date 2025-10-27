using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Meltingpot_InterAction : MonoBehaviour
{
    private bool isPlayerInZone = false;

    //플레이어가 멜팅팟 영역에 진입했을 때
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInZone = true;
            Debug.Log("미니게임을 하고 싶다면 F키를 누르세요");
        }
    }
    
    //플레이어가 트리거 영역에서 벗어났을 때

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInZone = false;
        }
    }

    void Update()
    {
        if (isPlayerInZone && Input.GetKeyDown(KeyCode.F))
        {
            SceneManager.LoadScene("mini_game");
        }
    }

}
   
